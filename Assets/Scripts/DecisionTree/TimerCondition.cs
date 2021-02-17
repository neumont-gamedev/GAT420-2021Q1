using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCondition : Condition
{
	public float value { get; set; }
	
	float timer;
	bool result;

	public override bool IsTrue()
	{
		timer -= Time.deltaTime;
		if (timer <= 0)
		{
			timer = Random.Range(0, value);
			result = (Random.Range(0, 2) == 1);
		}

		return result;
	}

}
