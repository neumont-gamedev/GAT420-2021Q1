using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DebugLine : MonoBehaviour
{
    [Range(0.1f, 2.0f)] public float width = 1;
    public Color color = Color.white;

    LineRenderer lineRenderer;
    int index = 0;

	private void Start()
	{
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
    }

	void Update()
    {
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
    }

	public void Reset()
	{
        index = 0;
        lineRenderer.positionCount = 0;
    }

	public void Add(Vector3 position)
	{
        lineRenderer.positionCount = index + 1;
        lineRenderer.SetPosition(index++, position);
    }
}
