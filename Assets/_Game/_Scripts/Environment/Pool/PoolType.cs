using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Each pool has a type that determines: 
/// if it is just a step to keep moving once we fill,
/// or if it is the last pool of level so we will pass to next level.
/// </summary>
public enum PoolType
{
    StepPool,
    FinalPool
}
