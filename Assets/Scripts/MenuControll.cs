using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuControll : MonoBehaviour
{
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject gamesList;
    [SerializeField]  private TMP_InputField playerName1;
    [SerializeField]  private TMP_InputField playerName2;
    [SerializeField]  private TMP_InputField sets;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exit(){
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void OnePlayer(){
        options.SetActive(true);
        playerName1.text = "";
        playerName2.text = "CPU";
        playerName2.readOnly = true;
        MainManager.Instance.isCPUActive = true;
    }

    public void TwoPlayer(){
        options.SetActive(true);
        playerName1.text = "";
        playerName2.text = "";
        playerName2.readOnly = false;
        MainManager.Instance.isCPUActive = false;
    }

    public void HideOptions(){
        options.SetActive(false);
    }

    public void ShowGamesList(){
        gamesList.SetActive(true);

        
    }

    public void HideGamesList(){
        gamesList.SetActive(false);
    }

    public void StartGame(){
        MainManager.Instance.playerOneName = playerName1.text;
        MainManager.Instance.playerTwoName = playerName2.text;
        MainManager.Instance.setsNumber = sets.text.Length > 0 ? sets.text : "5";
        SceneManager.LoadScene(1);
    }

    IEnumerator WaitLoadData(){
        yield return new WaitForSeconds(2.0f);
        
    }
}
