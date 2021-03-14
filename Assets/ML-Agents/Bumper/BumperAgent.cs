using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class BumperAgent : Unity.MLAgents.Agent
{
    public float forceMultiplier = 10;
	public float turnMultiplier = 10;
	public GameObject goal;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

	public override void OnEpisodeBegin()
	{
		base.OnEpisodeBegin();

		goal.transform.localPosition = new Vector3(Random.Range(-20, 20), 1, Random.Range(-20, 20));

		transform.localPosition = new Vector3(Random.Range(-20, 20), 0.5f, Random.Range(-20, 20));
		transform.rotation = Quaternion.AngleAxis(Random.value * 360, Vector3.up);

		rb.velocity = Vector3.zero;
	}

	public override void OnActionReceived(float[] vectorAction)
	{
		base.OnActionReceived(vectorAction);

		float force = vectorAction[0] * forceMultiplier;
		rb.AddRelativeForce(Vector3.forward * force, ForceMode.VelocityChange);

		float turn = vectorAction[1] * turnMultiplier;
		transform.rotation = transform.rotation * Quaternion.AngleAxis(turn * Time.deltaTime, Vector3.up);

		AddReward(-1f / MaxStep);
	}

	public override void Heuristic(float[] actionsOut)
	{
		actionsOut[0] = Input.GetAxis("Vertical");
		actionsOut[1] = Input.GetAxis("Horizontal");
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Obstacle"))
		{
			AddReward(-1);
			EndEpisode();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Goal"))
		{
			SetReward(5);
			EndEpisode();
		}
	}
}
