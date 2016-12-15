using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Used as the super class for dialogue class (engine code)
 * Written by Betsey McCarthy
 */

public abstract class AbstractDialogue : MonoBehaviour {

	// Use this for initialization
	public abstract void Start ();

	// Update is called once per frame
	public abstract void Update ();

	//override to create custom paths for the dialogue tree
	public abstract void InitializeDialoguePaths ();

	//this method switches the dialogue after a response has been selected and maps the answers (and the next dialogue) to the buttons
	public abstract void SetNextDialogue(Dialogue dialogue);

}