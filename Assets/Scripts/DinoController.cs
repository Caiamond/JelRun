using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float jumpForce;
    public bool isGrounded;
    public bool isDown;

    private Animator anim;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isGrounded", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            anim.SetBool("isGrounded", !anim.GetBool("isGrounded"));
            rb.velocity = Vector2.up * jumpForce;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("isGrounded", true);
        }
    }
}
