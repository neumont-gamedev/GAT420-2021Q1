using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSearchNode : SearchNode
{
	[SerializeField] WaypointSearchNode m_nextWaypoint = null;

	public WaypointSearchNode nextWaypoint { get { return m_nextWaypoint; } set { m_nextWaypoint = value; } }

	private void OnTriggerEnter(Collider other)
	{
		//StateAgent agent = other.GetComponent<StateAgent>();
		//if (agent && (agent.waypoint == this || agent.waypoint == null))
		//{
		//	agent.waypoint = m_nextWaypoint;
		//}
	}
}
