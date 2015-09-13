using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public CanvasGroup menuGroup;
	public Button playButton;
	public Button highscoreButton;
	public Button languageButton;
	public Button creditsButton;
	public CanvasGroup videoPopupGroup;
	public Text[] videoText;
	public Button videoButton;
	public Button backButton1;
	public CanvasGroup noInternetGroup;
	public Text[] noInternetText;
	public Button backButton2;

	// Use this for initialization
	void Start () {
		//Interessante para reduzir a passagem de tempo (skill? item?).
//		Time.timeScale = 0.5f

		//Interessante para animações.
//		panel.GetComponent<Image>().CrossFadeColor(Color.black, 2.0f, false);
//		thatButton.GetComponent<Image>().CrossFadeAlpha(0.1f, 2.0f, false);

		// If last played date is different from today, the player renews his retries.
		if (!PlayerPrefs.GetString ("lastPlayed").Equals (System.DateTime.Today.ToString ())) {
			PlayerPrefs.SetString ("lastPlayed", System.DateTime.Today.ToString ());
			PlayerPrefs.SetInt ("retries", 3);
		}

		switch (PlayerPrefs.GetInt ("lang")) {
		case 0:
			LanguageManager.LoadLanguageFile(Language.English);
			break;
		case 1:
			LanguageManager.LoadLanguageFile(Language.Portuguese);
			break;
		}

		playButton.GetComponentInChildren<Text> ().text = LanguageManager.GetText ("Play");
		highscoreButton.GetComponentInChildren<Text> ().text = LanguageManager.GetText ("Highscore");
		languageButton.GetComponentInChildren<Text> ().text = LanguageManager.GetText ("Language");
		creditsButton.GetComponentInChildren<Text> ().text = LanguageManager.GetText ("Credits");
		videoText[0].text = LanguageManager.GetText ("No Retries");
		videoText [1].text = LanguageManager.GetText ("for more retries")
			+ "\n" + LanguageManager.GetText ("or");
		videoText[2].text = LanguageManager.GetText ("and wait a day");
		videoButton.GetComponentInChildren<Text>().text = LanguageManager.GetText ("Watch Video");
		backButton1.GetComponentInChildren<Text>().text = LanguageManager.GetText ("Go Back");
		noInternetText [0].text = LanguageManager.GetText ("No Internet");
		noInternetText [1].text = LanguageManager.GetText ("You need an internet connection to watch the video");
		backButton2.GetComponentInChildren<Text> ().text = LanguageManager.GetText ("Back");

		BGMManager.instance.playBGM ("MainScene");
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
