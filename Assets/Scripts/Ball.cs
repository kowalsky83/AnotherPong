using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D ballRb;
    private Vector2 ballVelocity;
    [SerializeField] private float velocidadInicial = 4.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        StartMove();
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
            ballVelocity += ballVelocity.normalized * 0.01f;
        }

        if (Vector2.Dot(ballVelocity.normalized, Vector2.left) < 0.1f)
        {
            ballVelocity += ballVelocity.y > 0 ? Vector2.left * 0.5f : Vector2.right * 0.5f;
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
        Debug.Log(other.gameObject.name);
    }

    public void StartMove(){    
        float[] xyStart = {-1.0f,-0.9f,-0.8f,-0.8f,-0.7f,0.7f,0.8f,0.9f,1.0f};
        Vector2 forceDir = new Vector2(xyStart[Random.Range(0, 8)], xyStart[Random.Range(0, 8)]);
        forceDir.Normalize();
        ballRb.AddForce(forceDir * velocidadInicial, ForceMode2D.Impulse);
    }
}
