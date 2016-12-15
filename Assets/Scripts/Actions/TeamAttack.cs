using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
 * Allows team attacks to be created. Implementation in Rhythm Controller and UIController
 * Written by: Betsey McCarthy
 */
public class TeamAttack : Action {

	//same constructor as action
	public TeamAttack(string name, int baseDamage,ParticleSystem particleSystem) : base(name,  baseDamage,  particleSystem){
	}

	//action behavior determined in rhythm controller
	public override void ActionBehavior (){
	}

}
