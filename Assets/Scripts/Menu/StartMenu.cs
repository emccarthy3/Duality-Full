using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Displays content for the starting scene. Written by: Aneesha Smith and Evan Elkin
public class StartMenu : MonoBehaviour {
	[SerializeField] private Button startButton;

	//Initializes start button listener to start the game
	void Start () {
		startButton.onClick.AddListener(() =>  SwitchScenes());
	}

	//Loads the story scene when start button is clicked
	public void SwitchScenes(){
		SceneManager.LoadScene ("Story");
	}

}
