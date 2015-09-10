using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;

public class LoseScore : MonoBehaviour {
	
	public Text loseText;
	public Text scoreText;
	public Button retryButton;
	public Button mainMenuButton;

	// Use this for initialization
	void Start () {
		//Mostra o anúncio.
		if (Advertisement.IsReady ()) {
			Advertisement.Show();
		}

		loseText.text = LanguageManager.GetText ("LoseText");
		scoreText.text = LanguageManager.GetText ("Score") + ":\n" + GameControllerCowboy.score;
		HighscoreScript.saveScore (GameControllerCowboy.score);
		retryButton.GetComponentInChildren<Text> ().text = LanguageManager.GetText ("Retry");
		mainMenuButton.GetComponentInChildren<Text> ().text = LanguageManager.GetText ("Main Menu");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void loadScene (string scene) {
		Application.LoadLevel(scene);
	}

}
