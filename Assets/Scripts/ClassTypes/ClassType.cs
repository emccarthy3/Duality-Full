using UnityEngine;
using System.Collections.Generic;

/*
 * Engine code. Classtype defines the type of the character (warrior, ranger, or magician)
 * Written by: Betsey McCarthy
 */
 
public abstract class ClassType {
	private string className;
	private List<Action> actions;
	private Dictionary<string,double> classEffectiveness;

	//Constructor for classtype.  Defines dictionary for class effectiveness (weapons triangle setup)
	public ClassType(){
		classEffectiveness = new Dictionary<string, double> ();
		InitializeClassBonusDamage ();
	}
	//Name of the class (warrior, ranger, or magician)
	public string ClassName{
		get{ return className; }
		set{ className = value; }
	}

	//property for classEffectiveness dictionary
	public Dictionary<string,double> ClassEffectiveness{
		get{ return classEffectiveness; }
		set{ classEffectiveness = value; }
	}

	//the list of moves the classtype has
	public List<Action> Actions {
		get{ return actions; }
		set{ actions = value; }
	}

	//to be implemented in individual class implementations to define which classes are strong/weak against one another
	public abstract void InitializeClassBonusDamage();
}

