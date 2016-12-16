using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class ButtonManager : MonoBehaviour {



	// Use this for initialization

	void Start () {


	}
	// Update is called once per frame
	void Update () {
		

		}


	public void loadGameScene(){
		
		SceneManager.LoadScene ("QuickGame");

	}

	public void loadMenu(){
		

	SceneManager.LoadScene ("MainMenu");

	}

}


























