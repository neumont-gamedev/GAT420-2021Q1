using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCondition : Condition
{
	bool result;

	public override bool IsTrue()
	{
		if ((prevFrame + 1) != DecisionTree.frame)
		{
			result = (Random.Range(0, 2) == 1);
		}

		prevFrame = DecisionTree.frame;

		return result;
	}

}
