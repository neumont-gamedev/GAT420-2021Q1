using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehavior : Behavior
{
	[Range(0, 45)] public float displacement = 5;
	[Range(0, 2)] public float radius = 3;
	[Range(0, 5)] public float distance = 1;

	float angle = 0;

	public override Vector3 Execute(GameObject[] gameObjects)
	{
		Vector3 force = Vector3.zero;

		angle = angle + Random.Range(-displacement, displacement);
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
		Vector3 point = rotation * new Vector3(0, 0, radius);

		Vector3 forward = Agent.Direction * distance;
		Debug.DrawLine(transform.position, transform.position + forward, Color.green);
		Debug.DrawLine(transform.position + forward, transform.position + forward + point, Color.green);

		Vector3 direction = (forward + point).normalized;
		Vector3 desired = direction * Agent.maxSpeed;
		force = Vector3.ClampMagnitude(desired - Agent.Velocity, Agent.maxForce);

		return force;
	}
}
