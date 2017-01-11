using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {
	private static Text diceLabel;
	private static Text currentPLabel;
	GameObject selectedStone;
	GameManager gm;
	//GameObject[] whites = new GameObject[5];
	Vector3[] stonePositions = new Vector3[5];




	// Use this for initialization




	void Start () {
		gm = new GameManager();
		diceLabel = returnLabelWithTag ("diceLabel");
		currentPLabel = returnLabelWithTag ("currentPlayer");
	
	/*	for (int i = 1; i < 6; i++) {
	
			whites[i-1] = GameObject.FindGameObjectWithTag ("white"+i);
		
		}


		for (int i = 0; i < 5; i++) {
			Debug.Log (whites[i].tag+" - "+whites[i].transform.position);
		}*/
		initStonePositions ();
		Debug.Log (stonePositions [0]);
		setCurrentPlayerLabel(gm.getCurrentPlayer().name );
			
	}
	
	// Update is called once per frame
	public void Update () {
		

		if (Input.touchCount > 0) {

		selectStone ();
	selectedStoneStatus ();
		}

	

	}

	public void setDiceLabel(string str){
	diceLabel.text = str;


	}
	public void setCurrentPlayerLabel(string str){
		currentPLabel.text = str;


	}

	//hits = Physics2D.GetRayIntersectionAll(Camera.main.ScreenPointToRay(Input.mousePosition),100);
	// player controller 

	void selectStone(){
		//onnly if player1s turn
		//RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint ((Input.GetTouch (0).position)), Vector2.zero);
		RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll (Camera.main.ScreenPointToRay ((Input.GetTouch (0).position)), 100);
		RaycastHit2D hit;



		if (hits.Length == 0) {//if no objects touched
			highlightStoneOFF (selectedStone);
			selectedStone = null;
		}
		if (hits.Length == 1) {//if hit a field OR a stone
			hit = hits[0];

			if (hit.collider.tag.Contains (gm.getCurrentPlayer ().color)) {

				highlightStoneOFF (selectedStone);
				selectedStone = hit.transform.gameObject;
				highlightStone (selectedStone);



			} else if (selectedStone != null && hit.collider.tag.Length == 2 && Input.GetTouch (0).phase == TouchPhase.Ended) {//if a stone i selected and a field touched
				Debug.Log (hit.collider.tag);
				//Collider[] hitColliders = Physics.OverlapSphere (hit.collider.gameObject.transform.position, 1);
				//Debug.Log (hitColliders.Length);
				moveStone (hit.collider.gameObject);



				//gm.printTest ();

				//	Debug.Log ("heeeeej" + selectedStone.transform.position.Set());
				//gm.printTest ();

			}


			 
		}else if(hits.Length == 2){//if hit a field AND a stone
			RaycastHit2D stone = hits[0];
			RaycastHit2D field = hits[1];
			Debug.Log ("l103 stone:"+stone.collider.tag+" field"+field.collider.tag);
			if (selectedStone!=null && stone.collider.tag.Contains (getEnemyColor (gm.getCurrentPlayer ().color))) {//if there is an enemy stone on the field
		//		stone.transform.position = white1.transform.position;

				killStone (stone.transform.gameObject);
				moveStone (field.collider.gameObject);
				//		moveStone (field.collider.gameObject);
			
			
			
			} else if (stone.collider.tag.Contains (gm.getCurrentPlayer ().color)) {//if there is one of my stones on the field
			
				Debug.Log ("l 109 color: "+gm.getCurrentPlayer ().color);
				highlightStoneOFF (selectedStone);
				selectedStone = stone.transform.gameObject;
				highlightStone (selectedStone);
			}


		}






	
	}

	void highlightStone(GameObject stone){
		if (stone != null) {
Behaviour halo = (Behaviour)stone.GetComponent ("Halo");
halo.enabled = true;

		}
	}
	void highlightStoneOFF(GameObject stone){
		if (stone != null) {
			Behaviour halo = (Behaviour)stone.GetComponent ("Halo");
			halo.enabled = false;
			
		}
	}

	string returnFieldOfStone(Vector3 stonePosition){//delete
		RaycastHit2D hit  = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((stonePosition)), Vector2.zero);
		return hit.collider.tag;

	}



	void moveStone(GameObject moveTo){

			Debug.Log("MOVESTONE "+ moveTo.tag +moveTo.transform.position);
		selectedStone.transform.position = moveTo.transform.position;
		highlightStoneOFF(selectedStone);
		selectedStone = null;
		gm.turnEnded ();
		setCurrentPlayerLabel(gm.getCurrentPlayer().name );

	}



	string getEnemyColor(string currentPlayerColor){

		if (currentPlayerColor.Equals ("white")) {
			return "black";
		} else if (currentPlayerColor.Equals ("black")) {
		
			return "white";
		} else {
			return null;
		}


	}
	void selectedStoneStatus(){//delete me
	

	
		if (selectedStone == null) {
			setDiceLabel ("no selected stone");
		}
		else{
			setDiceLabel (selectedStone.tag);
		}
	}

	void killStone(GameObject killedSton){
		
	

			
		if (killedSton.tag.Contains("black")) {//if black stone i skilled

			for (int i = 0; i < 5; i++) {
				
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (stonePositions [i]), Vector2.zero);
				if (hit.collider == null) {
					Vector3 temp = stonePositions [i];
					temp.x = stonePositions [i].x * (-1.0F);
					killedSton.transform.position = temp;
				}
			}

			} else {//if white stone i skilled
			for (int i = 0; i < 5; i++) {

				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (stonePositions [i]), Vector2.zero);
				if (hit.collider == null) {
					killedSton.transform.position = stonePositions [i];
				}
			}


			
			}
		
		

		/*for (int i = 0; i < 5; i++) {
				Vector3 temp = stonePositions [i];
				temp.x = stonePositions [i].x * (-1.0F);
				whites [i].transform.position = temp;
			}*/
}

	void initStonePositions(){
	
		stonePositions [0] = new Vector3 (2.2F, -3.9F, 90.0F);
		stonePositions [1] = new Vector3 (2.2F, -2.6F, 90.0F);
		stonePositions [2] = new Vector3 (2.2F, -3.2F, 90.0F);
		stonePositions [3] = new Vector3 (2.2F, -1.4F, 90.0F);
		stonePositions [4] = new Vector3 (2.2F, -2.0F, 90.0F);
	
	
	
	
	}

	Text returnLabelWithTag(string tag){

		foreach (Text textElement in GameObject.FindGameObjectWithTag ("Canvas").GetComponentsInChildren<Text>()) {
			if (tag.Equals(textElement.tag)) {
				return textElement;
			}
		}
		return null;

	}



}
