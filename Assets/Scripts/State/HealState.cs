using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Heal State defines abstract behavior for heal states (heal method)
 * Written by: Betsey McCarthy
 */
public abstract class HealState : State {

	//HealState constructor same as State constructor
	public HealState(UIController ui, Battle battle ,Character battler): base(ui, battle, battler){
		
	}
	//Heal is to be implemented by heal state classes
	public abstract void Heal (int maxHP, int healAmount);
}
