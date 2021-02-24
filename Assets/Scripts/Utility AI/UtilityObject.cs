using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityObject : MonoBehaviour
{
    public string id;
    public string animationID;
    public float duration;
    public Transform location;
    public Transform actionLocation;

	public UtilityScore[] scores { get; set; }

	private void Start()
	{
		scores = GetComponentsInChildren<UtilityScore>();
	}

	public float GetScore(string id)
	{
		float change = 0;
		foreach (var score in scores)
		{
			if (score.id == id) change += score.change;
		}

		return change;
	}

	public bool HasScore(string id)
	{
		foreach (var score in scores)
		{
			if (score.id == id) return true;
		}

		return false;
	}
}
