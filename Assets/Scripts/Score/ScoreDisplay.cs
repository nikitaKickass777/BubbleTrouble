using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour, IDataPersistence
{
    private int playerExperience;
    string exp = "EXP: ";
    [SerializeField] private TextMeshProUGUI expText;

    private int experience;

    public void LoadData(GameData data)
    {
        this.playerExperience = data.playerExperience;
    }

    public void SaveData(GameData data)
    {
        data.playerExperience = this.playerExperience;
    }
}
