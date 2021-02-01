using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
	public State initialState;

    Dictionary<string, State> states = new Dictionary<string, State>();

    Agent Owner { get; set; }
    State State { get; set; }

	private void Start()
	{
        State[] states = GetComponentsInChildren<State>();
        foreach (State state in states)
		{
            this.states.Add(state.GetType().Name, state);
		}

        SetState(initialState);
    }

    public void Execute()
	{
        if (State != null) State.Update(Owner);
    }

    public void SetState(string stateName)
	{
        if (states.ContainsKey(stateName))
		{
            SetState(states[stateName]);
		}
	}

	public void SetState(State newState)
    {
        if (newState != State)
        {
            if (State != null)
            {
                State.Exit(Owner);
            }
            State = newState;
            newState.Enter(Owner);
        }
    }

}
