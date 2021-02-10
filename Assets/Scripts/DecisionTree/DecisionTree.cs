using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionTree : MonoBehaviour
{
    public DecisionNode root;

    void Update()
    {
        // reset all nodes
        DecisionNode[] nodes = FindObjectsOfType<DecisionNode>();
        foreach (var node in nodes) node.State = DecisionNode.eState.Inactive;

        // execute decision tree
        root.Execute();
    }
}
