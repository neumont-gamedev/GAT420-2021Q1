using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNodeSelector : MonoBehaviour
{
    public LayerMask layerMask;
    public GameObject selection;

    public bool IsActive { get { return selection.activeSelf; } }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, layerMask))
        {
            GraphNode node = hitInfo.collider.gameObject.GetComponent<GraphNode>();
            if (node)
			{
                selection.SetActive(true);
                selection.transform.position = node.gameObject.transform.position;

                if (Input.GetMouseButtonDown(0))
                {
                    if (Input.GetKey(KeyCode.S))
				    {
                        GraphNode.ClearNodeType(GraphNode.GetGraphNodes(), GraphNode.eType.Source);
                        node.Type = GraphNode.eType.Source;
                    }

                    if (Input.GetKey(KeyCode.D))
                    {
                        GraphNode.ClearNodeType(GraphNode.GetGraphNodes(), GraphNode.eType.Destination);
                        node.Type = GraphNode.eType.Destination;
                    }
                }
            }
        }
        else
		{
            selection.SetActive(false);
		}
    }





}
