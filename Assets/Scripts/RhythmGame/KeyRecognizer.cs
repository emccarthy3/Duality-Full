using UnityEngine;
using System.Collections;
/*
 * Used to detect key presses in team attack.  
 * Written by: Aneesha Smith
 */
public class KeyRecognizer : MonoBehaviour {

	public KeyCode press;
	public Color highlightColor = Color.cyan;

	// Update is called once per frame
	void Update () {

		// turns on the trigger when you press the corresponding key, turns it off when you pull up 
		if (Input.GetKeyDown (press)) {
			(gameObject.GetComponent(typeof(Collider2D)) as Collider2D).isTrigger = true;
			SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
			if (sprite != null) {
				sprite.color = highlightColor;
			}

		}
		if (Input.GetKeyUp (press)) {
			(gameObject.GetComponent(typeof(Collider2D)) as Collider2D).isTrigger = false;
			SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
			if (sprite != null) {
				sprite.color = Color.white;
			}
		}

	}

}
