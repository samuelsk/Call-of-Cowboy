using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControllerCowboy : MonoBehaviour {

	public Camera cam;
	public GameObject enemy;
	public int life = 3;
	private float spawnSpeedMin = 0.5f;
	private float spawnSpeedMax = 1f;
	//public int mode = 1;
	public static int score = 0;
	private int lastScore = 0;

	public Text lifeText;
	public Text scoreText;
	public GameObject blurImage;
	public Button continueButton;
	public Button mainMenuButton;
	public GameObject confirmImage;
	public Text[] confirmText;
	public Button yesButton;
	public Button noButton;

	public static bool isGamePaused = false;

	private float maxWidth;

	private int modifier = 0;

	// Use this for initialization
	void Start () {
		score = 0;
		scoreText.text = score.ToString();

		continueButton.GetComponentInChildren<Text>().text = LanguageManager.GetText ("Continue");
		mainMenuButton.GetComponentInChildren<Text>().text = LanguageManager.GetText ("Main Menu");
		confirmText [0].text = LanguageManager.GetText ("Are you sure?");
		confirmText [1].text = LanguageManager.GetText ("You'll lose one retry");
		yesButton.GetComponentInChildren<Text> ().text = LanguageManager.GetText ("Yes");
		noButton.GetComponentInChildren<Text> ().text = LanguageManager.GetText ("No");
		confirmImage.SetActive (false);
		blurImage.SetActive (false);

		Vector3 targetWidth = cam.ScreenToWorldPoint(new Vector3 (Screen.width, Screen.height, 0.0f));
		//float enemyWidth = enemy.GetComponent<Renderer> ().bounds.extents.x;
		lifeText.text = LanguageManager.GetText("Lifes") + ": " + life;
		maxWidth = targetWidth.x - enemy.GetComponent<Renderer> ().bounds.extents.x;
		StartCoroutine (Spawn ());

		BGMManager.instance.playBGM ("OldWest");
	}

	IEnumerator Spawn() {
		//if(
		while (life > 0) {
			if(score > 1000 & score <= 8000){
				if (modifier != score / 1000){
					modifier = score / 1000;
//					life++;
//					lifeText.text = "Life: " + life;
				}
//				if(score == 4000){
//					spawnSpeedMin = 0.3f;
//					spawnSpeedMax = 0.5f;
//				} else if (score == 1000){
//					spawnSpeedMin = 0.01f;
//					spawnSpeedMax = 0.1f;
//				}
				Debug.Log(modifier);
			}
			Vector3 spawnPosition = new Vector3 (Random.Range (-maxWidth, maxWidth), transform.position.y/2, 0.0f);
			Quaternion spawnRotation = Quaternion.identity; // Sem rotação
			enemy.GetComponent<EnemyScript>().speed = 4 + modifier * 0.5f;
			Instantiate (enemy, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(Random.Range (spawnSpeedMin, spawnSpeedMax));
		}
	}

	// Update is called once per frame
	void Update () {
		if (score != lastScore) {
			lastScore = score;
			scoreText.text = score.ToString();
		}

		if(score == 4000){
			spawnSpeedMin = 0.4f;
			spawnSpeedMax = 0.6f;
		} else if (score == 8000){
			//Debug.Log("ENTROU");
			spawnSpeedMin = 0.25f;
			spawnSpeedMax = 0.45f;
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Enemy") {
			if (life > 0) {
				//Destroy (other.gameObject);
				life--;
				lifeText.text = LanguageManager.GetText("Lifes") + ": " + life;
				GetComponent<AudioSource>().Play ();
				if (life == 0)
					Application.LoadLevel("LoseScene");
			}
		}
	}

	public void togglePause () {
		if (isGamePaused) {
			isGamePaused = false;
			blurImage.SetActive (false);
			Time.timeScale = 1.0f;
		} else {
			isGamePaused = true;
			blurImage.SetActive (true);
			Time.timeScale = 0.0f;
		}
	}

	public void LoadScene (string scene) {
		if (scene.Equals ("MainScene"))
			confirmImage.SetActive (true);
		else Application.LoadLevel (scene);
	}

	public void ConfirmQuit (bool didConfirm) {
		if (didConfirm) {
			togglePause ();
			PlayerPrefs.SetInt ("retries", PlayerPrefs.GetInt ("retries") - 1);
			Application.LoadLevel ("MainScene");
		} else {
			confirmImage.SetActive (false);
		}
	}

}
