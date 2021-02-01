using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public class StateAgent : MonoBehaviour
{
    public StateMachine stateMachine { get; private set; }

    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
    }

    void Update()
    {
        stateMachine.Execute();
    }
}
