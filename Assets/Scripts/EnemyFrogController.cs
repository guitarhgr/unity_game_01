using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrogController : MonoBehaviour
{
    private Rigidbody2D rigibody2d;
    private Animator animator;
    private Collider2D collider2d;
    public LayerMask ground;

    public float speed = 5.00f;
    public float jumpForce = 5;
    public Transform leftPoint, rightPoint;
    private float leftPosX, rightPosX;

    private bool isFaceLeft = true;


    // Start is called before the first frame update
    void Start()
    {
        
        rigibody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider2d = GetComponent<Collider2D>();

        // transform.DetachChildren();
        leftPosX = leftPoint.position.x;
        rightPosX = rightPoint.position.x;

        Destroy(leftPoint);
        Destroy(rightPoint);

    }

    // Update is called once per frame
    void Update()
    {
        
        // Move();
        SwitchAnim();

    }

    private void Move() 
    {

        if (isFaceLeft)
        {

            if (collider2d.IsTouchingLayers(ground))
            {

                animator.SetBool("jumping", true);
                rigibody2d.velocity = new Vector2(-speed, jumpForce);

            }

            if (transform.position.x < leftPosX)
            {

                transform.localScale = new Vector3(-1, 1, 1);

                isFaceLeft = false;

            }

        }
        else
        {

            if (collider2d.IsTouchingLayers(ground))
            {
                
                animator.SetBool("jumping", false);
                rigibody2d.velocity = new Vector2(speed, jumpForce);

            }


            if (transform.position.x > rightPosX)
            {

                transform.localScale = new Vector3(1, 1, 1);

                isFaceLeft = true;

            }

        }

    }

    private void SwitchAnim()
    {

        if (animator.GetBool("jumping"))
        {

            if (rigibody2d.velocity.y < 0.1f)
            {

                animator.SetBool("jumping", false);
                animator.SetBool("falling", true);

            }

        }

        if (collider2d.IsTouchingLayers(ground) && animator.GetBool("falling"))
        {

            animator.SetBool("falling", false);

        }

    }

}
