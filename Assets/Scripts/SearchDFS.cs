using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class SearchDFS
{
	public static bool Build(GraphNode source, GraphNode destination, out List<GraphNode> path)
	{
		bool found = false;
		Stack<GraphNode> nodes = new Stack<GraphNode>();
		nodes.Push(source);

		while (!found && nodes.Count > 0)
		{
			GraphNode node = nodes.Peek();
			node.Visited = true;

			bool forward = false;
			foreach (GraphNode.Edge edge in node.Edges)
			{
				if (edge.nodeB.Visited == false)
				{
					nodes.Push(edge.nodeB);
					forward = true;
					if (edge.nodeB == destination)
					{
						found = true;
					}
					break;
				}
			}

			if (forward == false)
			{
				nodes.Pop();
			}
		}

		path = new List<GraphNode>();
		path = nodes.ToList();
		path.Reverse();

		return found;
	}
}
