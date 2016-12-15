using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
 * Defines the Partner Character.
 * Written by: Betsey McCarthy
 */
public class Ally : Character{

	//creates the partner character and passes personality type
	public Ally(ClassType type){
		HP = 10;
		Type = type;
		Name = "Partner";
	}

}
