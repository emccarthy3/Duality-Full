using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Story Scene loads the quiz scene when the user is done reading the story
 * Written by: Evan Elkin
 */
public class StoryScene : MonoBehaviour {

	//switches to quiz scene
	public void SwitchScenes(){
		SceneManager.LoadScene ("Quiz");
	}
}
