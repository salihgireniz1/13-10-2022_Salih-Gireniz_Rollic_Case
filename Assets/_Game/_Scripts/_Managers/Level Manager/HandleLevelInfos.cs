using UnityEngine;

public class HandleLevelInfos : MonoBehaviour, IHandleLevelInfo
{
    #region Properties
    public LevelInfoAsset LevelInfoAsset
    {
        get => levelInfoAsset;
    }
    #endregion

    #region Variables
    [SerializeField] LevelInfoAsset levelInfoAsset;
    #endregion

    #region Methods
    public LevelInfo GetLevelInfo(int levelIndex)
    {
        // Member of the 'levelInfos' list will be one minus of the levelIndex.
        int infoIndex = levelIndex - 1;
        if (levelInfoAsset == null)
        {
            throw new System.Exception($"Please insert a 'LevelInfoAsset' scriptable object to {this} class!");
        }
        else
        {
            if (levelInfoAsset.levelInfos.Count == 0)
            {
                throw new System.Exception($"The 'LevelInfos' list in {levelInfoAsset} is empty! Add at least one member to the list!");
            }
            if (infoIndex >= levelInfoAsset.levelInfos.Count)
            {
                int randomLevelInfoIndex = Random.Range(0, levelInfoAsset.levelInfos.Count);
                return LevelInfoAsset.levelInfos[randomLevelInfoIndex];
            }
            return LevelInfoAsset.levelInfos[infoIndex];
        }
    }
    #endregion
}