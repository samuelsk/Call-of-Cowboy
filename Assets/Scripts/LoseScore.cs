using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;

public class LoseScore : MonoBehaviour {

	public CanvasGroup menuGroup;
	public Text loseText;
	public Text scoreText;
	public Button retryButton;
	public Button mainMenuButton;
	public CanvasGroup videoPopupGroup;
	public Text[] videoText;
	public Button videoButton;
	public Button backButton1;
	public CanvasGroup noInternetGroup;
	public Text[] noInternetText;
	public Button backButton2;

	// Use this for initialization
	void Start () {
		// Substracts one retry from the player.
		PlayerPrefs.SetInt ("retries", PlayerPrefs.GetInt ("retries") - 1);

		loseText.text = LanguageManager.GetText ("LoseText");
		scoreText.text = LanguageManager.GetText ("Score") + ":\n" + GameControllerCowboy.score;
		HighscoreScript.saveScore (GameControllerCowboy.score);
		retryButton.GetComponentInChildren<Text> ().text = LanguageManager.GetText ("Retry");
		mainMenuButton.GetComponentInChildren<Text> ().text = LanguageManager.GetText ("Main Menu");
		videoText[0].text = LanguageManager.GetText ("No Retries");
		videoText [1].text = LanguageManager.GetText ("for more retries")
			+ "\n" + LanguageManager.GetText ("or");
		videoText[2].text = LanguageManager.GetText ("and wait a day");
		videoButton.GetComponentInChildren<Text>().text = LanguageManager.GetText ("Watch Video");
		backButton1.GetComponentInChildren<Text>().text = LanguageManager.GetText ("Go Back");
		noInternetText [0].text = LanguageManager.GetText ("No Internet");
		noInternetText [1].text = LanguageManager.GetText ("You need an internet connection to watch the video");
		backButton2.GetComponentInChildren<Text> ().text = LanguageManager.GetText ("Back");

		BGMManager.instance.stopBGM ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadScene (string scene) {
		if (scene.Equals ("OldWest")) {
			if (PlayerPrefs.GetInt ("retries") > 0) {
				Application.LoadLevel (scene);
			} else {
				toggleGroup (menuGroup, false);
				toggleGroup (videoPopupGroup, true);
			}
		} else Application.LoadLevel (scene);
	}
	
	public void PlayVideo (bool didAccept) {
		if (didAccept) {
			if (Advertisement.IsReady("rewardedVideo")) {
				var options = new ShowOptions { resultCallback = HandleShowResult };
				Advertisement.Show ("rewardedVideo", options);
				toggleGroup (menuGroup, true);
				toggleGroup (videoPopupGroup, false);
			} else {
				toggleGroup (videoPopupGroup, false);
				toggleGroup (noInternetGroup, true);
			}
		}
	}
	
	public void ConfirmNoInternet () {
		toggleGroup (noInternetGroup, false);
		toggleGroup (menuGroup, true);
	}
	
	private void HandleShowResult (ShowResult result) {
		switch (result) {
		case ShowResult.Finished:
			PlayerPrefs.SetInt ("retries", 3);
			break;
		case ShowResult.Skipped:
			break;
		case ShowResult.Failed:
			break;
		}
	}

	private void toggleGroup (CanvasGroup group, bool isHidden) {
		if (isHidden) {
			group.alpha = 1.0f;
			group.interactable = true;
			group.blocksRaycasts = true;
		} else {
			group.alpha = 0.0f;
			group.interactable = false;
			group.blocksRaycasts = false;
		}
	}

}
