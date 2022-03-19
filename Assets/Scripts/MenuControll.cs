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
    [SerializeField]  private TMP_InputField playerName1;
    [SerializeField]  private TMP_InputField playerName2;
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
        playerName2.text = "CPU";
        playerName2.readOnly = true;
    }

    public void TwoPlayer(){
        options.SetActive(true);
    }

    public void HideOptions(){
        options.SetActive(false);
    }
}
