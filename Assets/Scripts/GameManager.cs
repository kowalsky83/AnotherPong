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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScorePLayer1(int punto){
        //if(isInProgress){
            scorePlayer1 += punto;
            scoreTextPlayer1.text = scorePlayer1.ToString();
            if(scorePlayer1.ToString() == maxScore){
                SetWinner(nameTextPlayer1.text);
                isInProgress=false;
            }else{
                Instantiate(ball);
            }
        //}
    }

    public void UpdateScorePLayer2(int punto){
        //if(isInProgress){
            scorePlayer2 += punto;
            scoreTextPlayer2.text = scorePlayer2.ToString();
            if(scorePlayer2.ToString() == maxScore){
                SetWinner(nameTextPlayer2.text);
                isInProgress=false;
            }else{
                Instantiate(ball);
            }
        //}
    }

    void SetWinner(string winnerName){
        nets.SetActive(false);
        inGameUi.SetActive(false);
        winner.text = winnerName + " winner";
        finalScore.text = nameTextPlayer1.text + " " + scoreTextPlayer1.text + " - " + scoreTextPlayer2.text + " " + nameTextPlayer2.text;
        endGameUi.SetActive(true);
        WinParticles.Play();
    }

    public void BackToTitle(){
        SceneManager.LoadScene(0);
    }

    public void PlayAgain(){
        SceneManager.LoadScene(1);
    }
}
