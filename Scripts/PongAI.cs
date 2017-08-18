using UnityEngine;
using System.Collections;

public class PongAI : MonoBehaviour {

    private GameObject ball;
    private float moveToPos;
    private bool posReached;
	// Use this for initialization
	void Awake () {
        if (!PongGameplayController.onePlayer)
        {
            gameObject.GetComponent<PongPaddle>().opponent = false;
            gameObject.GetComponent<PongAI>().enabled = false;

        }

        ball = GameObject.Find("Ball");
        if (ball == null) Debug.LogWarning("Ball not found");
        //else Debug.Log("Ball found");
        moveToPos = transform.position.y;
        posReached = false;
	}
	
	void FixedUpdate () {

        if (transform.position.y < moveToPos + 0.5f && transform.position.y > moveToPos - 0.5f) posReached = true;
        //Debug.Log(ball);

        if (ball.transform.position.x > 0)
        {
            moveToPos = ball.transform.position.y;
        }
        else 
        {

            if (posReached) {
                moveToPos = Random.Range(-5, 5);
                //Debug.Log("Moving to pos: " + moveToPos);
                posReached = false;
            }
            
        }

        float y = Mathf.Lerp(transform.position.y, moveToPos, .025f);
        transform.position = new Vector3(transform.position.x, y, 0);
	}
}
