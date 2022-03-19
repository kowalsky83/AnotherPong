using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D ballRb;
    private Vector2 ballVelocity;

    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        ballRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Control bouncing
    private void OnCollisionExit2D(Collision2D other) {        

        ballVelocity = ballRb.velocity;
        
        //Aceleramos mucho contra los jugadores y un poco contra el resto
        if(other.gameObject.name == "Player1" || other.gameObject.name == "Player2"){
            ballVelocity += ballVelocity.normalized * 0.5f;
        }else{
            ballVelocity += ballVelocity.normalized * 0.05f;
        }

        //max ballVelocity
        if (ballVelocity.magnitude > 25.0f)
        {
            ballVelocity = ballVelocity.normalized * 25.0f;
        }

        ballRb.velocity = ballVelocity;
    }

    //Add Points
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "WallRight"){
            gameManager.UpdateScorePLayer1(1);
        }
        if(other.gameObject.name == "WallLeft"){
            gameManager.UpdateScorePLayer2(1);
        }
    }
}
