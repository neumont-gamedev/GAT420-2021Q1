using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchBuilder : MonoBehaviour
{
    List<GraphNode> path = null;

    public void Build()
	{
        GraphNode source = GraphNode.GetGraphNode(GraphNode.GetGraphNodes(), GraphNode.eType.Source);
        GraphNode destination = GraphNode.GetGraphNode(GraphNode.GetGraphNodes(), GraphNode.eType.Destination);

        if (source == null || destination == null) return;

        SearchDFS.Build(source, destination, out path);
        foreach (GraphNode graphNode in path)
		{
            if (graphNode.Type == GraphNode.eType.Default)
			{
                graphNode.Type = GraphNode.eType.Path;
			}
		}
    }
}
