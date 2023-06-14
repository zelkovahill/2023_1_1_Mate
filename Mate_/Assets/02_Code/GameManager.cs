using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{

    public Transform targetLocation; // 클리어 지점의 Transform

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어가 클리어 지점에 도착한 경우
            StartCoroutine(GameClear());
        }
    }

    private IEnumerator GameClear()
    {
        AudioManager.instance.PlayBgm(false);
        Time.timeScale = 0f; // 게임 일시 정지

        yield return new WaitForSecondsRealtime(3f); // 3초 대기 (실제 시간 기준)

        Time.timeScale = 1f; // 게임 재개
        SceneManager.LoadScene(0); // 다음 씬으로 이동 (씬 이름을 적절히 변경해야 함)
    }


    public void GameStart()
    {
        AudioManager.instance.PlayBgm(true);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
        SceneManager.LoadScene(1);
    }



    
}
