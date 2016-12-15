using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Special move for warrior classes, unlocked on 3rd battle
 * Written by: Betsey McCarthy
 */
public class FatalBlow : Action {
	private const int MAX_HP = 14;

	//Constructor for fatal blow the same as action
	public FatalBlow(string name, int baseDamage,ParticleSystem particleSystem) : base(name,  baseDamage,  particleSystem){

	}

	//fatal blow has a 30% chance of defeating an enemy instantly. Makes for interesting gameplay strategy dependent on chance
	public override void ActionBehavior ()
	{
		BaseDamage = 0;
		float rand = Random.Range (0f, 1f);
		if (rand < .3) {
			BaseDamage = MAX_HP;
		}
	}
}
