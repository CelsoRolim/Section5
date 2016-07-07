using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public Sprite[] hitSprites;

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
        bool isBreakable = (this.tag == "Breakable");
        if(!isBreakable)
        {
            return;
        }

        HandleHits();
    }

    private void HandleHits()
    {
        timesHits++;
        int maxHits = hitSprites.Length + 1;

        // extending the idea of the ball to do two hits at once.
        if (maxHits <= timesHits)
        {
            // destroy object
            Destroy(gameObject);
        }
        else
        {
            ChangeSprite();
        }
    }

    // Method to change sprits according to hit count
    private void ChangeSprite()
    {
        // get the sprite in case the brick was hit "timesHits - 1"
        int spritHitIndex = timesHits - 1;

        // if the sprite is defined.
        if(hitSprites[spritHitIndex])
        {

            // load the sprite representing the state after being hit
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spritHitIndex];
        }
    }

    // method to simulate win while the logic to is on hold
    private void SimulateWin()
    {
        blockSceneManager.LoadNextLevel();
    }
}
