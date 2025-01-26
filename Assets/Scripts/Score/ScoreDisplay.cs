using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour, IDataPersistence
{
    private int playerExperience;
    int highscore = 0;
    [SerializeField] private TextMeshProUGUI expText;

    public static ScoreDisplay instance { get; private set;}

    void Awake(){
        if(instance!=null && instance!=this){
            Destroy(this);
            return;
        }

        instance = this;
    }

    public void UpdateScore(int score)
    {
        highscore += score;
        expText.text = "XP: " + highscore;
    }

    public void LoadData(GameData data)
    {
        this.playerExperience = data.playerExperience;
    }

    public void SaveData(GameData data)
    {
        data.playerExperience = this.playerExperience;
    }
}
