using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityAgent : Agent
{
    public enum eState
	{
        Idle,
        ActionStart,
        ActionInProgress,
        ActionComplete
	}
    eState state = eState.Idle;

	public float happiness = 0;

    UtilityAgentGoal[] goals;
    UtilityObject utilityObject;

    void Start()
    {
        goals = GetComponentsInChildren<UtilityAgentGoal>();
    }
        
    void Update()
    {
        animator.SetFloat("Speed", movement.Velocity.magnitude);

		// calculate happiness
		happiness = 0;
		foreach (var goal in goals)
		{
			happiness = happiness + goal.utility;
		}
		happiness = happiness / (float)goals.Length;

		// update state
		switch (state)
		{
			case eState.Idle:
				//
				break;
			case eState.ActionStart:
				StartCoroutine(ExecuteUtilityObject(utilityObject));
				break;
			case eState.ActionInProgress:
				//
				break;
			case eState.ActionComplete:
				StopCoroutine("ExecuteUtilityObject");
				
				ExecuteUtilityObjectScore(utilityObject);
				utilityObject = null;
				state = eState.Idle;
				break;
			default:
				break;
		}
	}

	IEnumerator ExecuteUtilityObject(UtilityObject utilityObject)
	{
		state = eState.ActionInProgress;

		// walk to object location
		movement.MoveTowards(utilityObject.location.position);
		while (Vector3.Distance(transform.position, utilityObject.location.position) > 0.1f)
		{
			yield return null;
		}
		yield return new WaitForSeconds(0.1f);

		Transform source = transform;
		Transform destination = utilityObject.actionLocation;

		// move to object action location
		float time = 1.0f;
		while (time > 0.0f)
		{
			time = time - Time.deltaTime;
			//time = Mathf.Max(time, 0.0f);
			//TransformLerp(t1, action.actionLocation.transform, transform, 1.0f - (time / 1.0f));

			yield return null;
		}
		yield return new WaitForSeconds(0.1f);

		// start action animation
		animator.SetTrigger(utilityObject.animationID);
		time = utilityObject.duration;
		while (time > 0.0f)
		{
			time = time - Time.deltaTime;
			yield return null;
		}
		animator.SetTrigger("Idle");

		// move to action location
		time = 1.0f;
		while (time > 0.0f)
		{
			time = time - Time.deltaTime;
			//time = Mathf.Max(time, 0.0f);
			//TransformLerp(t1, action.location.transform, transform, 1.0f - (time / 1.0f));

			yield return null;
		}

		state = eState.ActionComplete;

		yield return null;
	}

	public void StartUtilityObject(UtilityObject utilityObject)
	{
        if (state == eState.Idle)
		{
            this.utilityObject = utilityObject;
            state = eState.ActionStart;
		}
	}

	void ExecuteUtilityObjectScore(UtilityObject utilityObject)
	{
		foreach (var goal in goals)
		{
			float score = utilityObject.GetScore(goal.id);
			goal.input += score;
		}
	}
}
