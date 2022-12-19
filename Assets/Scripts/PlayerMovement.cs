using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;
    public float moveSpeed = 5f;
    public float animationSpeed = 1f;

    void Start()
    {
        //animator.speed = animationSpeed * timescale;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameManager.timescale != 0)
        {
            animator.speed = animationSpeed * gameManager.timescale;

            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            if (movement != Vector2.zero)
            {
                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
                //animator.SetFloat("LastHorizontal", movement.x);
                //animator.SetFloat("LastVertical", movement.y);
            }
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        else
        {
            animator.speed = 0;
        }
        // Input
    }

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime * gameManager.timescale);
    }
    public void ToggleAnimation(bool toggle)
    {
        if (toggle)
        {
            animator.speed = animationSpeed * gameManager.timescale;
        }
        else
        {
            animator.speed = 0;
        }
    }
}
