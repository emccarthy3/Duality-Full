using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * State used to define behavior if a battler is not attacking or blocking
 * Written by: Betsey McCarthy
 */
public class AttackableState : State {

	//Constructor for Attackable state.  Will add battler to attackable list if not already added and make enemy attack buttons visible if battler is an enemy
	public AttackableState(UIController ui, Battle battle ,Character battler): base(ui, battle, battler){
		if (battler.GetType ().Name == "Enemy" && !battle.AttackableEnemies.Contains(battler)) {
		ui.ChangeEnemyButtonVisibility (battler.Name, true);
		battle.AttackableEnemies.Add (battler);
		} else if ((battler.Name == "Player" || battler.Name == "Partner") && !battle.AttackablePlayers.Contains(battler)) {
			battle.AttackablePlayers.Add (battler);
		}
	}
}
