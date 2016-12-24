using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	private static Text diceLabel;

	// Use this for initialization
	void Start () {
		diceLabel = returnLabelWithTag ("diceLabel");
		//setDiceLabel ("Method works!");

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void setDiceLabel(string str){
		diceLabel.text = str;


	}

	Text returnLabelWithTag(string tag){

		foreach (Text textElement in GameObject.Find ("Canvas").GetComponentsInChildren<Text>()) {
			if (tag.Equals(textElement.tag)) {
				return textElement;
			}
		}
		return null;

	}



}
