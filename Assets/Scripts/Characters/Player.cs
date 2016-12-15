using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*defines your player character.
 * Written by: Betsey McCarthy
 * 
 */
public class Player : Character{
	private int rp;
	//Constructor for creating player by passing a personality type
	public Player(ClassType type){
		HP = 10;
		RP = 5;
		Type = type;
		Name = "Player";
	}

}