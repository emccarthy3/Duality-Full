using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Engine Code for making a Character
 * Written by: Betsey McCarthy
 */
public class Character{
	private const int STARTING_HP = 10;
	private double hp;
	private int rp;
	private string name;
	private int personalityType;
	private int healCount;
	private ClassType type;
	private Character nextPlayer;
	private Dictionary<int, ClassType> classTypesToPersonality;
	private Sprite playerSprite;
	private bool hasEffectDamage = false;
	private State isBlockingState;
	private HealState isAbleToHealState;
	private State lifeState;
	private int effectDamage;

	//the classtype of the battler (either warrior, mage, or ranger)
	public ClassType Type {
		get{ return type; }
		set{ type = value; }
	}

	//property for health points of characters.  Health points increase for the player and the ally during level ups and increase for enemies in between battles
	public double HP {
		get{return hp;}
		set{ hp = value; }
	}

	public string Name {
		get{ return name; }
		set{ name = value; }
	}
	//applicable to player characters.  Defines relationship score between player and the ally
	public int RP {
		get{ return rp; }
		set{ rp = value; }
	}

	//PersonalityType determines which dialogue will occur (1 for warrior, 2 for ranger and 3 for magician
	public int PersonalityType {
		get{ return personalityType; }
		set{ personalityType = value; }
	}

	//Defines sprite of the player
	public Sprite PlayerSprite {
		get{ return playerSprite; }
		set{ playerSprite = value; }
	}

	//Defines whether or not the player has effect damage
	public bool HasEffectDamage{
		get{ return hasEffectDamage; }
		set{ hasEffectDamage = value; }
	}

	//Defines amount of effect damage the character has
	public int EffectDamage{
		get{ return effectDamage; }
		set{ effectDamage = value; }
	}

	//Defines which block state the characer is in
	public State IsBlockingState{
		get{ return isBlockingState; }
		set{ isBlockingState = value; }
	}

	//Defines whether or not the character is alive or dead
	public State LifeState{
		get{ return lifeState; }
		set{ lifeState = value; }
	}

	//Defines whether or not the character is able to heal
	public HealState IsAbleToHealState{
		get{ return isAbleToHealState; }
		set{ isAbleToHealState = value; }
	}

	//Defines the heal count of the player (starts at 3)
	public int HealCount{
		get{ return healCount; }
		set{ healCount = value; }
	}



}
