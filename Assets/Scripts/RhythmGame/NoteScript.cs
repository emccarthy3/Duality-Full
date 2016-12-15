using UnityEngine;
using System.Collections;
/*
 * Script for inidividual note objects
 * Written by: Aneesha Smith
 */
public class NoteScript : MonoBehaviour {

	// the total of the points
	private GameObject rc;
	private RhythmController rhythmController;
	private GameObject gc;
	private GameController gameController;

	//Initializes gravity based on RP
	void Start(){
		gc = GameObject.Find ("GameController");
		gameController= gc.GetComponent <GameController> ();
		rc = GameObject.Find ("RhythmController");
		rhythmController = rc.GetComponent<RhythmController> ();
		Debug.Log (gameController.YourPlayer.RP);
		Physics2D.gravity = new Vector3(0,-(100-gameController.YourPlayer.RP) , 0);
	}
	//Checks to see if arrow was held down when the note fell or not.  If the note was successfully hit, the score will increment by 1
	void OnTriggerEnter2D (Collider2D col) {
		// if the note hits the nozone, it is a missed note
		if (col.gameObject.tag == "fail") {
			Destroy (this.gameObject);
		}
		// if the note hits the arrow and it's trigger is on, you get the point!
		if (col.gameObject.tag == "arrow" && (col.gameObject.GetComponent(typeof(Collider2D)) as Collider2D).isTrigger == true) {
			Destroy (this.gameObject);
			rhythmController.Score += 1;
		}
	
	}


}