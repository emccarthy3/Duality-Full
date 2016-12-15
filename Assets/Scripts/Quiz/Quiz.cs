using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Linq;

/*
 * Quiz controller class. Written by Evan Elkin and Betsey McCarthy.
 */ 
public class Quiz : MonoBehaviour {
	private GameObject gc;
	private GameController gameController;
	[SerializeField] private Button endButton;
	[SerializeField] private Button quizArcherButton;
	[SerializeField] private Button quizFighterButton;
	[SerializeField] private Button quizMagicianButton;
	private Text question;
	private bool isFinished;
	private Dictionary<string, int> buttonDictionary = new Dictionary<string, int> ();

	//Quiz questions array. i is what question the player is on.
	private int i = 0;
	private string[] questions = {"People would say that I’m the life of the party!", 
		"If I saw a bank robbery, I would chase after the robbers and help bring them to justice.", 
		"I prefer to go out to a party or bar than stay in on a Saturday night.", 
		"I love venturing out into the great outdoors!", 
		"I have many friends from all over rather than one small, tight-knit group of close friends.", 
		"The end goal in life is to be successful, not to be happy.", 
		"I’m known as the thrill-seeker amongst my friends.", 
		"I would not consider myself to be religious or spiritual.", 
		"I get by with a little help from my friends.", 
		"People would say that I’m a stubborn individual.", 
		"I don’t care if hurt somebody’s feelings… if they’re wrong, I’m going to call them out for it.",
		"I’m not really a day-dreamer, I’m much more down to earth.", 
		"I would rather be in business and make lots of money than be an artist.",
		"My best friend just cheated off of my test and got an A… I can’t risk them getting suspended, so I guess I’ll pretend I didn’t know.",
		"You can probably find me playing a game of chess rather than watching."
	};

	// Use this for initialization of buttons and quiz question text.
	void Start() {
		buttonDictionary.Add ("quizArcherButton", 0);
		buttonDictionary.Add ("quizFighterButton", 0);
		buttonDictionary.Add ("quizMagicianButton", 0);
		gc = GameObject.Find ("GameController");
		gameController= gc.GetComponent <GameController> ();
		quizArcherButton.onClick.AddListener(() =>  {buttonDictionary["quizArcherButton"]++;i++;
			question.text = questions [i];});
		quizFighterButton.onClick.AddListener(() =>  {buttonDictionary["quizFighterButton"]++;i++;
			question.text = questions [i];});
		quizMagicianButton.onClick.AddListener(() =>  {buttonDictionary["quizMagicianButton"]++;i++;
			question.text = questions [i];});
		endButton.gameObject.SetActive (false);
		isFinished = false;
		//loads the question to the panel
		GameObject textObject = GameObject.Find ("QuizQuestion");
		question = textObject.GetComponent<Text> ();
		endButton.onClick.AddListener(() =>  gameController.SwitchScene("Dialogue1"));
		question.text = questions [i]; 
	}

	// Update is called once per frame. Checks to see if player has gone through quiz. If they have, computes scores and assigns player a character class and ally.
	void Update () {
		//if the quiz has gone through all of the questions in the questions array
		if (i == questions.Length) {
			// max is the max value in the dictionary.  Source : http://stackoverflow.com/questions/2805703/good-way-to-get-the-key-of-the-highest-value-of-a-dictionary-in-c-sharp
			string max = buttonDictionary.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
			if (max == "quizFighterButton") {
				gameController.YourPlayer = new Player(new Warrior());
				gameController.YourPartner = new Ally (new Magician ());
				question.text = "Congratulations! You are a warrior!";
				gameController.YourPlayer.PersonalityType = 1;
				gameController.YourPlayer.PlayerSprite = gameController.Sprites [0];
				gameController.YourPartner.PlayerSprite = gameController.Sprites [2];

			} else if (max == "quizArcherButton") {
				question.text = "Congratulations! You are a ranger!";
				gameController.YourPlayer= new Player(new Ranger());
				gameController.YourPartner = new Ally (new Warrior ());
				gameController.YourPlayer.PersonalityType = 2;
				gameController.YourPartner.PlayerSprite = gameController.Sprites [0];
				gameController.YourPlayer.PlayerSprite = gameController.Sprites [1];
				Debug.Log ("Your Personality is" + gameController.YourPlayer.PersonalityType);
			} else {
				question.text = "Congratulations! You are a magician!";
				gameController.YourPlayer = new Player(new Magician());
				gameController.YourPartner = new Ally (new Ranger ());
				gameController.YourPlayer.PersonalityType = 3;
				gameController.YourPartner.PlayerSprite = gameController.Sprites [1];
				gameController.YourPlayer.PlayerSprite = gameController.Sprites [2];
				Debug.Log ("Your Personality is" + gameController.YourPlayer.PersonalityType);
			}
			quizArcherButton.gameObject.SetActive (false);
			quizFighterButton.gameObject.SetActive (false);
			quizMagicianButton.gameObject.SetActive (false);
			endButton.gameObject.SetActive (true);
		}
	}

	// property for if the quiz is finished or not.
	public bool IsFinished{
		get{ return isFinished; }
		set{ isFinished = value; }
	}

}
