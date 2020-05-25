using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrogController : MonoBehaviour
{
    private Rigidbody2D rigibody2d;
    public float speed = 5.00f;
    public Transform leftPoint, rightPoint;
    private float leftPosX, rightPosX;

    private bool isFaceLeft = true;


    // Start is called before the first frame update
    void Start()
    {
        
        rigibody2d = GetComponent<Rigidbody2D>();

        // transform.DetachChildren();
        leftPosX = leftPoint.position.x;
        rightPosX = rightPoint.position.x;

        Destroy(leftPoint);
        Destroy(rightPoint);

    }

    // Update is called once per frame
    void Update()
    {
        
        Move();

    }

    private void Move() 
    {

        if (isFaceLeft)
        {

            rigibody2d.velocity = new Vector2(-speed, rigibody2d.velocity.y);

            if (transform.position.x < leftPosX)
            {

                transform.localScale = new Vector3(-1, 1, 1);

                isFaceLeft = false;

            }

        }
        else
        {

            rigibody2d.velocity = new Vector2(speed, rigibody2d.velocity.y);

            if (transform.position.x > rightPosX)
            {

                transform.localScale = new Vector3(1, 1, 1);

                isFaceLeft = true;

            }

        }

    }

}
