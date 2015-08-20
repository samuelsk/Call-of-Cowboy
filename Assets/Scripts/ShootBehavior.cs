using UnityEngine;
using System.Collections;

public class ShootBehavior : MonoBehaviour {

	public float ShootSpeed;

	void Start () 
	{
	}

	void Update()
	{
		transform.Translate (ShootSpeed * Time.deltaTime, 0, 0);
	}
}
