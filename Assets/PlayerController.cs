using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject playerUno;
    [SerializeField] GameObject playerDos;

    private Vector2 positionPlayerUno;
    private Vector2 positionPlayerDos;

    public float Speed = 3f;
    public float MaxMovement = 4.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        positionPlayerUno = playerUno.GetComponent<Transform>().position;
        positionPlayerDos = playerDos.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        ControlPlayerUno();
        ControlPlayerDos();
    }

    void ControlPlayerUno(){
        if(Input.GetKey(KeyCode.UpArrow)){
            MovePlayer(1);
        }

        if(Input.GetKey(KeyCode.DownArrow)){
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
        if(Input.GetKey(KeyCode.W)){
            MovePlayer(1);
        }

        if(Input.GetKey(KeyCode.S)){
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

}
