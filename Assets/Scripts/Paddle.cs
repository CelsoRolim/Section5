using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	public float minX, maxX;

	private Ball ball;

	void Start()
	{
		ball = GameObject.FindObjectOfType<Ball>();
	}

	// Update is called once per frame
	void Update () {
		if(!autoPlay) 
		{
			MouseMove();
		} else 
		{
			AutoPlay ();
		}
    }

	void AutoPlay()
	{
		// paddle starts at 0.5f in x axis. We will keep the position in y and z axis.
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

		Vector3 ballPos = ball.transform.position;

		// Mathf.Clamp will keep the x position between 0.5f and 15.5f
		paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
		this.transform.position = paddlePos;	
	}

	void MouseMove()
	{
		float mousePosInBox = ((Input.mousePosition.x / Screen.width) * 16);
		mousePosInBox = Mathf.Clamp(mousePosInBox, minX, maxX);

		Vector3 position = new Vector3(mousePosInBox, this.transform.position.y, 0f);

		this.transform.position = position;	
	}
}
