using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Strong attacks will do 3 base damage, but only hit 50% of the time.  Second move in first battle
 * Written by: Betsey McCarthy
 */
public class StrongAttack : Action {

	//same constructor as action
	public StrongAttack(string name, int baseDamage,ParticleSystem particleSystem) : base(name,  baseDamage,  particleSystem){
	}

	//Base damage of 3, but only hits 50% of the time.
	public override void ActionBehavior ()
	{
		BaseDamage = 3;
		float rand = Random.Range (0f, 1f);
		if (rand < .5) {
			BaseDamage = 0;
		}
	}
}
