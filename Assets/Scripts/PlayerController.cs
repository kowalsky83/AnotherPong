using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject playerUno;
    [SerializeField] GameObject playerDos;

    [SerializeField] private GameObject ball;

    private Vector2 positionPlayerUno;
    private Vector2 positionPlayerDos;

    public float Speed = 3f;
    public float MaxMovement = 5.5f;

    private GameManager gameManager;

    private bool isCPUActive;
    
    // Start is called before the first frame update
    void Start()
    {
        positionPlayerUno = playerUno.GetComponent<Transform>().position;
        positionPlayerDos = playerDos.GetComponent<Transform>().position;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        isCPUActive = true;//MainManager.Instance.isCPUActive;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isInProgress){
            ControlPlayerUno();
            if(isCPUActive){
                CPUControl();
            }else{
                ControlPlayerDos();
            }
        }
    }

    void ControlPlayerUno(){
        if(Input.GetKey(KeyCode.W)){
            MovePlayer(1);
        }

        if(Input.GetKey(KeyCode.S)){
            MovePlayer(-1);
        }

        if(positionPlayerUno.y >= MaxMovement){
            positionPlayerUno.y = MaxMovement;
        }

        if(positionPlayerUno.y <= -MaxMovement){
            positionPlayerUno.y = -MaxMovement;
        }

        void MovePlayer(int dir){
            positionPlayerUno.y += dir * Speed * Time.deltaTime;
            playerUno.transform.position = positionPlayerUno;
        }
    }

    void ControlPlayerDos(){
        if(Input.GetKey(KeyCode.UpArrow)){
            MovePlayer(1);
        }

        if(Input.GetKey(KeyCode.DownArrow)){
            MovePlayer(-1);
        }

        if(positionPlayerDos.y >= MaxMovement){
            positionPlayerDos.y = MaxMovement;
        }

        if(positionPlayerDos.y <= -MaxMovement){
            positionPlayerDos.y = -MaxMovement;
        }

        void MovePlayer(int dir){
            positionPlayerDos.y += dir * Speed * Time.deltaTime;
            playerDos.transform.position = positionPlayerDos;
        }
    }

    void CPUControl(){

        int dir = 0;

        float diff = positionPlayerDos.y - ball.transform.position.y;
        float distance = Random.Range(0.5f, 0.6f);

        if(diff > - distance && diff < distance){
            dir = 0;
        }else if(diff > distance ){
            dir = -1; 
        }else if(diff < -distance ){
            dir = 1; 
        }

        positionPlayerDos.y += dir * (Speed + 1.2f) * Time.deltaTime;
        playerDos.transform.position = positionPlayerDos;

        if(positionPlayerDos.y >= MaxMovement){
            positionPlayerDos.y = MaxMovement;
        }

        if(positionPlayerDos.y <= -MaxMovement){
            positionPlayerDos.y = -MaxMovement;
        }

    }

}
