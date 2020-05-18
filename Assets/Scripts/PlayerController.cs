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

    // Start is called before the first frame update
    void Start()
    {

        InitCompont();

    }

    void FixedUpdate()
    {

        Move();
        SwitchAnim();

    }

    // Update is called once per frame
    void Update()
    {

        //Move();

    }

    private void InitCompont() {

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

    void SwitchAnim() {

        anim.SetBool("idle", false);

        if (anim.GetBool("jumping")) {

            if (rigidbody2d.velocity.y < 0) {

                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);

            }

        }
        else if (coll2d.IsTouchingLayers(ground)) {

            anim.SetBool("falling", false);
            anim.SetBool("idle", true);

        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        Debug.Log($"{other.tag}");

        if (other.tag == "Collection") {

            Destroy(other.gameObject);

            cherryCount++;

            TextCherryNum.text = cherryCount.ToString();

        }

    }

}
