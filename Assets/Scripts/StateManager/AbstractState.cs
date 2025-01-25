using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractState
{
    public abstract void EnterState(StateMachine stateMachine);
    public abstract void UpdateState(StateMachine stateMachine);
    public abstract void OnCollisionEnter(StateMachine stateMachine);

}
