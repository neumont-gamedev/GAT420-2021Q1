using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPerception : Perception
{
	public Transform raycastTransform;
	[Range(1, 40)] public float distance = 1;
	[Range(0, 90)] public float angle = 0;
	public int numRaycast = 1;

	public override GameObject[] GetGameObjects()
	{
		List<GameObject> gameObjects = new List<GameObject>();

		float rayDistance = distance;

		Ray ray = new Ray(raycastTransform.position, raycastTransform.forward);
		if (Physics.Raycast(ray, out RaycastHit raycastHit, rayDistance))
		{
			rayDistance = raycastHit.distance;
			gameObjects.Add(raycastHit.collider.gameObject);
		}
		Debug.DrawRay(ray.origin, ray.direction * rayDistance);

		return gameObjects.ToArray();
	}
}
