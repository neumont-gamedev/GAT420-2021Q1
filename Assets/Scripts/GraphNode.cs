using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNode : SearchNode
{
    public enum eType
    {
        Default,
        Source,
        Destination,
        Path,
        Visited
    }

    Color[] colors =
{
        Color.white,    // default
        Color.green,    // source
        Color.red,      // destination
        Color.yellow,   // path
        Color.blue      // visited
    };

    public struct Edge
	{
        public GraphNode nodeA;
        public GraphNode nodeB;

        public static float Distance(Edge edge)
        {
            return (edge.nodeA.transform.position - edge.nodeB.transform.position).magnitude;
        }
    }

    public List<Edge> Edges { get; set; } = new List<Edge>();
    public eType Type { get; set; } = eType.Default;
    public bool Visited { get; set; } = false;

    void Update()
    {
        GetComponent<Renderer>().material.color = colors[(int)Type];

        foreach (Edge edge in Edges)
        {
            Debug.DrawLine(edge.nodeA.transform.position, edge.nodeB.transform.position);
        }
    }

    public static GraphNode[] GetGraphNodes()
	{
        GraphNode[] graphNodes = GameObject.FindObjectsOfType<GraphNode>();

        return graphNodes;
    }

    public static GraphNode GetGraphNode(GraphNode[] graphNodes, GraphNode.eType type)
    {
        GraphNode graphNode = null;

        foreach (GraphNode node in graphNodes)
        {
            if (node.Type == type)
            {
                graphNode = node;
                break;
            }
        }

        return graphNode;
    }

    public static void LinkNodes(GraphNode[] graphNodes, float range)
    {
        foreach (GraphNode graphNode in graphNodes)
        {
            LinkNode(graphNode, range);
        }
    }

    public static void LinkNode(GraphNode node, float range)
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
            }
        }
    }

    public static void ResetGraphNodes(GraphNode[] graphNodes)
    {
        foreach (GraphNode graphNode in graphNodes)
        {
            graphNode.Edges.Clear();
            graphNode.Type = eType.Default;
            graphNode.Visited = false;
        }
    }

    public static void ClearNodeLinks(GraphNode[] graphNodes)
    {
        foreach (GraphNode graphNode in graphNodes)
        {
            graphNode.Edges.Clear();
        }
    }

    public static void ClearNodeType(GraphNode[] graphNodes, GraphNode.eType type)
    {
        foreach (GraphNode graphNode in graphNodes)
        {
            if (graphNode.Type == type)
            {
                graphNode.Type = GraphNode.eType.Default;
            }
        }
    }
}
