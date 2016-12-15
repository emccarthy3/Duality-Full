using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Arrow flurry is an action unique to the ranger, earned in the 3rd battle. 
 * Written by: Betsey McCarthy
 */
public class ArrowFlurry : Action {

	//same constructor as superclass action
	public ArrowFlurry(string name, int baseDamage,ParticleSystem particleSystem) : base(name,  baseDamage,  particleSystem){

	}

	//Arrow flurry has a base damage of 5 and does effect damage of 2 if it hits (80% chance)
	public override void ActionBehavior ()
	{
		BaseDamage = 5;
		EffectDamage = 2;
		float rand = Random.Range (0f, 1f);
		if (rand < .2) {
			BaseDamage = 0;
			EffectDamage = 0;
		}
	}
}
