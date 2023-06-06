using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    private void Start()
    {
        Button quitButton = GetComponent<Button>();
        quitButton.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
    }
}
