using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*
 * Popup for when a battle is finished, either by your player being defeated or both enemies being defeated.
 * Written by: Betsey McCarthy
 */
public class BattleFinishedPopup : MonoBehaviour {
	[SerializeField] private Text text;
	[SerializeField] private Text buttonText;

	//sets text on menu depending if the player was defeated or if the enemies were defeated
	public void SetStatusText(string text, string buttonText){
		this.text.text = text;
		this.buttonText.text = buttonText;
	}
	//opens menu
	public void Open(){
		gameObject.SetActive (true);

	}
	//closes menu
	public void Close(){
		gameObject.SetActive (false);
	}
}
