using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEagleController : Enemy
{

    private Rigidbody2D rigibody2d;
    // private Animator animator;
    // private Collider2D collider2d;

    public Transform topPoint;
    public Transform bottomPoint;
    public float speed = 5.0f;
    private float topPosY;
    private float bottomPosY;

    private bool isUp = true;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        
        rigibody2d = GetComponent<Rigidbody2D>();
        // animator = GetComponent<Animator>();
        // collider2d = GetComponent<Collider2D>();

        topPosY = topPoint.position.y;
        bottomPosY = bottomPoint.position.y;

        Destroy(topPoint.gameObject);
        Destroy(bottomPoint.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
        Move();

    }

    void Move()
    {

        if (isUp)
        {

            rigibody2d.velocity = new Vector2(rigibody2d.velocity.x, speed);

            if (transform.position.y > topPosY)
            {

                isUp = false;

            }

        }
        else
        {

            rigibody2d.velocity = new Vector2(rigibody2d.velocity.x, -speed);

            if (transform.position.y < bottomPosY)
            {

                isUp = true;

            }

        }

    }

}
