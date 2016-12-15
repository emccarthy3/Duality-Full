using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

//this class is used to save character data between scene switches.  An object called GameController with this script attached is in every scene. Written by Betsey McCarthy.
public class GameController : MonoBehaviour {
	private Player yourPlayer;
	private Ally yourPartner;
	private int battleLoop;
	[SerializeField] private List<Sprite> sprites;
	[SerializeField] private List<Sprite> backgrounds;
	[SerializeField] private List<ParticleSystem> attackSpecialEffects;

	// Use this for initialization
	void Start () {
		//ensures the object's data is not erased between scenes
		DontDestroyOnLoad (this);
		battleLoop = 0;
	}

	// Saves the character data for the player's character
	public Player YourPlayer{
		get{ return yourPlayer; }
		set{ yourPlayer = value; }
	}

	// Saves the character data for the ally character
	public Ally YourPartner{
		get{ return yourPartner; }
		set{ yourPartner = value; }
	}

	// In charge of scene management.
	public void SwitchScene (string nextScene)
	{
		SceneManager.LoadScene(nextScene);
	}

	// Saves the sprites for all the characters
	public List<Sprite> Sprites{
		get{ return sprites; }
		set{ sprites = value; }
	}

	// Saves the backgrounds for all of the levels
	public List<Sprite> Backgrounds{
		get{ return backgrounds; }
		set{ backgrounds = value; }
	}

	//  Keeps track of where the player is in the game. Used for flow of game from quiz->dialogue->battle, etc.
	public int BattleLoop{
		get{ return battleLoop; }
		set{ battleLoop = value; }
	}

	// Can be implemented for special effects in battle (particle systems)
	public List<ParticleSystem> AttackSpecialEffects{
		get { return attackSpecialEffects; }
		set { attackSpecialEffects = value; } 
	}

}
