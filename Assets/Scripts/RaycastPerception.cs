using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPerception : Perception
{
	public Transform raycastTransform;
	[Range(1, 40)] public float distance = 1;
	[Range(0, 90)] public float angle = 0;
	public int numRaycast = 1;

	private void OnValidate()
	{
		if (numRaycast == 0)
		{
			Debug.Log("Error: num raycast is invalid");
		}
	}

	public override GameObject[] GetGameObjects()
	{
		List<GameObject> gameObjects = new List<GameObject>();

		float angleOffset = angle / ((numRaycast - 1) * 0.5f);
		for (int i = 0; i < numRaycast; i++)
		{
			float rayDistance = distance;

			Quaternion rotation = Quaternion.AngleAxis(-angle + (angleOffset * i), Vector3.up);
			//Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
			Vector3 forward = rotation * raycastTransform.forward;
			Ray ray = new Ray(raycastTransform.position, forward);
			if (Physics.Raycast(ray, out RaycastHit raycastHit, rayDistance))
			{
				rayDistance = raycastHit.distance;
				gameObjects.Add(raycastHit.collider.gameObject);
			}
			Debug.DrawRay(ray.origin, ray.direction * rayDistance);
		}

		return gameObjects.ToArray();
	}
}
