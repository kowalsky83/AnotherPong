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

private void Awake() {
    if(Instance!=null){
        Destroy(gameObject);
        return;
    }
    Instance = this;
    DontDestroyOnLoad(gameObject);
}

/* [System.Serializable]
class MyData{
    public string playerOneName;
    public string playerTwoName;
    public string setsNumber;
}


public void SaveData(){
    MyData data = new MyData();
    data.playerOneName = playerOneName;
    data.playerTwoName = playerTwoName;
    data.setsNumber = setsNumber;
}

public void LoadData(){

} */

}
