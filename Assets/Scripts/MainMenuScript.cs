using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public Button playButton;
	public Button highscoreButton;
	public Button languageButton;

	// Use this for initialization
	void Start () {
		switch (PlayerPrefs.GetInt ("lang")) {
		case 0:
			LanguageManager.LoadLanguageFile(Language.English);
			break;
		case 1:
			LanguageManager.LoadLanguageFile(Language.Portuguese);
			break;
		}
		playButton.GetComponentInChildren<Text>().text = LanguageManager.GetText("Play");
		highscoreButton.GetComponentInChildren<Text> ().text = LanguageManager.GetText ("Highscore");
		languageButton.GetComponentInChildren<Text>().text = LanguageManager.GetText("Language");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadScene (string scene) {
		Application.LoadLevel (scene);
	}

}
