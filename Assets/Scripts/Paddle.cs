using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float mousePosInBox = ((Input.mousePosition.x / Screen.width) * 16);
        mousePosInBox = Mathf.Clamp(mousePosInBox, 0.5f, 15.5f);

        Vector3 position = new Vector3(mousePosInBox, this.transform.position.y, 0f);

        this.transform.position = position;
    }
}
