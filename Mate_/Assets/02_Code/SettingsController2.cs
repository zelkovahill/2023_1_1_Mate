using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsController2 : MonoBehaviour
{
    [SerializeField]
    private Button backButton;

    public GameObject settingsPanel;
    public Button[] buttons; 
    public Button gameStartButton;
    public Button settingsButton;
    public Button quitButton;
    private bool isSettingsOpen = false;

    public Slider soundSlider; 

    private bool isGamePaused = false; 

    private void Start()
    {
        settingsPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleSettings();
        }
    }

    public void ToggleSettings()
    {
        isSettingsOpen = !isSettingsOpen;

        if (isSettingsOpen)
        {
            OpenSettings();
        }
        else
        {
            CloseSettings();
        }
    }

    private void OpenSettings()
    {

        isGamePaused = true;
        Time.timeScale = 0f; 
        settingsPanel.SetActive(true);

        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
        AudioManager.instance.EffectBgm(true);
    }

    private void CloseSettings()
    {
        isGamePaused = false;
        settingsPanel.SetActive(false);

        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
        AudioManager.instance.EffectBgm(false);
    }

    private void SetButtonsInteractable(bool interactable)
    {
        foreach (Button button in buttons)
        {
            button.interactable = interactable;
            button.gameObject.SetActive(interactable); 
        }
    }

    public void GoBack()
    {
        CloseSettings();
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
    }

    public void OnSoundSliderValueChanged(float value)
    {
        AudioManager.instance.SetBgmVolume(value); 
        AudioManager.instance.SetSfxVolume(value); 
    }


    public void HomeBack()
    {
       
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
        SceneManager.LoadScene(0); // 다음 씬으로 이동
    }

    public void GameBack()
    {

        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
        SceneManager.LoadScene(1); // 다음 씬으로 이동
    }


    private void FixedUpdate()
    {
        if (isGamePaused)
        {
            
        }
    }
}
