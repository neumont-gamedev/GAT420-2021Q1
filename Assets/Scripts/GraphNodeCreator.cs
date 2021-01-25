using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNodeCreator : MonoBehaviour
{
    public GameObject nodeGameObject;
    public LayerMask layerMask;
    public float range = 1;
    public GraphNodeSelector graphNodeSelector;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && graphNodeSelector.IsActive == false)
		{
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, layerMask))
			{
                GameObject gameObject = Instantiate(nodeGameObject, hitInfo.point, Quaternion.identity, transform);
                GraphNode graphNode = gameObject.GetComponent<GraphNode>();

                GraphNode[] graphNodes = GraphNode.GetGraphNodes();
                GraphNode.ClearNodeLinks(graphNodes);
                GraphNode.LinkNodes(graphNodes, range);
			}
		}
    }

    public void ClearNodes()
	{
		// get all children graph nodes
		GraphNode[] graphNodes = GraphNode.GetGraphNodes();
		foreach (GraphNode graphNode in graphNodes)
		{
			Destroy(graphNode.gameObject);
		}
	}
}
