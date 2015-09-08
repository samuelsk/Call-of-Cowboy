using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControllerCowboy : MonoBehaviour {

	public Camera cam;
	public GameObject enemy;
	public int life = 3;
	private float spawnSpeedMin = 0.5f;
	private float spawnSpeedMax = 1f;
	public Text lifeText;
	public Text scoreText;
	//public int mode = 1;
	public static int score = 0;
	private int lastScore = 0;

	private float maxWidth;

	private int modifier = 0;


	// Use this for initialization
	void Start () {
		score = 0;
		scoreText.text = score.ToString();
		if (cam == null) {
			cam = Camera.main;
		}

		Vector3 targetWidth = cam.ScreenToWorldPoint(new Vector3 (Screen.width, Screen.height, 0.0f));
		//float enemyWidth = enemy.GetComponent<Renderer> ().bounds.extents.x;
		lifeText.text = "Life: " + life;
		maxWidth = targetWidth.x - enemy.GetComponent<Renderer> ().bounds.extents.x;
		StartCoroutine (Spawn ());

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
			Vector3 spawnPosition = new Vector3 (Random.Range (-maxWidth, maxWidth), transform.position.y, 0.0f);
			Quaternion spawnRotation = Quaternion.identity; // Sem rotação
			enemy.GetComponent<EnemyScript>().speed = 4 + modifier * 0.5f;
			Instantiate (enemy, spawnPosition, spawnRotation);
			Debug.Log(spawnSpeedMax);
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
				lifeText.text = "Life: " + life;
				if(life == 0){
					Application.LoadLevel("LoseScreen");
				}
			}
		}
	}
}
