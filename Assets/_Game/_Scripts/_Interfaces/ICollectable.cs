using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
    int Amount { get; }
    void Collect();
}
