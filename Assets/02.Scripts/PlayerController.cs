using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;
	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}

    void Update()
    {
        //Jump
        if(Input.GetKeyDown(KeyCode.Space) && rb.velocity.y.Equals(0))
        {
            rb.AddForce(transform.up * jumpForce);   //0,1,0이랑 똑같음
            animator.SetTrigger("Jump");
		}

        //좌우 이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //플레이어 속도
        float speedx = Mathf.Abs(rb.velocity.x);

        //스피드 제한
        if (speedx < maxWalkSpeed)
        {
            this.rb.AddForce(transform.right * key * this.walkForce);
		}

        //움직이는 방향에 따라 반전한다
        if(key != 0)
            {
            this.transform.localScale = new Vector3(key, 1, 1);
		}

        //플레이어 속도에 맞춰서 애니메이션 속도를 적용한다.
        animator.speed = speedx / 2.0f;

        Vector3 pos = transform.position;

		if (pos.y < -10.0f) 
        {
			// pos.x = 0.0f;
            // pos.y = 0.0f;
            // pos.z = 0.0f;
            SceneManager.LoadScene("GameScene");
		}
		transform.position = pos;
}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//Debug.Log("골인");
        SceneManager.LoadScene("ClearScene");
	}
}