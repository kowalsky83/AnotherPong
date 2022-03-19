using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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



private void Awake() {
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

    gamesPlayedList = new List<GamesPlayed>(){
        new GamesPlayed{playerOneName = playerOneName, playerTwoName = playerTwoName, score1 = score1, score2 = score2, winner = winner},
        new GamesPlayed{playerOneName = playerOneName, playerTwoName = playerTwoName, score1 = score1, score2 = score2, winner = winner},
        new GamesPlayed{playerOneName = playerOneName, playerTwoName = playerTwoName, score1 = score1, score2 = score2, winner = winner}
    };


    Games games = new Games{gamesPlayedList = gamesPlayedList}; //list to object

    string json = JsonUtility.ToJson(games);

    File.WriteAllText(Application.persistentDataPath + "/scores.json", json);

}

private class Games {
    public List<GamesPlayed> gamesPlayedList;
}

public void LoadData(){
    string path = Application.persistentDataPath + "/scores.json";
    if (File.Exists(path)) {
        string json = File.ReadAllText(path);
        //GamesPlayed data = JsonUtility.FromJson<GamesPlayed>(json);
        Games data = JsonUtility.FromJson<Games>(json);
        //Debug.Log(json);
        data.gamesPlayedList.ForEach(i=>{
            Debug.Log(i.playerOneName);
        });
    }
}

}
