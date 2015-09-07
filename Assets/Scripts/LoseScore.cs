using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class LoseScore : MonoBehaviour {

	//public Text scoreText;

	// Use this for initialization
	void Start () {
		//Mostra o anúncio.
		if (Advertisement.isReady ()) {
			Advertisement.Show();
		}
		//scoreText.text = "Score: "+GameControllerCowboy.score;
		GetComponent<Text> ().text = "Score:\n" + GameControllerCowboy.score;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
