using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighscoreScript : MonoBehaviour {

	public Text highscoreText;
	public Text scoresText;
	public Button backButton;

	// Use this for initialization
	void Start () {
		highscoreText.text = LanguageManager.GetText ("Highscore");
		backButton.GetComponentInChildren<Text> ().text = LanguageManager.GetText ("Back");
		//Checks if there are no saved scores (i.e. An empty string means there are no saved scores).
		if (PlayerPrefs.GetString ("highscore") == "") {
			scoresText.text = LanguageManager.GetText ("Empty Highscore");
		} else {
			string[] scores = PlayerPrefs.GetString("highscore").Split('/');
			scoresText.text = "1 " + scores [0];
			for (int i = 1; i < scores.Length; i++) {
				if (scores [i] != "0")
					scoresText.text += "\n" + (i+1) + " " + scores[i];
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void loadScene (string scene) {
		Application.LoadLevel (scene);
	}

	public static void saveScore (int score) {
		//Creates an empty array.
		int[] scores = {0, 0, 0, 0, 0};
		//Recovers saved scores which are saved as a single string and separated by '/'.
		string[] savedScores = PlayerPrefs.GetString("highscore").Split('/');
		//Checks if there are no saved scores (i.e. An empty string means there are no saved scores).
		if (savedScores [0] != "") {
			//Sets the scores in the empty array.
			for (int i = 0; i < savedScores.Length; i++)
				scores [i] = int.Parse (savedScores [i]);
		}
		//Checks if the new score is higher than the last score.
		if (score > scores [scores.Length - 1]) {
			//Creates the new highscore string to be saved.
			string highscore = "";
			for (int i = 0; i < scores.Length; i++) {
				//Checks if the new score was already set (i.e. 0 means the new score was already set).
				if (score == 0) {
					//Pushes every score after the new score into the next position, except the last score.
					highscore += "/" + scores [i - 1];
				} else {
					//Checks if the current score is higher than the new score.
					if (scores [i] > score)
						//Sets the current score in the same position.
						highscore += "/" + scores [i];
					else {
						//Replaces the current score with the new score.
						highscore += "/" + score;
						score = 0;
					}
				}
			}
			PlayerPrefs.SetString ("highscore", highscore.Substring(1));
		}
	}

}
