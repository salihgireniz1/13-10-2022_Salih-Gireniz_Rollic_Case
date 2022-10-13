using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    #region Variables
    [Header("Panels"), Space]
    public GameObject tapToStartPanel;
    public GameObject inGamePanel;
    public GameObject nextLevelPanel;
    public GameObject retryPanel;

    [Header("Texts"), Space]
    public TextMeshProUGUI levelText;

    private GameObject currentPanel;
    #endregion
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);

        currentPanel = null;
    }
    public void SwitchPanel(GameObject newPanel)
    {
        if (currentPanel != null && currentPanel.activeInHierarchy)
        {
            currentPanel.SetActive(false);
        }
        if (newPanel != null)
        {
            currentPanel = newPanel;
            currentPanel.SetActive(true);
        }
    }
    public void NextLevelHandler()
    {
        GameManager.Instance.SwitchGameState(GameManager.Instance.stateMachine.readyState);
    }
    public void ReplayHandler()
    {
        LoadManager.ReloadActiveScene();
    }
    public void UpdateLevelText(int level)
    {
        levelText.text = level.ToString();
    }
}
