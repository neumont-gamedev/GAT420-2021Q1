using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeparationBehavior : Behavior
{
	public override Vector3 Execute(GameObject[] gameObjects)
	{
		Vector3 force = Vector3.zero;

		if (gameObjects != null && gameObjects.Length > 0)
		{
			Vector3 directions = Vector3.zero;
			foreach (GameObject gameObject in gameObjects)
			{
				Vector3 v = transform.position - gameObject.transform.position;
				v = v.normalized / (v.magnitude * 0.2f);
				directions = directions + v;
			}
			Vector3 direction = (directions / gameObjects.Length).normalized;

			Vector3 desired = direction * Agent.maxSpeed;
			force = Vector3.ClampMagnitude(desired - Agent.Velocity, Agent.maxForce);

			Debug.DrawRay(transform.position, desired, Color.red); // desired
			Debug.DrawRay(transform.position + Agent.Velocity, force, Color.green); // steering
		}

		return force;
	}
}
