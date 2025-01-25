using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    AbstractState currentstate;
    NormalState normalState = new NormalState();
    BossFightState bossFightState = new BossFightState();
    LoseState loseState = new LoseState();
    WinState winState = new WinState();

    [SerializeField]
    GameObject BossBattleText;
    // Start is called before the first frame update
    void Start()
    {
        currentstate = normalState;
        currentstate.EnterState(this);
        BossBattleText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentstate.UpdateState(this);
    }
}
