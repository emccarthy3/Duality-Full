using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Mindboggle is a move unique to magicians gained in the 3rd battle
 * Written by: Betsey McCarthy
 */
public class MindBoggle : Action {

	//Same constructor as action
	public MindBoggle(string name, int baseDamage,ParticleSystem particleSystem) : base(name,  baseDamage,  particleSystem){

	}

	//Mind boggle only has a 50% chance of hitting, but has base damage of 3 and does 4 effect damage
	public override void ActionBehavior ()
	{
		BaseDamage = 3;
		EffectDamage = 4;
		float rand = Random.Range (0f, 1f);
		if (rand < .5) {
			BaseDamage = 0;
			EffectDamage = 0;
		}
	}
}
