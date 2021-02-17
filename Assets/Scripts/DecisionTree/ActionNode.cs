using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionNode : DecisionNode
{
	public override void Execute()
	{
		State = eState.Active;
	}
}
