using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController2 : MonoBehaviour
{
    public Transform goalPoint;
    public float pauseDuration = 3f;
    private bool isPaused = false;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPaused)
        {
            StartCoroutine(PauseGameAndLoadNextScene());
        }
    }

    private IEnumerator PauseGameAndLoadNextScene()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Clear);
        isPaused = true;
        Time.timeScale = 0f; // 게임 일시정지

        yield return new WaitForSecondsRealtime(pauseDuration); // 3초 대기

        Time.timeScale = 1f; // 게임 재개
        SceneManager.LoadScene(0); // 다음 씬으로 이동
    }
}
