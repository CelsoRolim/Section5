using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public Paddle paddle;
    private Vector3 paddleToBall;
    private bool hasStarted;

	// Use this for initialization
	void Start () {

        // get the difference between ball and paddle
        paddleToBall = this.transform.position - paddle.transform.position;

        hasStarted = false;
    }
	
	// Update is called once per frame
	void Update () {

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
}
