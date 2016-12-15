using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * State used in the battle to define a player not defeated (used in initialization to add players to attackable lists)
 * Written by: Betsey McCarthy
 */
public class AliveState : State {

	//Constructor for Alive state.  Adds players to attackable lists depending on type (enemy or member of your team)
	public AliveState(UIController ui, Battle battle ,Character battler): base(ui, battle, battler){
		if (battler.GetType ().Name == "Enemy") {
			battle.AttackableEnemies.Add (battler);
		} else {
			battle.AttackablePlayers.Add (battler);
			battle.YourTeam.Add (battler);
		}
	}
}
