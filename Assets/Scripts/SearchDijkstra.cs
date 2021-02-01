using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Priority_Queue;

public static class SearchDijkstra
{
	public static bool Search(GraphNode source, GraphNode destination, ref List<GraphNode> path, int maxSteps)
	{
		bool found = false;

		// dijkstra algorithm
		SimplePriorityQueue<GraphNode> nodes = new SimplePriorityQueue<GraphNode>();
		source.Cost = 0;
		nodes.Enqueue(source, source.Cost);

		// create a list of graph nodes (path)
		path = new List<GraphNode>();
		// if found is true
		if (found)
		{
			// set node to destination
			GraphNode node = destination;
			// while node not null
			while (node != null)
			{
				// add node to list path
				path.Add(node);
				// set node to node parent
				node = node.Parent;
			}

			// reverse path
			path.Reverse();
		}
		else
		{
			//
		}

		return found;
	}
}
