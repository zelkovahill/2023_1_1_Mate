using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private Transform player;
    private bool isCollisionHandled = false; // 충돌 처리 여부를 나타내는 플래그 변수
    private bool isPlayerDie = false; // 플레이어 사망 여부를 나타내는 전역 변수
    private Animator animator; // 애니메이터 컴포넌트

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>(); // 애니메이터 컴포넌트 가져오기
        SetNextWaypoint();
    }

    private void Update()
    {
        if (!isPlayerDie && player != null)
        {
            // 플레이어의 위치를 추적하여 이동 방향 결정
            Vector3 direction = (player.position - transform.position).normalized;
            direction.y = 0f; // Y 축 값을 0으로 설정하여 수직 방향 이동 방지
            transform.position += direction * moveSpeed * Time.deltaTime;

            // 이동하는 동안에는 움직임 애니메이션 재생
            animator.SetBool("isMoving", true);

            // 왼쪽 또는 오른쪽을 바라보도록 회전 적용
            if (direction.x >= 0)
            {
                transform.eulerAngles = new Vector3(0f, 90f, 0f); // 오른쪽을 보도록 회전
            }
            else
            {
                transform.eulerAngles = new Vector3(0f, 270f, 0f); // 왼쪽을 보도록 회전
            }
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

            // 정지 상태에서는 움직임 애니메이션 정지
            animator.SetBool("isMoving", false);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (!isCollisionHandled && collision.transform.CompareTag("Player"))
        {
            isCollisionHandled = true;
            isPlayerDie = true; // 플레이어 사망 상태로 변경
            moveSpeed = 0f; // 움직임을 멈추기 위해 moveSpeed를 0으로 설정

            // 애니메이션 재생 정지
            animator.enabled = false;

            SceneManager.LoadScene(2);
        }
    }

    private IEnumerator ReloadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 3초 후에 씬을 다시 로드하기 전에 상태를 초기화
        isPlayerDie = false;
        isCollisionHandled = false;
        moveSpeed = 3f;

        SceneManager.LoadScene(1);
    }
}
