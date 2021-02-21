using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntCondition : Condition
{
	public enum eCompare
	{
		Equal,
		Greater,
		Less
	}

	public eCompare compare { get; set; } = eCompare.Equal;
	public int compareInt
	{
		set
		{
			compare = (eCompare)value;
		}
	}

	public int value { get; set; }
	public string valueString
	{
		set
		{
			int.TryParse(value, out int v);
			this.value = v;
		}
	}

	public float parameter { get; set; }

	public override bool IsTrue()
	{
		bool isTrue = false;

		switch (compare)
		{
			case eCompare.Equal:
				isTrue = ((int)parameter == value);
				break;
			case eCompare.Greater:
				isTrue = ((int)parameter > value);
				break;
			case eCompare.Less:
				isTrue = ((int)parameter < value);
				break;
			default:
				break;
		}

		return isTrue;
	}
}
