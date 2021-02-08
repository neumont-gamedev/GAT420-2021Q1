using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMovement : Movement
{
	public override Vector3 Velocity { get { return navMeshAgent.velocity; } set { navMeshAgent.velocity = value; } }
	public override Vector3 Acceleration { get; set; }
	public override Vector3 Direction { get { return Velocity.normalized; } }

	NavMeshAgent navMeshAgent;

	private void Start()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	public void Update()
	{
		navMeshAgent.speed = speedMax;
		navMeshAgent.angularSpeed = rotationRate;
	}

	public override void ApplyForce(Vector3 force)
	{
		//
	}

	public override void MoveTowards(Vector3 target)
	{
		navMeshAgent.SetDestination(target);
	}

	public override void Stop()
	{
		navMeshAgent.isStopped = true;
	}
}
