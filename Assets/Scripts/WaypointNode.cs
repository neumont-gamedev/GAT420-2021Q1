using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNode : SearchNode
{
	public WaypointNode nextWaypoint = null;

	private void OnTriggerEnter(Collider other)
	{
		SearchAgent agent = other.GetComponent<SearchAgent>();
		if (agent && (agent.Waypoint == this || agent.Waypoint == null))
		{
			agent.Waypoint = nextWaypoint;
		}
	}
}
