using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    private Animator anim;
    private int cherryCount = 0;

    public Collider2D coll2d;
    public float speed;
    public float jumpforce = 5;
    public LayerMask ground;
    public Text TextCherryNum;
    private bool isHurt = false;

    // Start is called before the first frame update
    void Start()
    {

        InitCompont();

    }

    void FixedUpdate()
    {

        if (!isHurt)
        {

            Move();

        }

        SwitchAnim();

    }

    // Update is called once per frame
    void Update()
    {

        //Move();

    }

    private void InitCompont()
    {

        rigidbody2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void Move()
    {

        float horizontalDirection = Input.GetAxis("Horizontal");
        float facedDirection = Input.GetAxisRaw("Horizontal");

        if (horizontalDirection != 0)
        {

            rigidbody2d.velocity = new Vector2(horizontalDirection * speed, rigidbody2d.velocity.y);
            anim.SetFloat("running", Mathf.Abs(horizontalDirection));

        }

        if (facedDirection != 0)
        {

            transform.localScale = new Vector3(facedDirection, 1, 1);

        }

        if (Input.GetButton("Jump") && coll2d.IsTouchingLayers(ground))
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpforce * Time.deltaTime);
            anim.SetBool("jumping", true);

        }

    }

    void SwitchAnim()
    {

        anim.SetBool("idle", false);

        if (rigidbody2d.velocity.y < 0.1f && !coll2d.IsTouchingLayers(ground))
        {

            anim.SetBool("falling", true);

        }

        if (anim.GetBool("jumping"))
        {

            if (rigidbody2d.velocity.y < 0)
            {

                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);

            }

        }
        else if (isHurt)
        {

            anim.SetBool("hurting", true);
            anim.SetFloat("running", 0);

            if (Mathf.Abs(rigidbody2d.velocity.x) < 0.1f)
            {

                anim.SetBool("hurting", false);
                anim.SetBool("idle", true);

                isHurt = false;


            }

        }
        else if (coll2d.IsTouchingLayers(ground))
        {

            anim.SetBool("falling", false);
            anim.SetBool("idle", true);

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log($"{other.tag}");

        if (other.tag == "Collection")
        {

            Destroy(other.gameObject);

            cherryCount++;

            TextCherryNum.text = cherryCount.ToString();

        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Enemy")
        {

            if (anim.GetBool("falling"))
            {

                Destroy(other.gameObject);

            }
            else if (transform.position.x < other.gameObject.transform.position.x)
            {

                rigidbody2d.velocity = new Vector2(-5, rigidbody2d.velocity.y);

                isHurt = true;

                anim.SetBool("hurting", true);

            }
            else if (transform.position.x > other.gameObject.transform.position.x)
            {

                rigidbody2d.velocity = new Vector2(5, rigidbody2d.velocity.y);

                isHurt = true;

                anim.SetBool("hurting", true);

            }

        }

    }

}
