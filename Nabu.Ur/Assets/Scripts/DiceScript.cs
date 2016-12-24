using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DiceScript : MonoBehaviour {

	public Text output;



	// Use this for initialization
	void Start () {

		output.text = "Throwed: ";
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void rollDice  (){
		
		var randomNumber= Random.Range (1, 5);
		output.text = "Throwed: "+randomNumber;


}
}