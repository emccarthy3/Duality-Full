using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/* 
 * UIController class Controls the display for the battle. Communicates with both Battle and Rhythm Controller to respond to changes
 * Written by: Betsey McCarthy
 *
 */

public class UIController : MonoBehaviour {
	private GameObject gc;
	private GameController gameController;
	[SerializeField] private Popup enemyChooser;
	[SerializeField] private Popup moveChooser;
	[SerializeField] private Popup attackChooser;
	[SerializeField] private Popup teamAttackChooser;
	[SerializeField] private Popup restartPopup;
	[SerializeField] private BattleFinishedPopup battleFinishedPopup;
	[SerializeField] private HelpMenu helpMenu;
	[SerializeField] private Battle battle;
	[SerializeField] private Button enemy1Button;
	[SerializeField] private Button enemy2Button;
	[SerializeField] private Button teamEnemy1Button;
	[SerializeField] private Button teamEnemy2Button;
	[SerializeField] private Button battleFinishedButton;
	[SerializeField] private Button singleAttackButton;
	[SerializeField] private Button teamAttackButton;
	[SerializeField] private Button healButton;
	[SerializeField] private Button blockButton;
	[SerializeField] private Button exitHelpButton;
	[SerializeField] private Button restartButton;
	[SerializeField] private Button toMainMenuButton;
	[SerializeField] private Button helpButton;
	[SerializeField] private Button encourageButton;
	[SerializeField] private Text playerType;
	[SerializeField] private Text partnerType;
	[SerializeField] private Text enemy1Type;
	[SerializeField] private Text enemy2Type;
	[SerializeField] private List<Button> moveButtons;
	[SerializeField] private Text playerHP;
	[SerializeField] private Text partnerHP;
	[SerializeField] private Text enemy1HP;
	[SerializeField] private Text enemy2HP;
	[SerializeField] private Text rpText;
	[SerializeField] private Text damageDealt;
	[SerializeField] private List<Text> hpList;
	[SerializeField] private List<ParticleSystem> particleSystems;
	[SerializeField] private Text moveStatusText;
	private List<Text> typeLabels;
	private Player player;
	private const int MAX_NUM_BATTLES = 3;
	private const int DEFAULT_HP = 10;

	// Initializes UI for battle, starts with a UI for the character to choose their first move.
	void Start () {
		typeLabels = new List<Text> ();
		typeLabels.Add (playerType);
		typeLabels.Add (partnerType);
		typeLabels.Add (enemy1Type);
		typeLabels.Add (enemy2Type);
		SetTypeLabels ();
		GameObject playerSprite = GameObject.Find ("PlayerSprite");
		playerSprite.GetComponent<SpriteRenderer> ().sprite = gameController.YourPlayer.PlayerSprite;
		GameObject partnerSprite = GameObject.Find ("PartnerSprite");
		partnerSprite.GetComponent<SpriteRenderer> ().sprite = gameController.YourPartner.PlayerSprite;
		//initially, close unnecessary menus and open menus for first attack
		enemyChooser.Close ();
		teamAttackChooser.Close ();
		attackChooser.Close ();
		battleFinishedPopup.Close ();
		restartPopup.Close ();
		helpMenu.Close ();
		moveChooser.Open ();
		//set button listeners for menus
		enemy1Button.onClick.AddListener(() =>  OnEnemySelect(battle.Enemy1));
		enemy2Button.onClick.AddListener(() =>  OnEnemySelect(battle.Enemy2));
		healButton.onClick.AddListener(() =>  battle.StartCoroutine(battle.Heal()));
		blockButton.onClick.AddListener(() =>  battle.StartCoroutine(battle.Block()));
		encourageButton.onClick.AddListener(() =>  battle.StartCoroutine(battle.EncouragePartner()));
		teamEnemy1Button.onClick.AddListener(() =>  OnTeamAttackSelect(battle.Enemy1));
		teamEnemy2Button.onClick.AddListener(() =>  OnTeamAttackSelect(battle.Enemy2));
		teamAttackButton.onClick.AddListener(() =>  {if(battle.AttackableEnemies.Count > 0){
				battle.SelectedAction = new TeamAttack("Team attack", 1, gameController.AttackSpecialEffects[0]);
				OnAttackSelect (new TeamAttack("Team attack", 1, gameController.AttackSpecialEffects[0]));
		} else{
			moveStatusText.text = "All enemies are blocking!";
			attackChooser.Close();
		}
			});
		singleAttackButton.onClick.AddListener (() => {if(battle.AttackableEnemies.Count > 0){
			moveChooser.Close ();
			attackChooser.Open ();
		} else{
			moveStatusText.text = "All enemies are blocking!";
			attackChooser.Close();
		}
		});
		helpButton.onClick.AddListener(() =>  { helpMenu.Open(); attackChooser.Close(); ChangeButtonVisibility(false);});
		exitHelpButton.onClick.AddListener(() => { helpMenu.Close(); ChangeButtonVisibility(true);});
		restartButton.onClick.AddListener(() => { SceneManager.LoadScene("newBattle");});
		toMainMenuButton.onClick.AddListener(() => { SceneManager.LoadScene("StartScene");});
		battleFinishedButton.onClick.AddListener(() =>  ToNextScene());
		//set initial HP texts
		playerHP.text = "Player HP: " + gameController.YourPlayer.HP;
		partnerHP.text = "Partner HP: " + gameController.YourPartner.HP;
		enemy1HP.text = "Enemy 1 HP: " + battle.Enemy1.HP;
		enemy2HP.text = "Enemy 2 HP: " + battle.Enemy2.HP;
	}

	//when a move is chosen by the player, another window will be displayed to show which enemy to use the attack on
	public void OnAttackSelect(Action action){
		attackChooser.Close ();
		moveChooser.Close ();
		if (action.GetType ().Name == "TeamAttack") {
			teamAttackChooser.Open ();
		} else {
			enemyChooser.Open ();
		}
	}

	//Updates the ui accordingly when the players use encourage
	public  IEnumerator Encourage(){
		damageDealt.text = battle.Battlers[0].Name + " and " + battle.Battlers[1].Name +  " are encoraging each other " ;
		yield return new WaitForSeconds (1);
		rpText.text = "RP : " + gameController.YourPlayer.RP;
		damageDealt.text = "RP increased by 1!" ;

	}
	//this method updates the HP levels once a value has changed either from an attack or heal move.
	public IEnumerator UpdateHPLabels(string name,int index,double hp, bool hasStatusEffect, int delay){
		yield return new WaitForSeconds (delay);
		if (hp <= 0) {
			hpList [index].text = name + " HP: " + 0;
		}else {
			hpList [index].text = name + " HP: " + hp;
		}
		if (hasStatusEffect) {
			hpList [index].color = Color.red;
		}

	}
	//Shows what move was used and how much damage was dealt to the player to create an easier to understand ui
	public IEnumerator UpdateDamageDealt(string attackerName,Action action, string defenderName, double damage, int defenderIndex){
		damageDealt.text = attackerName + " used " + action.Name + " on " + defenderName;
		particleSystems[defenderIndex].Play ();
		yield return new WaitForSeconds (1);
		if (damage > 0) {
			damageDealt.text = attackerName + " dealt " + damage + " damage to " + defenderName;
		} else {
			damageDealt.text = "Attack missed!";
		}
	}

	//Loop for intializing battler type labels (warrior, ranger, magician)
	public void SetTypeLabels(){
		for (int i = 0; i < battle.Battlers.Count; i++) {
			typeLabels [i].text = battle.Battlers [i].Type.ClassName;
		}
	}
	//once the enemy to attack is chosen through the enemy chooser display, the attack move will be carried out.
	public void OnEnemySelect(Character enemy){
		battle.Fight(enemy);
		enemyChooser.Close ();
	}
	public void ToNextScene(){
		gameController.BattleLoop += 1;
		if (gameController.BattleLoop == MAX_NUM_BATTLES) {
			//make the final scene pop up
			gameController.BattleLoop = 0;
			gameController.SwitchScene ("End Scene");
		} else {
			gameController.SwitchScene ("Dialogue1");
		}
	}
	//when a team attack is selected, a UI will appear to do the rhthym minigame
	public void OnTeamAttackSelect(Character enemy){
		battle.Defender = enemy;
		GameObject rc = GameObject.Find ("RhythmController");
		RhythmController rhythmController = rc.GetComponent <RhythmController> ();
		teamAttackChooser.Close ();
		ChangeCanvasState (false);
		rhythmController.StartRhythmGame();
	}

	//rhthym controller calls this method once the team attack is finished and sends the final score to the UIController to send to the battle ( team attack damage will increase by 1 between battles).
	public void teamAttackisFinished(int score){
		if (score > 0) {
			battle.Defender.HP -= score + gameController.BattleLoop;
			battle.Defender.IsAbleToHealState = new CanHealState (this, battle, battle.Defender);
		}
		battle.UpdateUIPostAttack (score + gameController.BattleLoop);
	}

	//Heal status is updated when a heal occurs (in heal state)
	public IEnumerator UpdateHealStatus(string healerName, int HPRecovered, bool successfulHeal, int healCount){
		if (successfulHeal) {
			damageDealt.text = healerName + " recovered " + HPRecovered + " hp ";
			yield return new WaitForSeconds (1);
			battle.SwitchAttacker ();
		} else if (healCount == 0) {
			moveStatusText.text = "No more heals left! Pick a different move";
		} else {
			moveStatusText.text = "HP is already full! Pick a different move";
		}
	}
	public IEnumerator UpdateBlockStatus(string blockerName){		
		damageDealt.text = blockerName + " is blocking! ";
		yield return new WaitForSeconds (1);

	}
	//opens popups for when the battle ends, either by the enemies being defeated or the player being defeated (determined by didDefeatEnemies)
	public void OnBattleEndDialogue(bool didDefeatEnemies){
		gameController.YourPlayer.HP = DEFAULT_HP + gameController.BattleLoop * 2;
		gameController.YourPartner.HP = DEFAULT_HP + gameController.BattleLoop * 2;;
		if (didDefeatEnemies) {
			battleFinishedPopup.Open ();
		} else {
			restartPopup.Open ();
		}
	}
	//this method makes the character move buttons temporarily disabled so the player cannot move while the enemy is moving.
	public void ChangeButtonVisibility(bool isPlayerTurn){
		if (!isPlayerTurn) {
			attackChooser.Close ();
			moveChooser.Close ();
		} else {
			moveChooser.Open ();
		}
	}

	//sets listeners for move buttons to perform move assigned to them according to the list of moves the character currently has. 
	public void SetButtonListeners(Character battler){
		gc = GameObject.Find ("GameController");
		gameController= gc.GetComponent <GameController> ();
		if (battler.GetType().Name != "Enemy") {
			moveChooser.Open ();
		}
		moveStatusText.text = "Choose an action";
		int i = 0;
		foreach (Button button in moveButtons) { 
			moveButtons [i].GetComponentInChildren<Text> ().text = battler.Type.Actions[i].Name;
			if (i > gameController.BattleLoop + 2) {
				moveButtons [i].gameObject.SetActive (false);
			}
			i++;
		}
		//this code throws an out of bounds exception if in a loop
		moveButtons [0].onClick.AddListener (() => {
			battle.SelectedAction = battler.Type.Actions [0];
			OnAttackSelect (battler.Type.Actions [0]);
		});
		moveButtons [1].onClick.AddListener (() => {
			battle.SelectedAction = battler.Type.Actions [1];
			OnAttackSelect (battler.Type.Actions [1]);
		});
		moveButtons [2].onClick.AddListener (() => {
			battle.SelectedAction = battler.Type.Actions [2];
			OnAttackSelect (battler.Type.Actions [2]);
		});
		moveButtons [3].onClick.AddListener (() => {
			battle.SelectedAction = battler.Type.Actions [3];
			OnAttackSelect (battler.Type.Actions [3]);
		});
	}

	//when a battler is defeated, this method is called to ensure the UI does not update defeated player HP labels.  Replaces HP with "defeated"
	public void RemoveFromHPList(int index){
		hpList [index].text = "Defeated!";
		hpList.RemoveAt (index);
		particleSystems.RemoveAt (index);
	}

	//Canvas will be disabled on team attack, reenabled after team attack
	public void ChangeCanvasState(bool state){
		GameObject c = GameObject.Find ("Canvas");
		Canvas canvas = c.GetComponent <Canvas> ();
		canvas.enabled = state;
	}

	//if an enemy is defeated, prevent the user from selecting them when attacking
	public void ChangeEnemyButtonVisibility(string enemyName, bool visibility){
		if (enemyName == "Enemy 1") {
			enemy1Button.gameObject.SetActive (visibility);
			teamEnemy1Button.gameObject.SetActive (visibility);
		} else {
			enemy2Button.gameObject.SetActive (visibility);
			teamEnemy2Button.gameObject.SetActive (visibility);
		}
	}
}

