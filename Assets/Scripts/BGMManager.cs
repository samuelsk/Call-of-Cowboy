using UnityEngine;
using System.Collections;

public class BGMManager : MonoBehaviour {

	public AudioClip[] bgm;

	private AudioSource audioSource;
	private string currentBGM;

	private static BGMManager _instance;
	
	public static BGMManager instance {
		get {
			if (_instance == null)
				_instance = GameObject.FindObjectOfType<BGMManager> ();
			return _instance;
		}
	}

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();

		if (instance != this)
			Destroy (this.gameObject);

		DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void playBGM (string track) {
		if (!track.Equals (currentBGM)) {
			switch (track) {
			case "MainScene":
				currentBGM = "MainScene";
				audioSource.clip = bgm [0];
				audioSource.Play ();
				break;
			case "OldWest":
				currentBGM = "OldWest";
				audioSource.clip = bgm [1];
				audioSource.Play ();
				break;
			}
		}
	}

	public void stopBGM () {
		currentBGM = null;
		audioSource.Stop ();
	}

}
