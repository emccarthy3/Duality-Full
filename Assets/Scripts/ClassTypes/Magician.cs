using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
 * Defines the magician classtype
 * Written by: Betsey McCarthy
 */
public class Magician : ClassType {
	private GameObject gc;
	private GameController gameController;

	//Constructor for magician, sets default actions
	public Magician(){
		ClassName = "Magician";
		gc = GameObject.Find ("GameController");
		gameController= gc.GetComponent <GameController> ();
		Actions = DefaultActions();
	}

	//default actions defines the specific moves for magicians
	public List<Action> DefaultActions(){
		List<Action> defaultActions = new List<Action>();
		defaultActions.Add (new SingleAttack("Fire bolt", 1,gameController.AttackSpecialEffects[0]));
		defaultActions.Add (new StrongAttack ("Earthquake",3, gameController.AttackSpecialEffects[1]));
		defaultActions.Add (new StatusEffectAttack ("Water wave", 1, gameController.AttackSpecialEffects[0]));
		defaultActions.Add (new MindBoggle("Mind Boggle",5, gameController.AttackSpecialEffects[0]));
		return defaultActions;
	}

	//class bonus damage defines type effectiveness for magicians.  Magicians are weak to rangers but strong against warriors
	public override void InitializeClassBonusDamage(){
		ClassEffectiveness.Add ("Ranger", .5);
		ClassEffectiveness.Add ("Magician", 1);
		ClassEffectiveness.Add ("Warrior", 2);
	}
}
