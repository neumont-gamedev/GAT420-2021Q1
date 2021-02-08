using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
	public float idleTime = 2;

	float timer = 0;

	public override void Enter(Agent owner)
	{
		Debug.Log(GetType().Name + " Enter");
		timer = idleTime;
	}

	public override void Execute(Agent owner)
	{
		GameObject[] gameObjects = owner.perception.GetGameObjects();
		GameObject player = Perception.GetGameObjectFromTag(gameObjects, "Player");

		owner.movement.Velocity = Vector3.zero;

		if (player != null)
		{
			((StateAgent)owner).StateMachine.SetState("AttackState");
		}
		else
		{
			timer = timer - Time.deltaTime;
			if (timer <= 0)
			{
				((StateAgent)owner).StateMachine.SetState("PatrolState");
			}
		}
	}

	public override void Exit(Agent owner)
	{
		Debug.Log(GetType().Name + " Exit");
	}
}
