using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D bxCol2D;
    [SerializeField] private int objHP = 1;
    private AudioSource ausrc;
    
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        bxCol2D = GetComponent<BoxCollider2D>();
        ausrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("destroyed");
        Destroy(bxCol2D);
        ausrc.Play();
    }
}
