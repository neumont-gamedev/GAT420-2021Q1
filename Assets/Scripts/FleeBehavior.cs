﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeBehavior : Behavior
{
	public override Vector3 Execute(GameObject[] gameObjects)
	{
		Vector3 force = Vector3.zero;

		if (gameObjects != null && gameObjects.Length > 0)
		{
			GameObject target = gameObjects[0];

			Vector3 direction = (transform.position - target.transform.position).normalized;
			Vector3 desired = direction * Agent.MaxSpeed;
			force = Vector3.ClampMagnitude(desired - Agent.Velocity, Agent.MaxForce);
		}

		return force;
	}
}
