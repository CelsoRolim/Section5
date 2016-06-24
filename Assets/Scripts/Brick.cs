using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public int maxHits;
    private int timesHits;

	// Use this for initialization
	void Start () {
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
    }
}
