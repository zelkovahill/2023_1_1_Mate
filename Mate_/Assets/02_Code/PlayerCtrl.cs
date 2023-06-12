using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 10.0f;
    public float jumpForce = 5.0f;
    private bool isJumping = false;

    public Animator anim;
    private readonly int hashWalk = Animator.StringToHash("isWalking");
    private readonly int hashJumo = Animator.StringToHash("isJump");

    public Transform tr_Player;
 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
    }   

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
       

        Vector3 moveDir =  new Vector3(1.0f, 0.0f , 0.0f ) * h;
        transform.Translate(moveDir * Time.deltaTime * moveSpeed);

        if (h != 0)         
        {
            anim.SetBool("isWalking", true);
            Debug.Log(hashWalk.ToString());
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isJump", false);
        }

        if(h >= 0)
        {           
            Vector3 currentEulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
           
            tr_Player.transform.eulerAngles = currentEulerAngles;
        }
        else
        {
            Vector3 currentEulerAngles = new Vector3(0.0f, 270.0f, 0.0f);

            tr_Player.transform.eulerAngles = currentEulerAngles;
        }


        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isJumping = true;
        anim.SetTrigger(hashJumo);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
