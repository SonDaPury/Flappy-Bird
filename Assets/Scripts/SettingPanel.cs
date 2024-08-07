using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject flyAudioGameObject;

    [SerializeField]
    private GameObject swooshingAudioGameObject;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject gameOver;

    [SerializeField]
    private GameObject settingPanel;

    public bool isSettingPanelOpen = false;
    public bool isSoundOn = true;
    public GameObject[] allObjects;

    void Start()
    {
        allObjects = FindObjectsOfType<GameObject>(true);

        foreach (GameObject obj in allObjects)
        {
            if (obj.CompareTag("SettingPanel"))
            {
                settingPanel = obj;
            }
        }
    }

    public void ToggleSettingPanel()
    {
        Time.timeScale = 0f;
        settingPanel.SetActive(true);
        isSettingPanelOpen = true;
    }

    public void ContinueGame()
    {
        if (!gameOver.activeSelf)
        {
            Time.timeScale = 1f;
        }
        isSettingPanelOpen = false;
        settingPanel.SetActive(false);
    }

    public void ToggleSound()
    {
        if (flyAudioGameObject.activeSelf)
        {
            isSoundOn = false;
            PlayerPrefs.SetInt("SoundOn", 0);
        }
        else
        {
            isSoundOn = true;
            PlayerPrefs.SetInt("SoundOn", 1);
        }
        PlayerPrefs.Save();
        ContinueGame();
    }
}
