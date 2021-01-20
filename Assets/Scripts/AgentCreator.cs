using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentCreator : MonoBehaviour
{
    [Range(0, 5)] public float radius = 1;
    public AutonomousAgent[] agents;
    public LayerMask layerMask;

    void Update()
    {
        if (Input.GetMouseButton(0))
		{
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, layerMask))
			{
                Vector3 offset = Random.insideUnitSphere * radius;

                Instantiate(agents[0], hitInfo.point + offset, Quaternion.identity);
			}
		}
    }
}
