using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager {
	private static Text diceLabel;
	GameObject selectedStone;
	//GameManager gm;

	// Use this for initialization
	void Start () {
		//gm = new GameManager();
		diceLabel = returnLabelWithTag ("diceLabel");

		//gm.printTest ();
	//setDiceLabel ("Method works!");
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0) {
			selectStone ();
			selectedStoneStatus ();
		}


	}

	public void setDiceLabel(string str){
	diceLabel.text = str;


	}

	// player controller 

	void selectStone(){
	//onnly if player1s turn

			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint ((Input.GetTouch (0).position)), Vector2.zero);
		
			if (hit.collider == null) {//if no object is touched
			
				selectedStone = null;
		} 	else{// if an object is touched
			
			  if (hit.collider.tag.Contains ("black")) {//change black to currentPlayer.stoneColor

				selectedStone = hit.transform.gameObject;
		
				} else if (selectedStone != null && hit.collider.tag.Length==2) {//if a stone i selected and a field touched
					 

				moveStone (hit.collider.gameObject);


					//gm.printTest ();

					//	Debug.Log ("heeeeej" + selectedStone.transform.position.Set());
					//gm.printTest ();

			}
			

			}


		



	
	
	}


	string returnFieldOfStone(Vector3 stonePosition){
		RaycastHit2D hit  = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((stonePosition)), Vector2.zero);
		return hit.collider.tag;

	}



	void moveStone(GameObject moveTo){
		selectedStone.transform.position = moveTo.transform.position;
		//gm.p1StoneLanded(moveTo.tag);
	
	}




	void selectedStoneStatus(){//delete me
	

	
		if (selectedStone == null) {
			setDiceLabel ("no selected stone");
		}
		else{
			setDiceLabel (selectedStone.tag);
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
