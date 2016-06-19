using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BlockSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Method to go to a specific scene.
    public void goToScene(string sceneName) {

        SceneManager.LoadScene(sceneName);
    }
}
