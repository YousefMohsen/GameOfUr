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


	public void loadTestGame(){
		
		SceneManager.LoadScene ("testField");

	}

	public void loadMenu(){
	SceneManager.LoadScene ("MainMenu");
		}

	public void newGame(){
		SceneManager.LoadScene ("GameScene");
	}
}


























