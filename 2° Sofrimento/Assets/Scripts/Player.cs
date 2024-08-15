using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float Speed;
    public float JumpForce;

    public bool IsJumping;
    public bool DoubleJump;
    
    private Rigidbody2D rig;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }
    
    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f,0f);
        transform.position += movement * Time.deltaTime * Speed;

        if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("Run", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        
        if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("Run", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if(Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("Run", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (IsJumping == false)
            {
                rig.AddForce(new Vector2(0f, JumpForce),ForceMode2D.Impulse);
                anim.SetBool("Jump", true);
                DoubleJump = true;
            }
            else
            {
                if (DoubleJump)
                {
                    rig.AddForce(new Vector2(0f, JumpForce),ForceMode2D.Impulse);
                    DoubleJump = false;
                }
            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.layer == 8)
        {
            IsJumping = false;
            anim.SetBool("Jump", false);
        }
        
        if (Collision.gameObject.tag == "Spike")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
    }
    
    void OnCollisionExit2D(Collision2D Collision)
    {
        if (Collision.gameObject.layer == 8)
        {
            IsJumping = true;
        }
    }
}
