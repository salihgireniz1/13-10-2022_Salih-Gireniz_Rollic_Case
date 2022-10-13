using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour, IBall
{
    public int FillAmount => fillAmount;
    [SerializeField]
    int fillAmount;
}
