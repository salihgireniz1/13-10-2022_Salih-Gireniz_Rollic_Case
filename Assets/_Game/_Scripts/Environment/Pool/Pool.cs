using TMPro;
using UnityEngine;

public class Pool
{
    public int PoolSize;
    public int FilledAmount;
    public Pool(int size)
    {
        PoolSize = size;
        FilledAmount = 0;
    }
}
