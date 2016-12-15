using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Dialogue class that holds the actual dialogue. Written by Evan Elkin and Betsey McCarthy. 
*/
public class Dialogue {

	private string dialogueString;
	private Dictionary<string, Dialogue> dialogueDictionary = new Dictionary<string, Dialogue> ();

	/*
	 * Constructor for the dialogue object. 
	 */
	public Dialogue (string dialogueString) {
		this.dialogueString = dialogueString;
	}

	/*
	 * Property for the string of dialogue. 
	 */
	public string DialogueString {
		get{ return dialogueString; }
		set{ dialogueString = value; }
	}

	/*
	 * Property for the dialogue dictionary. 
	 */
	public Dictionary<string, Dialogue> DialogueDictionary {
		get{ return dialogueDictionary; }
		set{ dialogueDictionary = value; }
	}


}