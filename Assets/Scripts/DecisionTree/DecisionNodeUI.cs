using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DecisionNodeUI : MonoBehaviour
{
	public TMP_Text description;
    public Image nodeImage;
    public Image trueImage;
    public Image falseImage;
    public Color activeColor;
    public Color inactiveColor;

    public DecisionNode decisionNode;

	private void OnValidate()
	{
		if (description != null) description.text = name;
	}

	void LateUpdate()
    {
		switch (decisionNode.State)
		{
			case DecisionNode.eState.Inactive:
				nodeImage.color = inactiveColor;
				trueImage.enabled = false;
				falseImage.enabled = false;
				break;
			case DecisionNode.eState.Active:
				nodeImage.color = activeColor;
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
