using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

	int turns;
	GameObject stone1;
	GameObject stone2 ;
	Text output;

	// Use this for initialization
	 void Start () {
		stone1 = GameObject.Find ("Stone1");
		stone2 = GameObject.Find("Stone2");
	
		output = GameObject.Find("roll").GetComponentInChildren<Text> ();
		turns = 0;
		Vector3 pos = new Vector3 (10,10,0);

		//stone1.transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {
	//	stone1.transform.Rotate (0, 0, 50);
		dedectIfTouched ();

	}


	void dedectIfTouched(){

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint((Input.GetTouch (0).position)), Vector2.zero);
			if(hit.collider.tag == "stone1")
			{
				output.text ="stone1"; 
			//	Debug.Log ("Touched stone1");
			}
			else if(hit.collider.tag == "stone2")
			{
			
				output.text ="stone1"; 
				//Debug.Log ("Touched stone2");
			}
		
		}




	
	}

	void updateTurns(int newRoll){
		turns = newRoll;
		Debug.Log ("turns - origin: GM. " + turns);
}

	public void testMethod(){
		
		Debug.Log ("gm test method ");
	}















}
