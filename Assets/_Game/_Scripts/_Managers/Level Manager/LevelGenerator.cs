using UnityEngine;

public class LevelGenerator : MonoBehaviour, IGenerateLevel
{
    public Vector3 SpawnPosition { get; private set; }
    public void SpawnLevel(GameObject levelPrefab)
    {
        levelPrefab.transform.position = SpawnPosition;
        if (!levelPrefab.activeInHierarchy) levelPrefab.SetActive(true);
        SpawnPosition += levelPrefab.GetComponent<LevelOffset>().OffSet;
    }
    public void DestroyLevel(GameObject levelPrefab)
    {
        if (levelPrefab.activeInHierarchy) levelPrefab.SetActive(false);
    }
}
