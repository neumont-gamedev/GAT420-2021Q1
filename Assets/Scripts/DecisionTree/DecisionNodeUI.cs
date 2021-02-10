using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionNodeUI : MonoBehaviour
{
    public Image nodeImage;
	public Image trueImage;
	public Image falseImage;
    public Color activeColor;
	public Color inactiveColor;

    public DecisionNode decisionNode;

    void LateUpdate()
    {
		switch (decisionNode.State)
		{
			case DecisionNode.eState.Inactive:
				nodeImage.color = inactiveColor;
				trueImage.enabled = false;
				falseImage.enabled = false;
				break;
			case DecisionNode.eState.ConditionTrue:
				nodeImage.color = activeColor;
				trueImage.enabled = true;
				falseImage.enabled = false;
				break;
			case DecisionNode.eState.ConditionFalse:
				nodeImage.color = activeColor;
				trueImage.enabled = false;
				falseImage.enabled = true;
				break;
			default:
				break;
		}
	}
}
