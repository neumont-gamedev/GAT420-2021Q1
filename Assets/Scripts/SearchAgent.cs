using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SearchAgent : MonoBehaviour
{
	public WaypointNode Waypoint { get; set; }

	private void Update()
	{
		if (Waypoint != null)
		{
			Vector3 direction = Waypoint.transform.position - transform.position;
			transform.position += direction.normalized * Time.deltaTime;
		}
	}
}
