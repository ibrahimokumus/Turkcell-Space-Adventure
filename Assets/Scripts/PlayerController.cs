using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2D;
    Animator animator;
    Vector2 velocity;

    [SerializeField]
    float speed = default;
    [SerializeField]
    float accelerate = default;
    [SerializeField]
    float deceleration = default;
    [SerializeField]
    float jumpingPower = default;
    [SerializeField]
    int jumpingLimit = 3;
    [SerializeField]
    int jumpingCounter;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        MovementControl();
    }

    void MovementControl()
    {
        Vector2 scale = transform.localScale;
        float movementInput = Input.GetAxisRaw("Horizontal");
        if (movementInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, movementInput * speed, accelerate * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = 0.3f;
        }
        else if (movementInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, movementInput * speed, accelerate * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.3f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
            animator.SetBool("Walk", false);
        }
        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);
        if (Input.GetKeyDown("space"))
        {
            StartJumping();
        }
        if (Input.GetKeyUp("space"))
        {
            StopJumping();
        }

    }
    void StartJumping()
    {    
        if(jumpingCounter < jumpingLimit)
        {
            rb2D.AddForce(new Vector2(0, jumpingPower), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
        }
        
       

    }
    void StopJumping()
    {
        animator.SetBool("Jump", false);
        jumpingCounter++;
        //Debug.Log("Jump animasyonu durdu");

    }
    public void ResetJumping()
    {
        jumpingCounter = 0;
    }
}
