using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityAgentGoal : MonoBehaviour
{
    public string id;
    public AnimationCurve curve;
    public float input = 1;
    public float decay = 0;

    public float utility { get { return curve.Evaluate(input); } }

    void Update()
    {
        input = input - (decay * Time.deltaTime);
        input = Mathf.Clamp(input, -1, 1);
    }

    public float GetUtilityFromValue(float value)
	{
        return curve.Evaluate(value);
    }
}
