using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BlockSceneManager : MonoBehaviour {

	// Update is called once per frame
	void Update () {
	}

    // Method to go to a specific scene.
    public void goToScene(string sceneName) {

        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

	// Method to check if all breakable bricks were destroyed.
	public void BrickDestroyed() 
	{
		if(Brick.breakableCount <= 0) 
		{
			LoadNextLevel ();
		}
	}
}
