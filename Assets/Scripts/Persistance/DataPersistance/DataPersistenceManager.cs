using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    private GameData gameData;
    public static DataPersistenceManager instance {get; private set;}

    private void Start()
    {
        NewGame();
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    //public void LoadGame(){}

    public void SaveGame()
    {

    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
