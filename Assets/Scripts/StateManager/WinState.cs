using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : AbstractState
{
    public override void EnterState(StateMachine stateMachine)
    {
        stateMachine.winPanel.SetActive(true);
        RhythmManager.Instance.maxBubbles = 0;
        stateMachine.disableLights();
        stateMachine.BossBattleText.SetActive(false);
        Debug.Log("Won!");
    }

    public override void OnCollisionEnter(StateMachine stateMachine)
    {
    }

    public override void UpdateState(StateMachine stateMachine)
    {
    }
}
