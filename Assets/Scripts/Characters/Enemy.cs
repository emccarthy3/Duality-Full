using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*defines Enemy based on personality type for choosing class type
 * Written by: Betsey McCarthy
 * 
 */
public class Enemy : Character{
	private List<Action> enemyActions;

	//Constructor for defining enemy
	public Enemy(ClassType type, Sprite sprite){
		HP = 10;
		Name = "Enemy ";
		Type = type;
		PlayerSprite = sprite;
	}
	//property for which moves the enemy has.  Used to make the enemy do automated attacks
	public List<Action> EnemyActions {
		get{return enemyActions;}
		set{ enemyActions = value; }
	}
}