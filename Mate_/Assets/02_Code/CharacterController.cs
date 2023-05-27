using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        // 스프라이트 렌더러 컴포넌트 참조
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // 수평 입력값 받기
        float horizontalInput = Input.GetAxis("Horizontal");

        // 입력값에 따라 스프라이트 플립
        if (horizontalInput < 0)
        {
            // 왼쪽 방향을 보도록 스프라이트 플립
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            // 오른쪽 방향을 보도록 스프라이트 플립 해제
            spriteRenderer.flipX = false;
        }
    }
}
