using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float jumpForce;
    public bool isGrounded = true;
    public bool isDown = false;

    public GameObject Bullet;

    public Vector2 normalLaserOffset = new Vector2(0, .5f);

    private Vector2 normalSize = new Vector2(.5f, 1.2f);
    private Vector2 downSize = new Vector2(.5f, .73f);

    private Vector2 normalOffset = Vector2.zero;
    private Vector2 downOffset = new(0, -0.23f);


    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;

        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isGrounded", true);
    }

    // Update is called once per frame
    void Update()
    {
        isDown = (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && isGrounded;
        if (isDown != anim.GetBool("isDown"))
        {
            if (isDown)
            {
                boxCollider.size = downSize;
                boxCollider.offset = downOffset;
            }
            else
            {
                boxCollider.size = normalSize;
                boxCollider.offset = normalOffset;
            }

            
        }
        anim.SetBool("isDown", isDown);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && !isDown)
        {
            isGrounded = false;
            anim.SetBool("isGrounded", !anim.GetBool("isGrounded"));
            rb.velocity = Vector2.up * jumpForce;
        }

        if (isGrounded == false && (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
        {
            rb.velocity = -Vector2.up * jumpForce;
        }

        if (Input.GetMouseButtonDown(0))
        {
            var dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - (transform.position + (Vector3)normalLaserOffset);
            var newBullet = Instantiate(Bullet);
            newBullet.transform.position = transform.position + (Vector3)normalLaserOffset;
            float rot = Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg;
            newBullet.transform.rotation = Quaternion.Euler(0, 0, rot + 90);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("SUPER died");
        }
    }
}
