using UnityEngine;
using System.Collections;

public class MusicPlayerManager : MonoBehaviour {

	private static MusicPlayerManager instance = null;

	// Use this for initialization
	void Start () {

		// if has an instance 
		if (instance == null) {
			instance = this;


			// gameObject is the game object this script is attached to.
			// method DontDestroyOnLoad makes the gameObject not be destroyed 
			// automatically when loading a new scene.
			GameObject.DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
			print ("Destroy a Music Player since instance is not null..");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
