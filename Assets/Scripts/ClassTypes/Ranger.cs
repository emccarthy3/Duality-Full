using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Defines the ranger class type
 * Written by: Betsey McCarthy
 */
public class Ranger : ClassType {
	private GameObject gc;
	private GameController gameController;

	//Constructor for ranger. Sets default actions
	public Ranger(){
		ClassName = "Ranger";
		gc = GameObject.Find ("GameController");
		gameController= gc.GetComponent <GameController> ();
		Actions = DefaultActions();
	}

	//Unique actions for the ranger class type
	public List<Action> DefaultActions(){
		List<Action> defaultActions = new List<Action>();
		defaultActions.Add (new SingleAttack ("Shoot Arrow", 1, gameController.AttackSpecialEffects[0]));
		defaultActions.Add (new StrongAttack ("Chuck Rock",3, gameController.AttackSpecialEffects[0]));
		defaultActions.Add (new StatusEffectAttack ("Sharpshoot", 1, gameController.AttackSpecialEffects[0]));
		defaultActions.Add (new ArrowFlurry ("Arrow Flurry",5, gameController.AttackSpecialEffects[0]));
		return defaultActions;
	}

	//Initializes type advantages for ranger (weapons triangle).  Rangers are strong against magicians and weak to warriors
	public override void InitializeClassBonusDamage(){
		ClassEffectiveness.Add ("Ranger", 1);
		ClassEffectiveness.Add ("Magician", 2);
		ClassEffectiveness.Add ("Warrior", .5);
	}
}
