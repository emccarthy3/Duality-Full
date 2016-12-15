using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Script for the final scene of the game. Written by: Betsey McCarthy 
 */
public class EndScreen : MonoBehaviour {

	public void ToStartScene(){
		SceneManager.LoadScene ("StartScene");
	}
}
