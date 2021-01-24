using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNodeCreator : MonoBehaviour
{
    public GraphNode graphNode;
    public LayerMask layerMask;
<<<<<<< HEAD
    public float range = 1;
=======
	[Range(1, 20)] public float range = 1;
>>>>>>> dda073ab0288a198794f66ff03e2ad04599e1d36

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
<<<<<<< HEAD
		{
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, layerMask))
			{
                GraphNode node = Instantiate(graphNode, hitInfo.point, Quaternion.identity);
                LinkNode(node);
			}
		}
    }

    public void LinkNode(GraphNode node)
	{
        Collider[] colliders = Physics.OverlapSphere(node.transform.position, range);
        foreach(Collider collider in colliders)
		{
            GraphNode otherNode = collider.GetComponent<GraphNode>();
            if (otherNode != null && otherNode != node)
			{
                GraphNode.Edge edge;
                edge.nodeA = node;
                edge.nodeB = otherNode;

                node.Edges.Add(edge);
=======
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, layerMask))
            {
				GraphNode node = Instantiate(graphNode, hitInfo.point, Quaternion.identity, transform);
				LinkNode((GraphNode)node, range);
            }
        }
    }

	public void LinkNode(GraphNode node, float range)
	{
		Collider[] colliders = Physics.OverlapSphere(node.transform.position, range);
		foreach (Collider collider in colliders)
		{
			GraphNode otherNode = collider.GetComponent<GraphNode>();
			if (otherNode != null && otherNode != node)
			{
				GraphNode.Edge edge;
				edge.nodeA = node;
				edge.nodeB = otherNode;

				node.Edges.Add(edge);
>>>>>>> dda073ab0288a198794f66ff03e2ad04599e1d36
			}
		}
	}

<<<<<<< HEAD
    public void LinkNodes()
	{
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Node");
        foreach(GameObject gameObject in gameObjects)
		{
            GraphNode graphNode = gameObject.GetComponent<GraphNode>();
            if (graphNode != null)
			{
                LinkNode(graphNode);
			}
		}
	}
=======
	public void LinkNodes(float range)
	{
		// get all nodes in scene
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Node");
		foreach (GameObject gameObject in gameObjects)
		{
			GraphNode node = gameObject.GetComponent<GraphNode>();
			if (node != null)
			{
				// connect neighbor nodes within range
				LinkNode(node, range);
			}
		}
	}

	public void ClearNodes()
	{
		// get all children graph nodes
		GraphNode[] nodes = GetComponentsInChildren<GraphNode>();
		foreach (GraphNode node in nodes)
		{
			Destroy(node.gameObject);
		}
	}
>>>>>>> dda073ab0288a198794f66ff03e2ad04599e1d36
}
