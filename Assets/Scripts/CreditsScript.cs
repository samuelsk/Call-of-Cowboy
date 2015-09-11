using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreditsScript : MonoBehaviour {

	public Text creditsTitle;
	public Button musicButton;
	public Button backButton;

	// Use this for initialization
	void Start () {
		creditsTitle.text = LanguageManager.GetText ("Credits");
		musicButton.GetComponentInChildren<Text>().text = LanguageManager.GetText ("Music");
		backButton.GetComponentInChildren<Text> ().text = LanguageManager.GetText ("Back");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadScene (string scene) {
		Application.LoadLevel (scene);
	}

}
