using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoseScore : MonoBehaviour {

	//public Text scoreText;

	// Use this for initialization
	void Start () {
		//scoreText.text = "Score: "+GameControllerCowboy.score;
		GetComponent<Text> ().text = "Score: " + GameControllerCowboy.score;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
