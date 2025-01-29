using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    public float moveSpeed = 10.0f;
    public float jumpForce = 5.0f;
    private int jumpCount = 0;
    private bool isJumping = false;

    private Animator anim;
    private Rigidbody rb;
    private readonly int hashWalk = Animator.StringToHash("isWalking");
    private readonly int hashJump = Animator.StringToHash("isJump");

    public Transform tr_Player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        Vector3 moveDir = new Vector3(1.0f, 0.0f, 0.0f) * h;
        transform.Translate(moveDir * Time.deltaTime * moveSpeed);

        if (h != 0)
        {
            anim.SetBool(hashWalk, true);
        }
        else
        {
            anim.SetBool(hashWalk, false);
        }

        if (h >= 0)
        {
            Vector3 currentEulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
            tr_Player.transform.eulerAngles = currentEulerAngles;
        }
        else
        {
            Vector3 currentEulerAngles = new Vector3(0.0f, 270.0f, 0.0f);
            tr_Player.transform.eulerAngles = currentEulerAngles;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                Jump();
            }
            else if (jumpCount < 2)
            {
                Jump();
                jumpCount++;
            }
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isJumping = true;
        anim.SetTrigger(hashJump);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            jumpCount = 0;
        }
    }
}
