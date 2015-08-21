using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarrelController : MonoBehaviour {

	public Sprite[] sprites;
	public Image[] chambers;

	public GameObject shootProj;
	public GameObject hero;
	public GameObject shootLine;

	private Camera cam;
	private Vector3 touch;
	private Vector3 dir;
	private float angle;


	// -1 means the first round wasn't fired (i.e. a full barrel).
	private int currentRound = -1;
	// True if mouse is hovering over the game object collider.
	private bool isMouseOver = false;

	// Use this for initialization
	void Start () 
	{
		cam = Camera.main;
	}

	// Update is called once per frame
	void Update () {
		// Check for a mouse (or touch) input and if the cursor (or the tap) was over the game object at the time of input.
		if (Input.GetMouseButtonDown (0) && isMouseOver) {
			// Check if all rounds are loaded (i.e. barrel is full).
			if (currentRound >= 0) {
				// Changes current round chamber sprite to loaded.
				chambers [currentRound].sprite = sprites [1];
				// Changes to the previous chamber.
				currentRound--;
			}
			// Check for a mouse (or touch) input and if the cursor (or the tap) wasn't over the game object at the time of input.
		} else if (Input.GetMouseButtonDown (0) && !isMouseOver) {
			// Check if the last round was fired (i.e. the barrel is empty).
			if (currentRound < chambers.Length - 1) {

				shootProjectile ();


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
	public void OnMouseEnter() {
		isMouseOver = true;
	}

	// Called when Pointer Exit event trigger is called (i.e. when mouse exits game object collider).
	public void OnMouseExit() {
		isMouseOver = false;
	}

}
