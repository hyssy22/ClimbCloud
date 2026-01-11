using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    float jumpForce = 680.0f;
	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
	}

    void Update()
    {
        //Jump
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce);   //0,1,0ÀÌ¶û ¶È°°À½
		}
	}
}
