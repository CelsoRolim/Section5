using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    private Paddle paddle;
    private Vector3 paddleToBall;
    private bool hasStarted;
	private Rigidbody2D rigidBodyBrick;

	void Awake()
	{
		rigidBodyBrick = this.GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start ()
    {

        // get reference to the object Paddle
        paddle = GameObject.FindObjectOfType<Paddle>();

        // get the difference between ball and paddle
        paddleToBall = this.transform.position - paddle.transform.position;

        hasStarted = false;
    }
	
	// Update is called once per frame
	void Update ()
    {

        // update the position of the ball.
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBall;

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse clicked");
                hasStarted = true;

                // update velocity of the ball
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }
    }

	void OnCollisionEnter2D(Collision2D collision)
	{
		// only play audio if game has started
		if (!hasStarted) 
		{
			return;
		}

		AddRandomVelocity();

		AudioSource audioSource = this.GetComponent<AudioSource>();
		audioSource.Play ();
	}

	// Method to add a random ammount of velocity
	private void AddRandomVelocity()
	{
		Vector2 randomVelocity = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
		rigidBodyBrick.velocity += randomVelocity;
	}
}
