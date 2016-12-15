using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * Help menu is used to assist players in the battle scene with info on how battles function
 * Written by: Betsey McCarthy
 */
public class HelpMenu : MonoBehaviour {
	[SerializeField] private Button weaponsTriangle;
	[SerializeField] private Button moves;
	[SerializeField] private Button back;
	[SerializeField] private Button rp;
	[SerializeField] private Button teamAttack;
	[SerializeField] private Button dialogue;
	[SerializeField] private Button healButton;
	[SerializeField] private Text descriptionText;

	// sets the back button inactive and the description text inactive on start
	void Start () {
		back.gameObject.SetActive (false);
		descriptionText.gameObject.SetActive (false);
	}

	//makes help menu popup
	public void Open(){
		gameObject.SetActive (true);
	}

	//makes help menu close
	public void Close(){
		gameObject.SetActive (false);
	}

	//Calls this method when a help topic is clicked to hide the rest of the buttons to show the description of the help topic. Back button makes all the buttons visible again
	public void ChangeButtonVisibility(bool enable){
		weaponsTriangle.gameObject.SetActive (enable);
		moves.gameObject.SetActive (enable);
		rp.gameObject.SetActive (enable);
		teamAttack.gameObject.SetActive (enable);
		dialogue.gameObject.SetActive (enable);
		healButton.gameObject.SetActive (enable);
		back.gameObject.SetActive (!enable);
		descriptionText.gameObject.SetActive (!enable);
	}

	//Makes buttons visible after reading help topic
	public void Back(){
		ChangeButtonVisibility (true);
	}

	//Diplays info on the weapons triangle
	public void ShowWeaponsTriangle(){
		ChangeButtonVisibility (false);
		descriptionText.text = "The Weapons triangle determines any bonus damage dealt to the opponent when attacking.  When the attacking class has an advantage " +
		"the attack will deal x 2 damage.  Warriors are strong against rangers, rangers are strong against magicians, and magicians are strong against warriors." +
		"If the attacking character attacks someone who has an advantage against them, they will only deal .5 x damage, so strategize accordingly!";
	}

	//Diplays info on the weapons triangle
	public void Moves(){
		ChangeButtonVisibility (false);
		descriptionText.text = "Attack 1: Does 1 base damage (more damage depending on battle and class type advantage (see: weapons triangle)).  Attack 2: Only has 50% chance of hitting but does 3 base damage. Attack 3:(earned in 2nd battle) 80% chance of hitting but deals effect damage, which decrements target's hp each turn. Attack 4: Its a suprise! Changes depending on class type";
	}
	//Diplays info on RP
	public void RP(){
		ChangeButtonVisibility (false);
		descriptionText.text = "RP is dependent on your relationship with your partner.  If you had a good conversation with your partner, this value will be higher (Max value is 10).  Having a higher relationship will allow you to execute a more successful team move";
	}
	//Diplays info on team attacks
	public void TeamAttack(){
		ChangeButtonVisibility (false);
		descriptionText.text = "In order to successfully do a Team Attack, you will have to hold down the proper arrow keys as the orbs fall (orbs are destroyed at the top of the arrows, so hold down key before the orbs reaches this point). Remember, the higher your RP, the easier it will be to hit the orbs and do more damage.";
	}
	//Diplays info on dialogues
	public void Dialogue(){
		ChangeButtonVisibility (false);
		descriptionText.text = "The dialogue you just had with your partner determined your relationship points.  If you pick answers your partner agrees with, your relationship will increase allowing team attacks to be more useful";
	}
	//Diplays info on healing/blocking/encouraging
	public void Heal(){
		ChangeButtonVisibility (false);
		descriptionText.text = "Healing: will heal 2 Hp + 1(depending on the battle). Battle 1 only allows 3 heals, 2 only allows 2 and the last battle only allows 1 heal.  Blocking: prevents your player from being attacked for one turn. Encourage: will increase your RP by 1 (easier team attacks)";
	}
}
