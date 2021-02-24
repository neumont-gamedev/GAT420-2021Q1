using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityAgentGoal : MonoBehaviour
{
    public string id;
    public AnimationCurve curve = null;
    public float input = 1.0f;
    public float decay = 0.0f;

    public float utility { get { return Mathf.Clamp01(curve.Evaluate(input)); } }
    
    void Update()
    {
        input = input - (decay * Time.deltaTime);
        input = Mathf.Clamp(input, -1, 1);
    }

    public float GetUtilityFromParameter(float parameter)
	{
        return Mathf.Clamp01(curve.Evaluate(parameter));
    }
}
