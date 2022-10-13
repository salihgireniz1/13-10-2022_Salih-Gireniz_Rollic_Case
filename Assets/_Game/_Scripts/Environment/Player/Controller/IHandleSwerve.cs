using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHandleSwerve
{
    bool CanSwerve { get; set; }
    float SwerveSpeed { get; set; }
    Vector3 SwerveAmount();
}
