using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNode : SearchNode
{
    public enum eType
    {
        DEFAULT,
        SOURCE,
        DESTINATION,
        PATH,
        VISITED
    }

    public struct Edge
    {
        public GraphNode nodeA;
        public GraphNode nodeB;
    }

    public List<Edge> Edges { get; set; } = new List<Edge>();
    public eType Type { get; set; } = eType.DEFAULT;
    public bool Visited { get; set; } = false;
    public GraphNode Parent { get; set; } = null;

    Color[] colors =
    {
        Color.magenta,
        Color.green,
        Color.red,
        Color.yellow,
        Color.blue
    };

    void Update()
    {
        GetComponent<Renderer>().material.color = colors[(int)Type];
        foreach (GraphNode.Edge edge in Edges)
        {
            Debug.DrawLine(edge.nodeA.transform.position, edge.nodeB.transform.position);
        }
    }
}
