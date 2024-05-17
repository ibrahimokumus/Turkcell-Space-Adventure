using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   // Rigidbody2D rb2D;
    Animator animator;
    Vector2 velocity;

    [SerializeField]
    float speed = default;
    [SerializeField]
    float accelerate = default;
    [SerializeField]
    float deceleration;
    

    void Start()
    {
     //   rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        movementControl();
    }

    void movementControl()
    {
        Vector2 scale = transform.localScale;
        float movementInput = Input.GetAxisRaw("Horizontal");
        if (movementInput > 0) 
        {
           velocity.x=Mathf.MoveTowards(velocity.x, movementInput* speed, accelerate * Time.deltaTime);         
           animator.SetBool("Walk",true);
           scale.x = 0.3f;
        }else if (movementInput < 0) 
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
        transform.Translate(velocity*Time.deltaTime);
    }
}
