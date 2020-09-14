using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    public GameObject player;
    public bool isGrounded = false;
    public float yJump = 5f;

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += movement * Time.deltaTime * moveSpeed;
        
        if (movement.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (movement.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (movement.x == 0)
        {
            animator.SetBool("IsMoving", false);
        }
        else if (animator.GetBool("isJumping") == true)
        {
            animator.SetBool("IsMoving", false);
        }
        else
        {
            animator.SetBool("IsMoving", true);
        }
        
        Jump();
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("IsMoving", false);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, yJump), ForceMode2D.Impulse);
        }

    }
}
