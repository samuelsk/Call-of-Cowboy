using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame(){
		Application.LoadLevel("OldWest");
	}

	public void MainScreen() {
		Application.LoadLevel("MainScreen");
	}

	public void HighscoreScreen() {
		Application.LoadLevel("HighscoreScreen");
	}

}
