using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Defines the warrior class type
 * Written by: Betsey McCarthy
 */
public class Warrior : ClassType {
	private GameObject gc;
	private GameController gameController;

	//Initializes default actions list for warriors
	public Warrior(){
		ClassName = "Warrior";
		gc = GameObject.Find ("GameController");
		gameController= gc.GetComponent <GameController> ();
		Actions = DefaultActions(); 
	}

	//creates unique actions for warriors
	public List<Action> DefaultActions(){
		List<Action> defaultActions = new List<Action>();
		defaultActions.Add (new SingleAttack ("Slash", 1, gameController.AttackSpecialEffects[0]));
		defaultActions.Add (new StrongAttack ("Impale",3, gameController.AttackSpecialEffects[0]));
		defaultActions.Add (new StatusEffectAttack ("Stab", 1, gameController.AttackSpecialEffects[0]));
		defaultActions.Add (new FatalBlow ("Fatal Blow",14, gameController.AttackSpecialEffects[0]));
		return defaultActions;
	}

	//Initializes class bonus damage for warriors (weapons triangle).  Warriors are strong against rangers but weak to magicians
	public override void InitializeClassBonusDamage(){
		ClassEffectiveness.Add ("Ranger", 2);
		ClassEffectiveness.Add ("Magician", .5);
		ClassEffectiveness.Add ("Warrior", 1);
	}

}
