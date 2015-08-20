using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour {

	public GameObject shoot;

	private Camera cam;

	private Vector3 touch;
	private Vector3 dir;

	private float angle;

	void Start () 
	{
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (Input.GetMouseButton (0)) 
		{
			touch = cam.ScreenToWorldPoint (Input.mousePosition);
			touch.z = 0;

			dir = touch - transform.position;
			dir = transform.InverseTransformDirection(dir);

			angle = Mathf.Atan2 (dir.y,dir.x) * Mathf.Rad2Deg;

			Quaternion quat = Quaternion.Euler(new Vector3(0,0,angle));
			//quat = Quaternion.Lerp(shoot.transform.rotation,quat,1);

			Instantiate (shoot, transform.position, quat);
		};
	}

}
