using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTextHandler : MonoBehaviour
{
    TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        text.text = LevelManager.Instance.GetCurrentLevel().ToString();
    }
}
