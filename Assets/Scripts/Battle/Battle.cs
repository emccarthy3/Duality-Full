using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

/*
 * Defines the concrete implementation of the Battle class.  
 * Written by: Betsey McCarthy
 */
using UnityEngine.SceneManagement;


public class Battle : AbstractBattle{
	private Character playerChar;
	private Character partnerChar;
	private Enemy enemy1;
	private Enemy enemy2;
	private Action selectedAction;
	[SerializeField] private Text status;
	[SerializeField] private Text currentPlayer;
	[SerializeField] private UIController ui;
	//private List<Character> battlers;
	private List<Character> yourTeam;
	//private List<Character> attackablePlayers;
	//private List<Character> attackableEnemies;
	private List<int> enemyRandomAttacks;
	private int attackerIndex = 0;
	private GameObject gc;
	private GameController gameController;
	private const int FINAL_PLAYER = 2;
	private const int DEFAULT_HEAL_AMOUNT = 2;
	private const int NUM_PERSONALITIES = 3;
	private const int FINAL_ENEMY = 4;
	private const int ENEMY_LOOP = 6;
	//default HP is the same value as default rp, so the two are used interchangeably
	private const int DEFAULT_HP = 10;
	private Dictionary<int,Enemy> enemies;
	[SerializeField] private AudioClip shootArrow;
	private AudioSource source; 
	private int healCount = 3;
	private List<string> statusEffectAttacks;

	//initializes battle. Sets sprites for enemies, sets UI texts appropriately, and sets starting states for battlers (and adds them to appropriate lists) 
	  public override void Start(){
		source = GetComponent<AudioSource> ();
		gc = GameObject.Find ("GameController");
		gameController = gc.GetComponent <GameController> ();
		//between battles, the amount of times you can heal decreases
		healCount -= gameController.BattleLoop;
		enemies = new Dictionary<int, Enemy>();
		InitializeEnemyDictionary ();
		GameObject background = GameObject.Find ("Background");
		background.GetComponent<SpriteRenderer> ().sprite = gameController.Backgrounds[gameController.BattleLoop];
		Battlers = new List<Character> ();
		yourTeam = new List<Character> ();
		AttackablePlayers = new List<Character> ();
		AttackableEnemies = new List<Character> ();
		statusEffectAttacks = new List<string> ();
		playerChar = gameController.YourPlayer;
		partnerChar = gameController.YourPartner;
		//RP will change depending on dialogue beforehand
		status.text = "RP: " + playerChar.RP;
		//enemies are set depending on the class type of the player
		enemy1= enemies[gameController.YourPlayer.PersonalityType % NUM_PERSONALITIES * 2 + (ENEMY_LOOP * gameController.BattleLoop)];
		enemy2 = enemies[gameController.YourPlayer.PersonalityType % NUM_PERSONALITIES  * 2 + (ENEMY_LOOP * gameController.BattleLoop)  + 1];
		GameObject enemy1Sprite = GameObject.Find ("Enemy1Sprite");
		enemy1Sprite.GetComponent<SpriteRenderer> ().sprite = enemy1.PlayerSprite;
		GameObject enemy2Sprite = GameObject.Find ("Enemy2Sprite");
		enemy2Sprite.GetComponent<SpriteRenderer> ().sprite = enemy2.PlayerSprite;
		enemy1.Name = "Enemy 1";
		enemy2.Name = "Enemy 2";
		// Max HP increases by two in between battles to increase difficulty
		enemy1.HP = gameController.BattleLoop * 2 + DEFAULT_HP;
		enemy2.HP = gameController.BattleLoop * 2 + DEFAULT_HP;
		ui.SetButtonListeners (playerChar);
		//list of battlers is used to switch turns
		Battlers.Add (playerChar);
		Battlers.Add (partnerChar);
		Battlers.Add (enemy1);
		Battlers.Add (enemy2);
		//all battlers start in the no heal state and alive state
		for (int i = 0; i < Battlers.Count; i++) {
			Battlers [i].HealCount = healCount;
			Battlers [i].IsAbleToHealState = new NoHealState (ui,this, Battlers[i]);
			Battlers [i].LifeState = new AliveState (ui, this, Battlers [i]); 
			Battlers [i].HasEffectDamage = false;
		}
		statusEffectAttacks.Add ("StatusEffectAttack");
		statusEffectAttacks.Add ("ArrowFlurry");
		statusEffectAttacks.Add ("MindBoggle");
		Attacker = playerChar;
	}

	//checks to see if both enemies were defeated and will load the next scene if true
	public override void Update(){
		if (!Battlers.Contains (enemy1) && !Battlers.Contains (enemy2)) {
			ui.OnBattleEndDialogue (true);
			ui.ChangeButtonVisibility (false);
		}
		if(!Battlers.Contains(playerChar)){
			ui.ChangeButtonVisibility (false);
			ui.OnBattleEndDialogue (false);
		}
	}

	//Enemy dictionary is used to generate the enemies in the different battles. The enemies' classes will depend on your player and partner's classes.  For the first battle, you will have an advantage against both enemies, battle 2 you will only 
	//have one advantage, and battle 3 will have no advantages.
	private void InitializeEnemyDictionary(){
		//enemies if your player is a magician, 1st battle.
		enemies.Add(0,new Enemy(new Warrior(),gameController.Sprites[3])); 
		enemies.Add(1,new Enemy(new Magician(),gameController.Sprites[5]));
		//enemies if your player is a warrior, 1st battle 
		enemies.Add(2,new Enemy(new Ranger(),gameController.Sprites[4])); 
		enemies.Add(3,new Enemy(new Warrior(),gameController.Sprites[3])); 
		//enemies if your player is a ranger, 1st battle
		enemies.Add(4, new Enemy(new Magician(),gameController.Sprites[5])); 
		enemies.Add(5, new Enemy(new Ranger(),gameController.Sprites[4])); 
		//enemies if your player is a magician, 2nd battle 
		enemies.Add(6,new Enemy(new Warrior(),gameController.Sprites[6])); 
		enemies.Add(7,new Enemy(new Ranger(),gameController.Sprites[7])); 
		//enemies if your player is a warrior, 2nd battle 
		enemies.Add(8,new Enemy(new Ranger(),gameController.Sprites[7])); 
		enemies.Add(9,new Enemy(new Magician(),gameController.Sprites[8])); 
		//enemies if your player is a ranger, 2nd battle 
		enemies.Add(10,new Enemy(new Magician(),gameController.Sprites[8])); 
		enemies.Add(11,new Enemy(new Warrior(),gameController.Sprites[6])); 
		//enemies if your player is a magician, 3rd battle 
		enemies.Add(12,new Enemy(new Ranger(),gameController.Sprites[10])); 
		enemies.Add(13,new Enemy(new Ranger(),gameController.Sprites[10])); 
		//enemies if your player is a warrior, 3rd battle 
		enemies.Add(14,new Enemy(new Magician(),gameController.Sprites[11])); 
		enemies.Add(15,new Enemy(new Magician(),gameController.Sprites[11])); 
		//enemies if your player is a ranger, 3rd battle 
		enemies.Add(16,new Enemy(new Warrior(),gameController.Sprites[9])); 
		enemies.Add(17,new Enemy(new Warrior(),gameController.Sprites[9])); 
	}

	// Performs fighting moves when chosen.  Puts a delay between action selected and the move performing for a more natural feel
	public override void Fight(Character defender){
		source.PlayOneShot (shootArrow);
		Defender = defender;
		double damage = DealDamage (Defender);
		//if the status effect attack hit, do status effect damage on the defender
		if (statusEffectAttacks.Contains(SelectedAction.GetType().Name) && damage > 0) {
			Defender.HasEffectDamage = true;
			Debug.Log (Attacker.Name + " HAS EFFECT DAMAGE");
			Defender.EffectDamage = SelectedAction.EffectDamage;
		}
		UpdateUIPostAttack (damage);
	}

	// Method to trigger enemy attacks after both player characters attack. Implements AI
	public override void EnemyAttacks(){
		//if the enemy's HP is less than half and the enemy has heals available, heal
		if (Attacker.HP <= (gameController.BattleLoop * 2 + DEFAULT_HP) / 2 && Attacker.HealCount > 0) {
			StartCoroutine (Heal ());
		} else {
			//if at least one player is attackable, the enemy will either block or attack (this is randomly chosen, 70% chance of attack, 30% chance of block)
			if (AttackablePlayers.Count > 0) {
				if (Random.Range(0f,1f) < .7) {
					SelectedAction = Attacker.Type.Actions [Random.Range (0, gameController.BattleLoop + 2)];
					Fight (AttackablePlayers [Random.Range (0, AttackablePlayers.Count)]);
				} else {
					StartCoroutine (Block ());
				}
			} else { 
				//if there's no attackable players, no available heals or HP is too high, the enemies will block
				StartCoroutine (Block ());
			}
		}
	}

	//After an attack, coroutines will start to allow the player to see what move was used and how much damage it did (and check if the defender was defeated)
	public override void UpdateUIPostAttack(double damage){
		StartCoroutine(ui.UpdateDamageDealt (Attacker.Name,SelectedAction, Defender.Name, damage,Battlers.IndexOf(Defender)));
		StartCoroutine(ui.UpdateHPLabels (Defender.Name, Battlers.IndexOf(Defender), Defender.HP, Defender.HasEffectDamage,1));
		StartCoroutine(CheckIfDefeated (Defender,true));
	}

	//When an attacker blocks, they will change state to blocking state and the ui will let the player know a block occurred
	public IEnumerator Block(){
		ui.ChangeButtonVisibility (false);
		Attacker.IsBlockingState = new BlockingState (ui, this, Attacker);
		StartCoroutine(ui.UpdateBlockStatus (Attacker.Name));
		yield return new WaitForSeconds (1);
		SwitchAttacker ();
	}

	//Encouraging your partner will increase RP by 1, making team attacks easier to perform
	public IEnumerator EncouragePartner(){
		ui.ChangeButtonVisibility (false);
		if (playerChar.RP < DEFAULT_HP) {
			playerChar.RP += 1;
		}
		StartCoroutine(ui.Encourage ());
		yield return new WaitForSeconds (2);
		SwitchAttacker ();
	}

	//this method will check whether or not the defender was defeated in battle. If the defender was defeated, the UI will update accordingly and the battler will be taken out of the battler list
	public IEnumerator CheckIfDefeated(Character target, bool needToSwitch){
		yield return new WaitForSeconds (2);
		if (target.HP <= 0) {
			target.LifeState = new DefeatedState (ui, this, target);
		}
		if (needToSwitch) {
			SwitchAttacker ();
		}
	}
	//will calculate damage dealt. More damage is dealt depending on the battle loop
	public override double DealDamage(Character defender){
		double damageDealt = SelectedAction.CalculateDamage(Attacker , Defender, gameController.BattleLoop);
		Defender.HP -= damageDealt;
		if (damageDealt > 0) {
			Defender.IsAbleToHealState = new CanHealState (ui, this, Defender);
		}
		return damageDealt;
	}

	//property for setting enemies for player attacks. Used in UIController to set enemy choice buttons
	public Enemy Enemy1{
		get{ return enemy1; }
		set{ enemy1 = value; }
	}

	//property for setting enemies for player attacks. Used in UIController to set enemy choice buttons
	public Enemy Enemy2{
		get{ return enemy2; }
		set{ enemy2 = value; }
	}
	//defines list of the characters on your team (player and partner)
	public List<Character> YourTeam{
		get{ return yourTeam; }
		set{ yourTeam= value; }
	}

	//the player will recover HP depending on the battle, and will switch to no heal state if the player cannot heal (full HP or out of heals)
	public IEnumerator Heal (){
		if (Attacker.HP == DEFAULT_HP + gameController.BattleLoop * 2 || Attacker.HealCount == 0) {
			Attacker.IsAbleToHealState = new NoHealState (ui, this, Attacker);
		}
		Attacker.IsAbleToHealState.Heal (DEFAULT_HP + gameController.BattleLoop * 2, gameController.BattleLoop + 2);
		yield return new WaitForSeconds (0);			
	}

	//allows for turn based attack system. Will deal any effect damage the battler has
	public override void SwitchAttacker(){
		attackerIndex++;
		if (attackerIndex > Battlers.Count-1) {
			attackerIndex = 0;
			ui.ChangeButtonVisibility (true);
		}
		Attacker = Battlers [attackerIndex];
		Attacker.IsBlockingState = new AttackableState (ui, this, Attacker);
		if (Attacker.HasEffectDamage) {
			Attacker.HP -= Attacker.EffectDamage;
			Attacker.IsAbleToHealState = new CanHealState (ui, this, Attacker);
			StartCoroutine(ui.UpdateHPLabels (Attacker.Name, Battlers.IndexOf(Attacker), Attacker.HP, true,0));
			StartCoroutine(CheckIfDefeated(Attacker,false));
		}
		if (Attacker.GetType ().Name == "Enemy") {			
			ui.ChangeButtonVisibility (false);
			EnemyAttacks ();
		}
		ui.SetButtonListeners (Battlers [attackerIndex]);
		currentPlayer.text = Attacker.Name + "'s turn";
	}

}
