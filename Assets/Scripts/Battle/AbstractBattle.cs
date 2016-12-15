using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Engine code for creating a battle
 * Written by: Betsey McCarthy
 */
public abstract class AbstractBattle: MonoBehaviour  {
	private Character defender;
	private Character attacker;
	private List<Character> battlers;
	private List<Character> attackableEnemies;
	private List<Character> attackablePlayers;
	private Action selectedAction;

	//implement this method to initialize the battle (i.e. add number of battlers to a list, initialize HP, update ui accordingly, etc. In our implementation, we add 4 battlers to a list, initialize HP, update UI labels, etc.)
	public abstract void Start();

	//the update method can be used to check any changes in the battle in realtime (i.e. check if certain players are defeated and act accordingly)
	public abstract void Update();

	//this method is used for the automated enemy attacks.  Override it to implement custom AI when the enemy attacks (i.e. enemy will heal if has less than half hp, enemy attacks player with type weakness, etc.)
	public abstract void EnemyAttacks();

	//will play out the fight move (can implement animation).  Used to call deal damage method and update ui accordingly in concrete implementation
	public abstract void Fight (Character defender);

	//Deals damage on the defender according to how damage calculation is implemented
	public abstract double DealDamage (Character defender);

	//allows for turn-based attacks, call after an attack/move is made (in our implementation, we also reset blocking state / check for status effect damage)
	public abstract void SwitchAttacker ();

	//can override this if ui is connected to battle (in our implementation, this method is used to start coroutines for updating the ui in a way that makes sense to the player).
	public virtual void UpdateUIPostAttack(double damage){
	}

	//Defender is the character being attacked
	public Character Defender{
		get{ return defender; }
		set{ defender = value; }
	}
	//Attacker is the current character selected in the battle (based on turn)
	public Character Attacker{
		get{ return attacker; }
		set{ attacker = value; }
	}
	//defines a list of battlers in the battle
	public List<Character> Battlers{
		get{ return battlers; }
		set{ battlers = value; }
	}
	//defines a list of enemies which are attackable (not defeated/blocking)
	public List<Character> AttackableEnemies{
		get{ return attackableEnemies; }
		set{ attackableEnemies = value; }
	}
	//defines a list of players which are attackable (not defeated/blocking)
	public List<Character> AttackablePlayers{
		get{ return attackablePlayers; }
		set{ attackablePlayers = value; }
	}
	//property for setting/getting the move selected for the current turn
	public Action SelectedAction{
		get{return selectedAction;}
		set{ selectedAction = value; }
	}
}
