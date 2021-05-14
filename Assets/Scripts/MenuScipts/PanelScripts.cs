using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PanelScripts : MonoBehaviour
{
    [SerializeField]
    private GameObject HowToPlayPanel, SettingsPanel;
    bool HowToPlayPanelActivity, SettingsPanelActivity;
    void Start()
    {
        HowToPlayPanelActivity = false;
        SettingsPanelActivity = false;
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("GameLevel");
    }
    public void HowToPlayButton()
    {
        if (!HowToPlayPanelActivity)
        {
            Debug.Log("a");
            HowToPlayPanel.GetComponent<CanvasGroup>().DOFade(1f, 0.5f);
        }
        else 
        {
            Debug.Log("b");
            HowToPlayPanel.GetComponent<CanvasGroup>().DOFade(0f, 0.5f);
        }
        HowToPlayPanelActivity = !HowToPlayPanelActivity;
    }
    public void SettingsButton()
    {
        if (!SettingsPanelActivity)
        {
            Debug.Log("c");
            SettingsPanel.GetComponent<CanvasGroup>().DOFade(1f, 0.5f);
        }
        else
        {
            Debug.Log("d");
            SettingsPanel.GetComponent<CanvasGroup>().DOFade(0f, 0.5f);
        }
        SettingsPanelActivity = !SettingsPanelActivity;
    }
    public void MuteSound()
    {
        AudioListener.volume = 0;
    }

    public void UnMuteSound()
    {
        AudioListener.volume = 1;
    }
}
