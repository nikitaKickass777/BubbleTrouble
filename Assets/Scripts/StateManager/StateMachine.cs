using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    AbstractState currentstate;
    NormalState normalState = new NormalState();
    BossFightState bossFightState = new BossFightState();
    LoseState loseState = new LoseState();
    WinState winState = new WinState();
    // Start is called before the first frame update
    void Start()
    {
        currentstate = normalState;
        currentstate.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentstate.UpdateState(this);
    }
}
