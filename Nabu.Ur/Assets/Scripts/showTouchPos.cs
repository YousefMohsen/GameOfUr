using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class moveIfTouched : MonoBehaviour {


	Text txt;

	// Use this for initialization
	void Start () {
	txt = gameObject.GetComponent<Text> ();
		txt.text = "Touch: ";

	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended) {

			Vector2 touchPos = Input.GetTouch (0).position;

			txt.text = "Touch: "+touchPos;

		} 
	

	}
}



/* 	if (Input.touchCount > 0 && Input.GetTouch (0).phase == iPhoneTouchPhase.Ended) {
		
			Vector2 touchPos = Input.GetTouch (0).position;

			transform.position = touchPos;
		
		} */