using UnityEngine;
using System.Collections;

/*
 * Defines a concrete Action (single attack)
 * Written by: Betsey McCarthy
 */
public class SingleAttack : Action{

	//same constructor as action
	public SingleAttack(string name, int baseDamage,ParticleSystem particleSystem) : base(name,  baseDamage,  particleSystem){
	}

	public override void ActionBehavior ()
	{
		//no additional behavior for singleAttack
	}


}
