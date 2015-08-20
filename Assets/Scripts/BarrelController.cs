using UnityEngine;
using System.Collections;

public class BarrelController : MonoBehaviour {

	public Sprite[] sprites;
	public GameObject[] chambers;

	// -1 means the first round wasn't fired (i.e. a full barrel).
	private int currentRound = -1;
	// True if mouse is hovering over the game object collider.
	private bool isMouseOver = false;

	// Use this for initialization
	void Start () {

	}

//	 Update is called once per frame
	void Update () {
		// Check for a mouse (or touch) input and if the cursor (or the tap) was over the game object at the time of input.
		if (Input.GetMouseButtonDown (0) && isMouseOver) {
			// Check if all rounds are loaded (i.e. barrel is full).
			if (currentRound >= 0) {
				// Changes current round chamber sprite to loaded.
				chambers [currentRound].GetComponent<SpriteRenderer> ().sprite = sprites [1];
				// Changes to the previous chamber.
				currentRound--;
			}
			// Check for a mouse (or touch) input and if the cursor (or the tap) wasn't over the game object at the time of input.
		} else if (Input.GetMouseButtonDown (0) && !isMouseOver) {
			// Check if the last round was fired (i.e. the barrel is empty).
			if (currentRound < chambers.Length - 1) {
				// Changes to the next chamber.
				currentRound++;
				// Changes current round chamber sprite to empty.
				chambers [currentRound].GetComponent<SpriteRenderer> ().sprite = sprites [0];
				// Rotates the barrel to simulate a spinning revolver barrel.
//				transform.Rotate (Vector3.forward * 60);
			}
		}
	}

	// Called when mouse enters game object collider.
	void OnMouseEnter() {
		isMouseOver = true;
	}

	// Called when mouse exits game object collider.
	void OnMouseExit() {
		isMouseOver = false;
	}

}
