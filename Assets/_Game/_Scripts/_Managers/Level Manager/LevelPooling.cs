using System.Collections.Generic;
using UnityEngine;

public static class LevelPooling
{
    public static List<GameObject> GeneratePoolOfLevels(int lastLevel, IHandleLevelInfo levelInfoHandler, int poolingSize, Transform pooledObjectHolder = null)
    {
        List<GameObject> tmpList = new List<GameObject>();
        for (int i = 0; i < poolingSize; i++)
        {
            int levelIndex = lastLevel + i;
            LevelInfo tmpLevelInfo = levelInfoHandler.GetLevelInfo(levelIndex);
            GeneratePoolMember(tmpList, tmpLevelInfo, pooledObjectHolder);
        }
        return tmpList;
    }
    public static void GeneratePoolMember(List<GameObject> pool, LevelInfo info, Transform pooledObjectHolder)
    {
        var tmp = MonoBehaviour.Instantiate(info.levelPrefab, pooledObjectHolder);
        tmp.SetActive(false);
        LevelOffset tmpOffset = tmp.AddComponent(typeof(LevelOffset)) as LevelOffset;
        tmpOffset.OffSet = new Vector3(0, 0, info.unitLength);
        pool.Add(tmp);

        // This has nothing to do with object pooling.
        // It is all about the pool that we need to fill with balls
        // at each level. We are going to initialize the pool settings
        // of level for pass amount, the text on pool(such like "0/30") etc.
        tmp.GetComponentInChildren<PoolManager>().InitializeGroundPool(info);
    }
}
