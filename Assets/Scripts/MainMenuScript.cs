using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	//Permite o uso de anúncios do UnityAds.
		Advertisement.Initialize ("71200");
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
