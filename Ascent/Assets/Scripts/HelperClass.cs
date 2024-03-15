using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HelperClass : MonoBehaviour
{
    Rigidbody2D rb2d;
    Rigidbody rb;
    float speed, jumpforce;
    public void Movement2D()
    {
        float xinput, yinput;

       
        xinput = Input.GetAxisRaw("Horizontal");
        yinput = Input.GetAxisRaw("Vertical");

        rb2d.velocity = new Vector2(xinput * speed * Time.deltaTime, yinput * speed * Time.deltaTime);
    }
    public void Movement3D()
    {
        float xinput, zinput, jump;


        xinput = Input.GetAxisRaw("Horizontal");
        zinput = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            jump = jumpforce;
        }
        else
        {
            jump = 0f;
        }

        rb.velocity = new Vector3(xinput * speed * Time.deltaTime, jump, zinput * speed * Time.deltaTime);
    }
}
