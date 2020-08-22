using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Animator animator;

    public Rigidbody2D rb;

    Vector2 liike;


    
    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isUp", false);
        animator.SetBool("isDown", false);
        animator.SetBool("isRight", false);
        animator.SetBool("isLeft", false);

        liike.x = Input.GetAxisRaw("Horizontal");
        liike.y = Input.GetAxisRaw("Vertical");
        if ((liike.x != 0) & (liike.y != 0))
        {
            liike.x = 0;
        }


        //Kävelyanimaatiot

        if (liike.x > 0)
        {
            //oikea
            animator.SetBool("isRight", true);
        }
        else if (liike.x < 0)
        {
            //vasen
            animator.SetBool("isLeft", true);
        }
        else if (liike.y > 0)
        {
            //ylös
            animator.SetBool("isUp", true);
        }
        else if (liike.y < 0)
        {
            //alas
            animator.SetBool("isDown", true);
        }
        else
        {
            //idle
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + liike * moveSpeed * Time.fixedDeltaTime);
        //Kävelyanimaatiot

        if (liike.x > 0)
        {
            //oikea
            animator.SetBool("isRight", true);
        }
        else if (liike.x < 0)
        {
            //vasen
            animator.SetBool("isLeft", true);
        }
        else if (liike.y > 0)
        {
            //ylös
            animator.SetBool("isUp", true);
        }
        else if (liike.y < 0)
        {
            //alas
            animator.SetBool("isDown", true);
        }
    }


}
