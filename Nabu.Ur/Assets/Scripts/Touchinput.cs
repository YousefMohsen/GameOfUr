using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Touchinput : MonoBehaviour {

	Text tagText;
	Text posText;
	Text phaseText;
	int testint;

	void Start () {
		Debug.Log ("start works");
		tagText = returnLabelWithTag ("TagText");
		phaseText = returnLabelWithTag ("PhaseText");
		posText=returnLabelWithTag("PosText");
		testint = 0;


	}

	// Update is called once per frame
	void Update () {
		dedectIfTouched ();
	}


	void dedectIfTouched(){

		if (Input.touchCount > 0)

		{

			RaycastHit2D hit  = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);

			//			
			testint++;
			Debug.Log (testint+" f");
	//		posText.text = "gameObjectTag: " + hit.transform.gameObject.tag;
			phaseText.text =  testint+" f";
			if(hit.collider != null)

			{

				tagText.text ="TagPos: collider not null";

			}

		}

		}


		//	posText.text = "TouchPos: " + Input.GetTouch (0).position;




	Text returnLabelWithTag(string tag){ //delete me


		foreach (Text textElement in GameObject.Find ("Canvas").GetComponentsInChildren<Text>()) {
			if (tag.Equals(textElement.tag)) {
				return textElement;
			}
		}
		return null;

	}
}





/*
		if (Input.touchCount > 0 )
		{
			
			tagText.text ="TagPos:: ";
		RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint((Input.GetTouch (0).position)), Vector2.zero);
		
			if(hit.collider!=null )
			{
				tagText.text ="TagPos:: ";
			
			}




		if(hit.collider!=null && hit.transform.gameObject.tag == "stone1")
			{

			Debug.Log ("Touched stone1");
			}
		
*/