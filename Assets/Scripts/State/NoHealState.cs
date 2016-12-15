using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Defines state for when battler can't heal (either out of heals or has max hp)
 * Written by: Betsey McCarthy
 */
public class NoHealState : HealState {
	private Battle battle;
	private UIController ui;
	private Character battler;

	//Constructor for no heal state, sets private instance variables to parameters
	public NoHealState(UIController ui, Battle battle ,Character battler): base(ui, battle, battler){
		this.battle = battle;
		this.ui = ui;
		this.battler = battler;
	}

	//if a battler tries to heal in no heal state, ui will respond by not letting the player heal and displaying an appropriate message
	public override void Heal(int maxHP, int healAmount){
		battle.StartCoroutine(ui.UpdateHealStatus (battler.Name, 0, false, battler.HealCount));
	}
}
