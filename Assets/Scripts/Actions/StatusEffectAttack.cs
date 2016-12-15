using UnityEngine;
using System.Collections;
/*
 * Status effect attacks deal damage every turn to affected players.  Used starting in the second battle 
 * Written by: Betsey McCarthy
 */
public class StatusEffectAttack : Action {

	//Same constructor as Action
	public StatusEffectAttack(string name, int baseDamage,ParticleSystem particleSystem) : base(name,  baseDamage,  particleSystem){
	}

	//80% chance of hitting, base damage of 1, will do 1 damage per turn
	public override void ActionBehavior ()
	{
		EffectDamage = 1;
		float rand = Random.Range (0f, 1f);
		if (rand < .2) {
			BaseDamage = 0;
			EffectDamage = 0;
		}

	}
}
