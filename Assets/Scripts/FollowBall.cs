using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public Transform ball;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (ball.GetComponent<BallBehaviour>().gameStarted)
        {
            float yPosition = 0f;
            float offset = speed * Time.deltaTime;
            if(transform.position.y < ball.position.y)
            {
                yPosition = transform.position.y + offset;
            }
            else if(transform.position.y > ball.position.y)
            {
                yPosition = transform.position.y - offset;
            }
            yPosition = Mathf.Clamp(yPosition, -3.7f, 3.7f);
            transform.position = new Vector3(transform.position.x
                                            , yPosition
                                            , transform.position.z);
        }
    }
}
