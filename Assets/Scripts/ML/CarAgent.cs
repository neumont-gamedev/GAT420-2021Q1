using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class CarAgent : Unity.MLAgents.Agent
{
    public float forceMultiplier = 10;
	public CarTarget target;

	Rigidbody2D rb;

    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
    }

	public override void OnEpisodeBegin()
	{
		base.OnEpisodeBegin();

		rb.velocity = Vector2.zero;
		transform.localPosition = new Vector2(0, -200);

		//target.Reset();
		//target.localPosition = new Vector2(Random.Range(-60.0f, 60.0f), 0);
	}

	public override void CollectObservations(VectorSensor sensor)
	{
		base.CollectObservations(sensor);

		sensor.AddObservation(transform.localPosition);
		sensor.AddObservation(target.transform.localPosition);

		sensor.AddObservation(rb.velocity.x);
	}

	public override void OnActionReceived(float[] vectorAction)
	{
		base.OnActionReceived(vectorAction);

		Vector2 force = Vector2.zero;
		force.x = vectorAction[0];
		rb.AddForce(force * forceMultiplier);

		SetReward(0.01f);
	}

	public override void Heuristic(float[] actionsOut)
	{
		base.Heuristic(actionsOut);

		actionsOut[0] = Input.GetAxis("Horizontal");
	}

	//public void OnCollisionEnter(Collision collision)
	//{
	//	if (collision.collider.CompareTag("Target"))
	//	{
	//		Debug.Log("target collision");
	//		SetReward(-1);
	//		EndEpisode();
	//	}
	//}

	//public void OnCollisionExit(Collision collision)
	//{
	//	if (collision.collider.CompareTag("World"))
	//	{
	//		Debug.Log("world exit collision");
	//		SetReward(-1);
	//		EndEpisode();
	//	}
	//}
}
