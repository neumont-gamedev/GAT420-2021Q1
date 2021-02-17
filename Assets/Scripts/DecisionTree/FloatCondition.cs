using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatCondition : Condition
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

	public float value { get; set; }
	public string valueString
	{
		set
		{
			float.TryParse(value, out float v);
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
				isTrue = (parameter == value);
				break;
			case eCompare.Greater:
				isTrue = (parameter > value);
				break;
			case eCompare.Less:
				isTrue = (parameter < value);
				break;
			default:
				break;
		}

		return isTrue;
	}
}
