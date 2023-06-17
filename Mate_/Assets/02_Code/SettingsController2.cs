using UnityEngine;
using UnityEngine.UI;

public class SettingsController2 : MonoBehaviour
{
    [SerializeField]
    private Button backButton;

    public GameObject settingsPanel;
    public Button[] buttons; // 숨길 버튼들
    public Button gameStartButton;
    public Button settingsButton;
    public Button quitButton;
    private bool isSettingsOpen = false;

    public Slider soundSlider; // 사운드 볼륨 조절용 슬라이더

    private bool isGamePaused = false; // 게임 일시 정지 여부를 저장하는 변수

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
        Time.timeScale = 0f; // 게임 일시 정지
        settingsPanel.SetActive(true);

        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
    }

    private void CloseSettings()
    {
        isGamePaused = false;
        settingsPanel.SetActive(false);

        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
    }

    private void SetButtonsInteractable(bool interactable)
    {
        foreach (Button button in buttons)
        {
            button.interactable = interactable;
            button.gameObject.SetActive(interactable); // 버튼 활성/비활성화
        }
    }

    public void GoBack()
    {
        CloseSettings();
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
    }

    public void OnSoundSliderValueChanged(float value)
    {
        AudioManager.instance.SetBgmVolume(value); // 배경음 볼륨 조절
        AudioManager.instance.SetSfxVolume(value); // 효과음 볼륨 조절
    }

    private void FixedUpdate()
    {
        if (isGamePaused)
        {
            // 게임이 일시 정지된 상태에서 UI 작동을 원하는 업데이트 로직을 작성하세요.
        }
    }
}
