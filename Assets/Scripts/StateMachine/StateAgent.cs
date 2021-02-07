using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public class StateAgent : Agent
{
    public StateMachine StateMachine { get; private set; }

    void Start()
    {
        StateMachine = GetComponent<StateMachine>();
    }

    void Update()
    {
        movement.Reset();
        StateMachine.Execute();
    }
}
