using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fanplatform : MonoBehaviour
{
    Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) {

            animator.Play("Fan_run");
         }
    }
}
