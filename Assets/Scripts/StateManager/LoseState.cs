using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : AbstractState
{
    public override void EnterState(StateMachine stateMachine)
    {
        stateMachine.losePanel.SetActive(true);
        RhythmManager.Instance.maxBubbles = 0;
        stateMachine.disableLights();
        stateMachine.BossBattleText.SetActive(false);
        Debug.Log("Lost!");
    }

    public override void OnCollisionEnter(StateMachine stateMachine)
    {
    }

    public override void UpdateState(StateMachine stateMachine)
    {
    }
}
