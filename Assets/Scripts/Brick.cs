using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public Sprite[] hitSprites;
    public static int breakableCount = 0;

    private int timesHits;
    private BlockSceneManager blockSceneManager;
	private bool isBreakable;
	private AudioSource crackSound;

	void Awake()
	{
		Debug.Log ("Awake");
		crackSound = this.GetComponent<AudioSource>();
		breakableCount = 0;
	}

    // Use this for initialization
    void Start () 
	{
		Debug.Log ("Start");
        blockSceneManager = GameObject.FindObjectOfType<BlockSceneManager>();
        timesHits = 0;

		// check if current instance has breakable tag.
		isBreakable = (this.tag == "Breakable");
		if(isBreakable) 
		{
			// increment variable of total breakable bricks
			breakableCount++;
		}
    }

    // Collision collider
    void OnCollisionEnter2D(Collision2D collision)
    {
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
			AudioSource.PlayClipAtPoint (crackSound.clip, transform.position);

			// decrease the total of breakable instances 
			breakableCount--;            
			Debug.Log (breakableCount);
			// check if all bricks have been destroyed.
			blockSceneManager.BrickDestroyed();

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
