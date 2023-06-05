using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider volumeSlider;

    private void Start()
    {
        settingsPanel.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void OnVolumeChanged(float value)
    {
        // 소리 조절 기능 구현
        float volume = value; // 슬라이더 값으로부터 소리 크기 조절
        // 소리 조절 로직 추가
    }

    public void GoBack()
    {
        CloseSettings();
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
