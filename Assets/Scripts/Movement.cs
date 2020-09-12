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
    private Vector3 direction = new Vector3(0f, 0f, -1f);
    public bool isGrounded = false;
    public float yJump = 5f;

    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += movement * Time.deltaTime * moveSpeed;
        if (movement.x > 0)
        {
            player.transform.localScale -= direction;
            animator.SetTrigger("Running");
        }
        else if (movement.x < 0)
        {
            player.transform.localScale += direction;
            animator.SetTrigger("Running");
        }
        else
        {
            animator.SetTrigger("PlayerIdle");
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, yJump), ForceMode2D.Impulse);
        }
    }
}
