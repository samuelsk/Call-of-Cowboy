using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public float speed;
	public static int score = 0;
	public GameObject tiro;

	// Use this for initialization
	void Start () {
		//score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, -speed * Time.deltaTime, 0);

	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Food") {
			Destroy(other.gameObject);
			Destroy(this.gameObject);

			GameControllerCowboy.score += 10;
			print("Score: " + GameControllerCowboy.score);
		}
	}

}
