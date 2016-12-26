using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	private static Text diceLabel;
	GameObject selectedStone;


	// Use this for initialization
	void Start () {
		diceLabel = returnLabelWithTag ("diceLabel");





	//setDiceLabel ("Method works!");
	
	}
	
	// Update is called once per frame
	void Update () {
		
		selectStone();
		if (selectedStone == null) {
			setDiceLabel ("no selected stone");
		}
		else{
			setDiceLabel (selectedStone.tag);
		}
	}

	public void setDiceLabel(string str){
	diceLabel.text = str;


	}

	// player controller 

	void selectStone(){
	//onnly if player1s turn
	
		//Color32 sColor = new Color32(255,255,225,100);//selected color
		//Color32 nColor = new Color32(255,255,225,255);//normal color

		if (Input.touchCount > 0) {
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint ((Input.GetTouch (0).position)), Vector2.zero);
		
			if (hit.collider == null) {
				Debug.Log ("line: 52");
				selectedStone = null;
		} 	else{// if an object is touched
				Debug.Log ("line: 55");
			  if (hit.collider.tag.Contains ("black")) {
					Debug.Log ("line: 57");
				selectedStone = hit.transform.gameObject;
		
				} else if (selectedStone != null && hit.collider.tag.Contains ("A")) {
					Debug.Log ("line: 61");
					Debug.Log (hit.transform.gameObject.tag+" "+hit.transform.gameObject.transform.position);
					Debug.Log ("selectedStone"+selectedStone.transform.position);
				
					selectedStone.transform.position = hit.transform.gameObject.transform.position;
					//	Debug.Log ("heeeeej" + selectedStone.transform.position.Set());
				

			}
			

			}


		



		}
	
	}





	void moveStone(){
		RaycastHit2D hit  = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);

		if (hit.collider.tag.Contains ("A") && selectedStone != null) {
			selectedStone.transform.position = hit.transform.position;
			Debug.Log ("selectedStone: "+selectedStone.transform.position+" Field: "+hit.collider.tag +" "+hit.transform.position );
		}
	
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
