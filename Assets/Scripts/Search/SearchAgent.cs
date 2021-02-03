using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchAgent : Agent
{
    public SearchPath searchPath;

	void Update()
    {
        searchPath.Move(movement);
    }
}
