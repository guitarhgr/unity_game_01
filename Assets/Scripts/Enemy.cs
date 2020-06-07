using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected Animator animator;
    protected AudioSource deathAudio;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
        animator = GetComponent<Animator>();
        deathAudio = GetComponent<AudioSource>();

    }

    public void Death()
    {

        Destroy(gameObject);

    }

    public void JumpOn()
    {

        animator.SetTrigger("death");
        deathAudio.Play();

    }
}
