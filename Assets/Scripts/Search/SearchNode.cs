using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SearchNode : MonoBehaviour
{
	public static SearchNode GetRandomSearchNode()
	{
		SearchNode[] searchNodes = GameObject.FindObjectsOfType<SearchNode>();
		return searchNodes[Random.Range(0, searchNodes.Length-1)];
	}
}
