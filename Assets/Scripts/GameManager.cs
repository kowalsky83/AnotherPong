using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject nets;
    [SerializeField] private GameObject inGameUi;
    [SerializeField] private GameObject endGameUi;
    [SerializeField] private ParticleSystem WinParticles;

    [SerializeField] private TextMeshProUGUI finalScore;
    [SerializeField] private TextMeshProUGUI winner;

    [SerializeField] private TextMeshProUGUI scoreTextPlayer1;
    [SerializeField] private TextMeshProUGUI nameTextPlayer1;
    private int scorePlayer1;

    [SerializeField] private TextMeshProUGUI scoreTextPlayer2;
    [SerializeField] private TextMeshProUGUI nameTextPlayer2;
    private int scorePlayer2;
    private string maxScore;
    public bool isInProgress = true;
    // Start is called before the first frame update
    void Start()
    {
        nameTextPlayer1.text = "Player1"; //MainManager.Instance.playerOneName.Length > 0 ? MainManager.Instance.playerOneName : "Player1";
        nameTextPlayer2.text = "CPU";//MainManager.Instance.playerTwoName.Length > 0 ? MainManager.Instance.playerTwoName : "Player2";
        maxScore = "2";//MainManager.Instance.setsNumber.ToString();
        StartBallMove();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBallMove(){    
        ball.transform.position = new Vector2(0,0);
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ball.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        float[] xyStart = {-1.0f,-0.9f,-0.8f,-0.8f,-0.7f,0.7f,0.8f,0.9f,1.0f};
        Vector2 forceDir = new Vector2(xyStart[Random.Range(0, 8)], xyStart[Random.Range(0, 8)]);
        forceDir.Normalize();
        ball.GetComponent<Rigidbody2D>().AddForce(forceDir * 5.0f, ForceMode2D.Impulse);
    }

    public void UpdateScorePLayer1(int punto){
            scorePlayer1 += punto;
            scoreTextPlayer1.text = scorePlayer1.ToString();
            if(scorePlayer1.ToString() == maxScore){
                SetWinner(nameTextPlayer1.text);
            }else{
                StartBallMove();
            }
    }

    public void UpdateScorePLayer2(int punto){
            scorePlayer2 += punto;
            scoreTextPlayer2.text = scorePlayer2.ToString();
            if(scorePlayer2.ToString() == maxScore){
                SetWinner(nameTextPlayer2.text);
            }else{
                StartBallMove();
            }
    }

    void SetWinner(string winnerName){
        isInProgress=false;
        Destroy(ball);
        nets.SetActive(false);
        inGameUi.SetActive(false);
        winner.text = winnerName + " winner";
        finalScore.text = nameTextPlayer1.text + " " + scoreTextPlayer1.text + " - " + scoreTextPlayer2.text + " " + nameTextPlayer2.text;
        endGameUi.SetActive(true);
        WinParticles.Play();
    }

    void ResetBall(){
        ball.transform.position = new Vector2(0,0);
    }

    public void BackToTitle(){
        SceneManager.LoadScene(0);
    }

    public void PlayAgain(){
        SceneManager.LoadScene(1);
    }
}
