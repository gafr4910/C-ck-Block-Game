using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawshMovement : MonoBehaviour
{
    public float speed = 10;
    public KeyCode left, right, up, down;

    private Rigidbody2D     rb;
	private Animator anim;
	private SpriteRenderer sr;

    void Awake () 
    {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		sr = GetComponent<SpriteRenderer>();
	}

    void Start()
    {
        
    }

    void Update()
    {
        // float xAxis = Input.GetAxis("Horizontal");
        // float yAxis = Input.GetAxis("Vertical");
        // Vector3 pos = transform.position;
        // pos.x += xAxis * speed * Time.deltaTime;
        // pos.y += yAxis * speed * Time.deltaTime;
        // transform.position = pos;

        if(Input.GetKey(left))
        {
			rb.velocity = Vector2.left * speed;
			anim.CrossFade("Jawsh_Walk", 0);
			sr.flipX = true;
		}

		else if(Input.GetKey(right))
        {
			rb.velocity = Vector2.right * speed;
			anim.CrossFade("Jawsh_Walk", 0);
			sr.flipX = false;
		}

        else if(Input.GetKey(up))
        {
			rb.velocity = Vector2.up * speed;
			anim.CrossFade("Jawsh_Walk", 0);
		}

        else if(Input.GetKey(down))
        {
			rb.velocity = Vector2.down * speed;
			anim.CrossFade("Jawsh_Walk", 0);
		}

        else 
		{
            rb.velocity = Vector2.up * 0;
			anim.CrossFade("Jawsh_Idle", 0);
		}
    }
}
