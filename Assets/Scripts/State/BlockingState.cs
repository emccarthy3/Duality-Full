using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Defines State for if battler is blocking
 * Written by: Betsey McCarthy
 */
public class BlockingState : State {

	//Constructor for BlockingState, removes battler from attackable lists while in blocking state and hides enemy attack button if battler is an enemy
	public BlockingState(UIController ui, Battle battle ,Character battler): base(ui, battle, battler){
		if (battler.GetType ().Name == "Enemy") {
			ui.ChangeEnemyButtonVisibility (battler.Name, false);
			battle.AttackableEnemies.Remove (battler);
		} else {
			battle.AttackablePlayers.Remove (battler);
		}
	}
}
