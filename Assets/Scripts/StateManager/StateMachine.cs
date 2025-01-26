using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public AbstractState currentstate;
    public NormalState normalState = new NormalState();
    public BossFightState bossFightState = new BossFightState();
    public LoseState loseState = new LoseState();
    public WinState winState = new WinState();

    public bool PlayerWon = false;
    public float amountOfTimeTillBonusTime = 10f;
    [SerializeField]
    public List<GameObject> lights;

    [SerializeField]
    public GameObject BossBattleText;
    [SerializeField] public GameObject winPanel;
    [SerializeField] public GameObject losePanel;

    public float timeTillWin = 80f;

    public float timeInSpecialTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        currentstate = normalState;
        currentstate.EnterState(this);
        BossBattleText.SetActive(false);
        disableLights();
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentstate.UpdateState(this);
        if(Time.time >= timeTillWin){
            PlayerWon= true;
            RhythmManager.Instance.playerWon = true;
        }
    }

    public void disableLights(){
        foreach(var light in lights){
            light.SetActive(false);
        }
    }
}
