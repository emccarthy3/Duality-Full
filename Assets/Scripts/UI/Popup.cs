using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Used to open and close generic menus
 * Written by: Betsey McCarthy
 */
public class Popup : MonoBehaviour {

	//opens the menu
	public void Open(){
		gameObject.SetActive (true);
	}

	//closes the menu
	public void Close(){
		gameObject.SetActive (false);
	}
}
