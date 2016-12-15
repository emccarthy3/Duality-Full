using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Engine code for creating a rhythm game
 * Written by: Betsey McCarthy
 */
public abstract class AbstractRhythmGame : MonoBehaviour {
	private int score;

	// Use this for initialization of the rhythm game (how many notes, where to place the notes, etc.)
	public abstract void Start ();
	
	// Update is called once per frame. Starts coroutine for creating notes if not already created in our implementation
	public abstract void Update ();

	//this method is used to generate the notes when the rhythm game has started
	public abstract IEnumerator MakeNotes();

	//triggers rhythm game ui and creates notes. 
	public abstract void StartRhythmGame();

	//this is the score the user gets based on how many times they hit the notes successfully. This is used to calculate team attack damage
	public int Score {
		get{return score;}
		set{ score = value; }
	}
}
