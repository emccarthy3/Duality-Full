using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/*
 * Concrete RhythmGame
 * Written by: Aneesha Smith (logic) & Betsey McCarthy (refactoring)
 */
public class RhythmController : AbstractRhythmGame { 
	private const int LEFT = 1;
	private const int RIGHT = 2;
	private const int UP = 3;
	private const int DOWN = 4;
	private const float YPOS = 6.0f;
	private const float ZPOS = -1f;
	private const float NOTE_CREATE_DELAY = .5f;
	private const float LEFT_POS = .6f;
	private const float RIGHT_POS = 1.8f;
	private const float UP_POS = -2.2f;
	private const float DOWN_POS = -0.7f;
	private const float GAME_END_DELAY = 1.5f;
	private Dictionary<int, float> notePositions;
	List<int> lrud  = new List<int> {LEFT, RIGHT, UP, DOWN, DOWN, UP, LEFT, RIGHT, UP, DOWN};
	private int whichDir = 0;
	public Transform note; 
	private GameObject rhythmBackground;
	[SerializeField] private UIController uiController;
	// when the coroutine has begun
	private string hasBegun = "y";
	// location of the note on the background 
	private float xPos;

	//initializes note positions Written by: Aneesha Smith
	public override void Start () {
		rhythmBackground = GameObject.Find ("rhythmBackground");
		rhythmBackground.gameObject.SetActive (false);
		notePositions = new Dictionary<int, float>();
		notePositions.Add (LEFT, LEFT_POS);
		notePositions.Add (RIGHT, RIGHT_POS);
		notePositions.Add (UP, UP_POS);
		notePositions.Add (DOWN, DOWN_POS);
	}

	// starts coroutine for making new notes. Written by: Aneesha Smith
	public override void Update () {
		if (hasBegun == "n") {
			StartCoroutine (MakeNotes ());
			hasBegun = "y";
		}
	}

	// instantiates notes in the correct position on the background. Written by: Aneesha Smith, refactored by Betsey McCarthy
	public override IEnumerator MakeNotes() {
		// wait half a second before making a new one; 
		yield return new WaitForSeconds (NOTE_CREATE_DELAY);
		xPos = notePositions[Random.Range(LEFT,DOWN)];
		whichDir += 1;
		if (whichDir >= lrud.Count) {
			yield return new WaitForSeconds (GAME_END_DELAY);
			rhythmBackground.gameObject.SetActive (false);
			GameObject uic = GameObject.Find ("UIController");
			UIController uiController = uic.GetComponent <UIController> ();
			uiController.teamAttackisFinished (Score/2);
			uiController.ChangeCanvasState (true);
			whichDir = 0;
			Score = 0;
		}
		else{
		hasBegun = "n";	
		Instantiate (note, new Vector3(xPos, YPOS, ZPOS), note.rotation); 
		}
	}

	//this is called once the team attack button enemy choice is selected.  Starts up rhythm game. Written by: Aneesha Smith
	public override void StartRhythmGame() {
		hasBegun = "n";
		rhythmBackground.gameObject.SetActive (true);
	}


}

