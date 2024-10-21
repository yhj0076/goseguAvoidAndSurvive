using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_PlayerController : MonoBehaviour
{
    public GameObject cam;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    SA_HealthController healthCon;
    public bool isGrounded = false;

    public float JumpPower;
    public float maxSpeed;
    public int JumpCount = 0;
    public bool isTalking = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        healthCon = GetComponent<SA_HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTalking == false)
        {
            Flipx();
            Jump();
            Move();
        }
    }

    void Flipx()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
        }
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right*h*10, ForceMode2D.Impulse);
        
        //Max speed
        if (rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * (-1))
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }
    }

    void Jump()
    {   
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && JumpCount<2)
        {
            rigid.velocity = Vector2.zero;
            rigid.AddForce(new Vector2(rigid.velocity.x, JumpPower));
            JumpCount++;
        }

        //Stop speed
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f || collision.transform.tag == "Platform")
        {
            isGrounded = true;
            JumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isGrounded = false;
        }
    }
}
