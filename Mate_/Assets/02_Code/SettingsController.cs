using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField]
    private Button backButton;

    public GameObject settingsPanel;
    public Button[] buttons; // 숨길 버튼들
    public Button gameStartButton;
    public Button settingsButton;
    public Button quitButton;
    private bool isSettingsOpen = false;

    private void Start()
    {
        settingsPanel.SetActive(false);
        gameStartButton = GameObject.Find("Button - START").GetComponent<Button>();
        settingsButton = GameObject.Find("Button - SET UP").GetComponent<Button>();
        quitButton = GameObject.Find("Button - EXIT").GetComponent<Button>();
       
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
        settingsPanel.SetActive(true);
        SetButtonsInteractable(false); // 버튼들을 비활성화
        gameStartButton.gameObject.SetActive(false); // 게임 시작 버튼 숨기기
        settingsButton.gameObject.SetActive(false); // 설정 버튼 숨기기
        quitButton.gameObject.SetActive(false); // 나가기 버튼 숨기기
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
    }

    private void CloseSettings()
    {
        settingsPanel.SetActive(false);
        SetButtonsInteractable(true); // 버튼들을 활성화
        gameStartButton.gameObject.SetActive(true); // 게임 시작 버튼 보이기
        settingsButton.gameObject.SetActive(true); // 설정 버튼 보이기
        quitButton.gameObject.SetActive(true); // 나가기 버튼 보이기
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

}
