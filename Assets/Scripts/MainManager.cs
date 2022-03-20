using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class MainManager : MonoBehaviour
{
public static MainManager Instance;
public string playerOneName;
public string playerTwoName;
public string setsNumber;
public bool isCPUActive;
public string score1;
public string score2;
public string winner;

public TextMeshProUGUI gameListText;



    private void Awake() {
        LoadData();
        if(Instance!=null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class GamesPlayed{
        public string playerOneName;
        public string playerTwoName;
        public string score1;
        public string score2;
        public string winner;
        
    }

    private List<GamesPlayed> gamesPlayedList;

    public void SaveData(){
        string path = Application.persistentDataPath + "/scores.json";

        gamesPlayedList = new List<GamesPlayed>(){
            new GamesPlayed{playerOneName = playerOneName, playerTwoName = playerTwoName, score1 = score1, score2 = score2, winner = winner}
        }; 


        if (File.Exists(path)) {
            string jsonLoad = File.ReadAllText(path);
            Games data = JsonUtility.FromJson<Games>(jsonLoad);
            if(data.gamesPlayedList.ToArray().Length >= 5){
                data.gamesPlayedList.RemoveAt(4);
            }
            data.gamesPlayedList.ForEach(i=>{
                gamesPlayedList.Add(new GamesPlayed{playerOneName = i.playerOneName, playerTwoName = i.playerTwoName, score1 = i.score1, score2 = i.score2, winner = i.winner});
            }); 
        }

        Games games = new Games{gamesPlayedList = gamesPlayedList}; //list to object
        Debug.Log(JsonUtility.ToJson(games));       

        string json = JsonUtility.ToJson(games);

        File.WriteAllText(path, json);

    }

    //list to object
    private class Games {
        public List<GamesPlayed> gamesPlayedList;
    }

    public void LoadData(){
        string path = Application.persistentDataPath + "/scores.json";
        if (File.Exists(path)) {
            gameListText.text = "";
            string json = File.ReadAllText(path);
            Games data = JsonUtility.FromJson<Games>(json);
            data.gamesPlayedList.ForEach(i=>{
                gameListText.text += i.playerOneName + " vs " + i.playerTwoName + " --- " + i.score1 + "-" + i.score2 + " --- " + i.winner + " Wins\n";
            });
        }

    }

}
