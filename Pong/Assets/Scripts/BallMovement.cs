using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    // Variables for the game
    public bool xMove = true;
    public bool yMove = true;
    public float xSpeed = 0.015f;
    public float ySpeed = 0.01f;
    public float xBorder = 10.1f;
    public float yBorder = 5.1f;
    int leftPlayerScore;
    int rightPlayerScore;
    public Text scoreTextLP;
    public Text scoreTextRP;

    bool ballInPlay = true;

    void Start()
    {
        LaunchBall();
    }

    void Update()
    {
        if (!ballInPlay)
            return;

        MoveBall();
        CheckBorders();
    }

    void MoveBall()
    {
        transform.position = new Vector2(transform.position.x + xSpeed, transform.position.y + ySpeed);
    }

    void CheckBorders()
    {
        if (transform.position.x >= xBorder || transform.position.x <= -xBorder)
        {
            if (transform.position.x > 0)
                leftPlayerScore++;
            else
                rightPlayerScore++;

            UpdateScores();
            ResetBallPosition();
            ballInPlay = true; // Set ballInPlay to true before launching the ball again
            LaunchBall();
        }

        if (transform.position.y >= yBorder || transform.position.y <= -yBorder)
        {
            ySpeed *= -1;
        }
    }

    void UpdateScores()
    {
        scoreTextLP.text = leftPlayerScore.ToString();
        scoreTextRP.text = rightPlayerScore.ToString();
    }

    void ResetBallPosition()
    {
        transform.position = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("RPlayer") || coll.collider.CompareTag("LPlayer"))
        {
            Debug.Log("hit");

            xSpeed *= -1;
        }
    }

    public void LaunchBall()
    {
        ballInPlay = true;
        xSpeed = Mathf.Abs(xSpeed); // Ensure xSpeed is positive to launch in the correct direction
    }
}