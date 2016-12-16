using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class ButtonManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.touchCount>0) {
		
	
		
		}



	}




	public void loadGameScene(){
		
		SceneManager.LoadScene ("QuickGame");

	}
	public void loadMenu(){
		

		SceneManager.LoadScene ("MainMenu");

		Debug.Log("loadScene");
	}
}
