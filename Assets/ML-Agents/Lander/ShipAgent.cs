using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class ShipAgent : Unity.MLAgents.Agent
{
	public float forceMultiplier = 10;
	public float gravityScale = 5;
	public float landingThreshold = 1;

	Rigidbody rb;
	Vector3 startPosition;
	Vector3 velocity;
	float distance;

    void Start()
    {
		startPosition = transform.position;

		rb = GetComponent<Rigidbody>();
		Physics.gravity = Vector3.down * gravityScale;
    }

	public override void OnEpisodeBegin()
	{
		base.OnEpisodeBegin();

		transform.position = startPosition + new Vector3(0, Random.Range(-2f, 2f), 0);
		transform.rotation = Quaternion.identity;

		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
	}

	public override void CollectObservations(VectorSensor sensor)
	{
		base.CollectObservations(sensor);

		sensor.AddObservation(velocity.y);
		sensor.AddObservation(distance);
	}

	public override void OnActionReceived(float[] vectorAction)
	{
		base.OnActionReceived(vectorAction);

		int action = Mathf.FloorToInt(vectorAction[0]);
		if (action == 1)
		{
			rb.AddForce(Vector3.up * forceMultiplier, ForceMode.Force);
		}

		AddReward(-1.0f / MaxStep);

		velocity = rb.velocity;
		Physics.Raycast(transform.localPosition, Vector3.down, out RaycastHit raycastHit);
		distance = raycastHit.distance;
	}

	public override void Heuristic(float[] actionsOut)
	{
		actionsOut[0] = 0;
		if (Input.GetKey(KeyCode.Space))
		{
			actionsOut[0] = 1;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("ground"))
		{
			if (velocity.y >= -landingThreshold)
			{
				SetReward(1);
			}
			else
			{
				SetReward(0);
			}
			EndEpisode();
		}

		if (collision.collider.CompareTag("block"))
		{
			SetReward(-1);
			EndEpisode();
		}
	}
}
