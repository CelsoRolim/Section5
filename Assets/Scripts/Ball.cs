using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    private Paddle paddle;
    private Vector3 paddleToBall;
    private bool hasStarted;

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

		AudioSource audioSource = this.GetComponent<AudioSource>();
		audioSource.Play ();
	}	
}
