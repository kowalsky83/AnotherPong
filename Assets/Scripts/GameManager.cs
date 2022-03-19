using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    public TextMeshProUGUI scoreTextPlayer1;
    private int scorePlayer1;

    public TextMeshProUGUI scoreTextPlayer2;
    private int scorePlayer2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScorePLayer1(int punto){
        scorePlayer1 += punto;
        scoreTextPlayer1.text = scorePlayer1.ToString();
        Instantiate(ball);
    }

    public void UpdateScorePLayer2(int punto){
        scorePlayer2 += punto;
        scoreTextPlayer2.text = scorePlayer2.ToString();
        Instantiate(ball);
    }
}
