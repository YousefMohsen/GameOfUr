using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager  {
	private static Text diceLabel;
	private static Text currentPLabel;
	GameObject selectedStone;
	GameObject canvas;
	Camera camera;


	// Use this for initialization



	public UIManager(GameObject gamObj,Camera cam){
		canvas = gamObj;
		camera = cam;
		Start ();
	}
	void Start () {
	//	gm = new GameManager();
		diceLabel = returnLabelWithTag ("diceLabel");
		currentPLabel = returnLabelWithTag ("currentPlayer");
	

		//gm.printTest ();
	//setDiceLabel ("Method works!");
	
	}
	
	// Update is called once per frame
	public void Update () {
		

		if (Input.touchCount > 0) {

		selectStone ();
	selectedStoneStatus ();
		}
		Debug.Log (selectedStone.name);
	

	}

	public void setDiceLabel(string str){
	diceLabel.text = str;


	}
	public void setCurrentPlayerLabel(string str){
		currentPLabel.text = str;


	}

	// player controller 

	void selectStone(){
	//onnly if player1s turn


		RaycastHit2D hit = Physics2D.Raycast (camera.ScreenToWorldPoint ((Input.GetTouch (0).position)), Vector2.zero);
		
			if (hit.collider == null) {//if no object is touched
			highlightStoneOFF(selectedStone);
				selectedStone = null;
		} 	else{// if an object is touched
			
			if (hit.collider.tag.Contains ("black") ) {//change black to currentPlayer.stoneColor
				highlightStoneOFF(selectedStone);
				selectedStone = hit.transform.gameObject;
				highlightStone(selectedStone);
			

		
			} else if (selectedStone != null && hit.collider.tag.Length==2 && Input.GetTouch (0).phase == TouchPhase.Ended) {//if a stone i selected and a field touched
					 
				moveStone (hit.collider.gameObject);
				highlightStoneOFF(selectedStone);
				selectedStone = null;
			

					//gm.printTest ();

					//	Debug.Log ("heeeeej" + selectedStone.transform.position.Set());
					//gm.printTest ();

			}
			

			}


		



	
	
	}

	void highlightStone(GameObject stone){
		if (stone != null) {
Behaviour halo = (Behaviour)stone.GetComponent ("Halo");
halo.enabled = true;
			Debug.Log(stone.name +" highlighted");
		}
	}
	void highlightStoneOFF(GameObject stone){
		if (stone != null) {
			Behaviour halo = (Behaviour)stone.GetComponent ("Halo");
			halo.enabled = false;
			Debug.Log ("l 112");
		}
	}

	string returnFieldOfStone(Vector3 stonePosition){//delete
		RaycastHit2D hit  = Physics2D.Raycast(camera.ScreenToWorldPoint((stonePosition)), Vector2.zero);
		return hit.collider.tag;

	}



	void moveStone(GameObject moveTo){
		selectedStone.transform.position = moveTo.transform.position;
	
	
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

		foreach (Text textElement in canvas.GetComponentsInChildren<Text>()) {
			if (tag.Equals(textElement.tag)) {
				return textElement;
			}
		}
		return null;

	}



}
