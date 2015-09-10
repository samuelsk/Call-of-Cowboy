using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LanguageScript : MonoBehaviour {

	public Text langSelectText;
	public Button backButton;

	// Use this for initialization
	void Start () {
		langSelectText.text = LanguageManager.GetText ("LangSelect");
		backButton.GetComponentInChildren<Text> ().text = LanguageManager.GetText("Back");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadScene (string scene) {
		Application.LoadLevel (scene);
	}

	public void ChangeLanguage (int lang) {

		PlayerPrefs.SetInt ("lang", lang);

		switch (lang) {
		case 0:
			LanguageManager.LoadLanguageFile (Language.English);
			break;
		case 1:
			LanguageManager.LoadLanguageFile (Language.Portuguese);
			break;
		}

		langSelectText.text = LanguageManager.GetText ("LangSelect");
		backButton.GetComponentInChildren<Text> ().text = LanguageManager.GetText("Back");
	}

}
