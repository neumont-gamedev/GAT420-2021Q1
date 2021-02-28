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
    UtilityAgentGoal[] goals;
    UtilityObject utilityObject;

    void Start()
    {
        goals = GetComponentsInChildren<UtilityAgentGoal>();
    }
        
    void Update()
    {
        animator.SetFloat("Speed", movement.Velocity.magnitude);

		switch (state)
		{
			case eState.Idle:
				break;
			case eState.ActionStart:
				StartCoroutine(ExecuteUtilityObject(utilityObject));
				break;
			case eState.ActionInProgress:
				break;
			case eState.ActionComplete:
				StopCoroutine("ExecuteUtilityObject");
				// update agent scores
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

		// walk to utility object
		movement.MoveTowards(utilityObject.location.position);
		while (Vector3.Distance(transform.position, utilityObject.location.position) > 0.1f)
		{
			yield return null;
		}

		// perform utiltiy object action
		animator.SetTrigger(utilityObject.animationID);
		utilityObject.actionFX.SetActive(true);

		// wait for action duration
		yield return new WaitForSeconds(utilityObject.duration);

		// return to idle
		animator.SetTrigger("Idle");
		utilityObject.actionFX.SetActive(false);

		// add utility score
		UpdateUtilityObjectScore(utilityObject);

		state = eState.ActionComplete;

		yield return null;
	}

	public void StartUtilityObject(UtilityObject utilityObject)
	{
		if (state == eState.Idle)
		{
			state = eState.ActionStart;
			this.utilityObject = utilityObject;
		}
	}

	void UpdateUtilityObjectScore(UtilityObject utilityObject)
	{
		foreach (var goal in goals)
		{
			float score = utilityObject.GetScore(goal.id);
			goal.input += score;
		}
	}
}
