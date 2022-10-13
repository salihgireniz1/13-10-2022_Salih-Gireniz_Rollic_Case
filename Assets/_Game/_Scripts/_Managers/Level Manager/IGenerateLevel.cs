using UnityEngine;

public interface IGenerateLevel
{
    /// <summary>
    /// Start position of the prefab.
    /// </summary>
    public Vector3 SpawnPosition { get; }

    /// <summary>
    /// Spawn a level object.
    /// </summary>
    /// <param name="levelPrefab">Object to spawn.</param>
    void SpawnLevel(GameObject levelPrefab);

    /// <summary>
    /// Destroy a level object.
    /// </summary>
    /// <param name="levelPrefab">Object to destroy.</param>
    void DestroyLevel(GameObject levelPrefab);
}