using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControllerCowboy : MonoBehaviour {

	public Camera cam;
	public GameObject enemy;
	private float maxWidth;
	public int life = 3;
	public Text lifeText;
	public Text lose;
	public int mode = 1;

	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		lose.gameObject.SetActive(false);

		Vector3 targetWidth = cam.ScreenToWorldPoint(new Vector3 (Screen.width, Screen.height, 0.0f));
		//float enemyWidth = enemy.GetComponent<Renderer> ().bounds.extents.x;
		lifeText.text = "Life: " + life;
		maxWidth = targetWidth.x - enemy.GetComponent<Renderer> ().bounds.extents.x;
		StartCoroutine (Spawn ());

	}

	IEnumerator Spawn() {
		//if(
		while (life > 0) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-maxWidth, maxWidth), transform.position.y, 0.0f);
			Quaternion spawnRotation = Quaternion.identity; // Sem rotação
			Instantiate (enemy, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(Random.Range (0.25f, 1.0f));
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Enemy") {
			if (life > 0) {
				//Destroy (other.gameObject);
				life--;
				lifeText.text = "Life: " + life;
				if(life == 0){
					lose.gameObject.SetActive(true);
					Application.LoadLevel("tapToPlay");
				}
			}
		}
	}
}
