using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAgent : MonoBehaviour
{
	[SerializeField] float maxSpeed = 2;
	[SerializeField] float maxForce = 2;
    [SerializeField] Perception perception = null;
	[SerializeField] Behavior behavior = null;

	public float MaxSpeed { get { return maxSpeed; } }
	public float MaxForce { get { return maxForce; } }
	public Vector3 Velocity { get; set; } = Vector3.zero;
	public Vector3 Direction { get { return Velocity.normalized; } }

	Vector3 acceleration = Vector3.zero;

    void Update()
    {
		acceleration = Vector3.zero;

		// update acceleration with behavior force
		GameObject[] gameObjects = perception.GetGameObjects();
		Vector3 force = behavior.Execute(gameObjects);
		acceleration += force;

		// update velocity and position
		Velocity += acceleration * Time.deltaTime;
		Vector3.ClampMagnitude(Velocity, maxSpeed);
		transform.position += Velocity * Time.deltaTime;

		if (Velocity.magnitude > 0.1f)
		{
			transform.rotation = Quaternion.LookRotation(Velocity);
		}

		transform.position = Utilities.Wrap(transform.position, new Vector3(-10, -10, -10), new Vector3(10, 10, 10));
    }
}

