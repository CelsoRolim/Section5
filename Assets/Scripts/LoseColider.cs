using UnityEngine;
using System.Collections;

public class LoseColider : MonoBehaviour
{

    private BlockSceneManager blockSceneManager;

    void Start()
    {
        blockSceneManager = GameObject.FindObjectOfType<BlockSceneManager>();
    }

    // Trigger collider ignores the physics (the ball pass throught the LoseObject)
    void OnTriggerEnter2D(Collider2D trigger)
    {
        Debug.Log("OnTriggerEnter2D");
    }

    // Collision collider consider the physics of the object(the ball stops on the LoseObject)
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");

        // the ball hits the ground. So the game ends.
        blockSceneManager.goToScene("Lose");
    }
}
