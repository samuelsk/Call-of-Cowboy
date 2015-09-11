using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarrelController : MonoBehaviour {

	public Sprite[] sprites;
	public Image[] chambers;
	public AudioClip[] sfx;

	public GameObject shootProj;
	public GameObject hero;
	public GameObject shootLine;

	private Camera cam;
	private Vector3 touch;
	private Vector3 dir;
	private float angle;
	private AudioSource audioSource;


	// -1 means the first round wasn't fired (i.e. a full barrel).
	private int currentRound = -1;
	// True if mouse is hovering over the barrel collider.
	private bool isMouseOverBarrel = false;
	// True if mouse is hovering over the pause button.
	private bool isMouseOverPauseButton = false;

	// Use this for initialization
	void Start () 
	{
		cam = Camera.main;
		audioSource = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if (!GameControllerCowboy.isGamePaused) {
			// Checks for a mouse (or touch) input and if the cursor (or the tap) was over the game object at the time of input.
			if (Input.GetMouseButtonDown (0) && isMouseOverBarrel) {
				// Checks if all rounds are loaded (i.e. barrel is full).
				if (currentRound >= 0) {
					//Switches audio clip to the reloading sfx.
					audioSource.clip = sfx [2];
					audioSource.Play ();

					// Changes current round chamber sprite to loaded.
					chambers [currentRound].sprite = sprites [1];
					// Changes to the previous chamber.
					currentRound--;
				}
				// Checks for a mouse (or touch) input and if the cursor (or the tap) wasn't over the game object at the time of input.
			} else if (Input.GetMouseButtonDown (0) && !isMouseOverBarrel && !isMouseOverPauseButton) {
				// Checks if the last round was fired (i.e. the barrel is empty).
				if (currentRound < chambers.Length - 1) {
					//Switches audio clip to the shooting sfx.
					audioSource.clip = sfx [0];
					audioSource.Play ();
					shootProjectile ();
				} else {
					//Switches audio clip to the dry fire sfx.
					audioSource.clip = sfx [1];
					audioSource.Play ();
				}
			}
		}
	}


	void shootProjectile()
	{
		touch = cam.ScreenToWorldPoint (Input.mousePosition);
		touch.z = 0;

		if (!(touch.y < shootLine.transform.position.y)) 
		{
		 dir = touch - hero.transform.position;
	 	 dir = transform.InverseTransformDirection (dir);
		
		 angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		
		 Quaternion quat = Quaternion.Euler (new Vector3 (0, 0, angle));
		
		 Instantiate (shootProj, hero.transform.position, quat);

		 currentRound++;
		 // Changes current round chamber sprite to empty.
		 chambers [currentRound].sprite = sprites [0];
  	    }
	}

	// Called when Pointer Enter event trigger is called (i.e. when mouse enters game object collider).
	public void OnMouseEnterBarrel() {
		isMouseOverBarrel = true;
	}

	// Called when Pointer Exit event trigger is called (i.e. when mouse exits game object collider).
	public void OnMouseExitBarrel() {
		isMouseOverBarrel = false;
	}

	public void OnMouseEnterPauseButton() {
		isMouseOverPauseButton = true;
	}

	public void OnMouseExitPauseButton() {
		isMouseOverPauseButton = false;
	}

}
