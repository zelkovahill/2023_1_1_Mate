using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        SetNextWaypoint();
    }

    private void Update()
    {
        if (player != null)
        {
            // 플레이어의 위치를 추적하여 이동 방향 결정
            Vector3 direction = (player.position - transform.position).normalized;
            direction.y = 0f; // Y 축 값을 0으로 설정하여 수직 방향 이동 방지
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
        else
        {
            // 목표 지점 방향으로 이동
            Vector3 direction = (waypoints[currentWaypointIndex].position - transform.position).normalized;
            direction.y = 0f; // Y 축 값을 0으로 설정하여 수직 방향 이동 방지
            transform.position += direction * moveSpeed * Time.deltaTime;

            // 목표 지점에 도달하면 다음 지점으로 이동
            float distanceToWaypoint = Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position);
            if (distanceToWaypoint < 0.1f)
            {
                SetNextWaypoint();
            }
        }
    }

    private void SetNextWaypoint()
    {
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어와 충돌한 경우, 오디오 재생 후 3초 후에 씬을 다시 로드
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
            StartCoroutine(ReloadSceneAfterDelay(3f));
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Dead);
        }
    }

    private IEnumerator ReloadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(1);
    }

}
