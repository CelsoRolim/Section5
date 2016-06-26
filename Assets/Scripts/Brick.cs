using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public int maxHits;
    private int timesHits;
    private BlockSceneManager blockSceneManager;

    // Use this for initialization
    void Start () {
        blockSceneManager = GameObject.FindObjectOfType<BlockSceneManager>();
        timesHits = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    // Collision collider
    void OnCollisionEnter2D(Collision2D collision)
    {
        timesHits++;
        Debug.Log("Time hits: " + timesHits);

        // TODO 
        // create logic to detect win condition
        //        if(timesHits == 3)
        //        {
        SimulateWin();
        //}
    }

    // method to simulate win while the logic to is on hold
    private void SimulateWin()
    {
        blockSceneManager.LoadNextLevel();
    }
}
