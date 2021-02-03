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

		// create priority queue
		SimplePriorityQueue<GraphNode> nodes = new SimplePriorityQueue<GraphNode>();

		// set source cost to 0
		source.Cost = 0;
		// enqueue source node with the source cost as the priority
		nodes.Enqueue(source, source.Cost);

		// set the current number of steps
		int steps = 0;
		while (!found && nodes.Count > 0 && steps++ < maxSteps)
		{
			// dequeue node
			GraphNode node = nodes.Dequeue();

			// check if node is the destination node
			if (node == destination)
			{
				// set found to true
				found = true;
				// continue, do not execute the rest of this loop
				continue;
			}

			// search node edges for unvisited node
			foreach (GraphNode.Edge edge in node.Edges)
			{
				// calculate cost to nodeB = node cost + edge distance (nodeA to nodeB)
				float cost = node.Cost + Vector3.Distance(edge.nodeA.transform.position, edge.nodeB.transform.position);
				// if cost < nodeB cost, add to priority queue
				if (cost < edge.nodeB.Cost)
				{
					// set nodeB cost to cost
					edge.nodeB.Cost = cost;
					// set nodeB parent to node
					edge.nodeB.Parent = node;
					// enqueue without duplicates nodeB with cost as priority
					nodes.EnqueueWithoutDuplicates(edge.nodeB, edge.nodeB.Cost);
				}
			}
		}

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
			while (nodes.Count > 0)
			{
				path.Add(nodes.Dequeue());
			}
		}

		return found;
	}
}
