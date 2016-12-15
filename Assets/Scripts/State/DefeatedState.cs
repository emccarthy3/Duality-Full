using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * State for when the battler is defeated
 * Written by: Betsey McCarthy
 */
public class DefeatedState : State {

	//Constructor for defeated state.  Removes defeated players from attackable lists and is used in battle to check if player or enemy was defeated (to end the battle)
	public DefeatedState(UIController ui, Battle battle ,Character battler): base(ui, battle, battler){
		ui.RemoveFromHPList (battle.Battlers.IndexOf (battler));
		battle.Battlers.Remove (battler);
		if (battler.GetType ().Name == "Enemy") {
			ui.ChangeEnemyButtonVisibility (battler.Name, false);
			battle.AttackableEnemies.Remove (battler);
		} else {
			battle.YourTeam.Remove (battler);
			battle.AttackablePlayers.Remove (battler);
		}

	}
}
