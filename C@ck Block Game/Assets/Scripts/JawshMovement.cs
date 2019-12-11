using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawshMovement : MonoBehaviour
{
    public float speed = 10;
    public float runSpeed = 15;
    public KeyCode left, right, up, down;
    public bool hadWaiterDisguise = false;
    public bool hasWaiterDisguise = false;
    public bool isDisguisedAsWaiter = false;
    //public GameObject barLimit;

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
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        //Vector3 pos = transform.position;
        if(Input.GetAxis("Fire3") == 0)
        {
            rb.velocity = Vector2.right * xAxis * speed + Vector2.up * yAxis * speed;
        }
        else 
        {
            rb.velocity = Vector2.right * xAxis * runSpeed + Vector2.up * yAxis * runSpeed;
        }
        // pos.x += xAxis * speed * Time.deltaTime;
        // pos.y += yAxis * speed * Time.deltaTime;
        //transform.position = pos;

        if(!hadWaiterDisguise && hasWaiterDisguise)
        {
            isDisguisedAsWaiter = true;
            hadWaiterDisguise = true;
        }

        bool disguiseKeyPressed = false;

        if((Input.GetKeyDown(KeyCode.E)) && (!isDisguisedAsWaiter) && (hasWaiterDisguise))
        {
            isDisguisedAsWaiter = true;
            disguiseKeyPressed = true;
            //Debug.Log("1");
        }

        if((Input.GetKeyDown(KeyCode.E)) && (isDisguisedAsWaiter) && !disguiseKeyPressed)
        {
            isDisguisedAsWaiter = false;
            //Debug.Log("2");
        }

        disguiseKeyPressed = false;

        if(!isDisguisedAsWaiter)
        {
            if(xAxis == 0 && yAxis == 0)
            {
                anim.CrossFade("Jawsh_Idle", 0);
            }
            else if(Input.GetAxis("Fire3") > 0)
            {
                anim.CrossFade("Jawsh_Run", 0);
                sr.flipX = xAxis < 0;
            }
            else
            {
                anim.CrossFade("Jawsh_Walk", 0);
                sr.flipX = xAxis < 0;
            }

            //barLimit.SetActive(true);
        }

        else if(isDisguisedAsWaiter)
        {
            if(xAxis == 0 && yAxis == 0)
            {
                anim.CrossFade("Jawsh_Waiter_Idle", 0);
            }
            else if(Input.GetAxis("Fire3") > 0)
            {
                anim.CrossFade("Jawsh_Waiter_Run", 0);
                sr.flipX = xAxis < 0;
            }
            else
            {

                anim.CrossFade("Jawsh_Waiter_Walk", 0);
                sr.flipX = xAxis < 0;
            }

            //barLimit.SetActive(false);
        }

        // float horiz = 0.0f;
        // float vert = 0.0f;

        // Debug.Log(Input.GetKey(left) + ", " + Input.GetKey(right) + ", " + Input.GetKey(up) + ", " + Input.GetKey(down));

        // if(Input.GetKey(left))
        // {
        //     // horiz -= Input.GetKey(left);
		// 	rb.velocity = Vector2.left * speed;
		// 	anim.CrossFade("Jawsh_Walk", 0);
		// 	sr.flipX = true;
		// }

		// else if(Input.GetKey(right))
        // {
        //     // horiz += Input.GetKey(right);
		// 	rb.velocity = Vector2.right * speed;
		// 	anim.CrossFade("Jawsh_Walk", 0);
		// 	sr.flipX = false;
		// }

        // else if(Input.GetKey(up))
        // {
		// 	rb.velocity = Vector2.up * speed;
		// 	anim.CrossFade("Jawsh_Walk", 0);
		// }

        // else if(Input.GetKey(down))
        // {
		// 	rb.velocity = Vector2.down * speed;
		// 	anim.CrossFade("Jawsh_Walk", 0);
		// }

        // else 
		// {
        //     rb.velocity = Vector2.up * 0;
		// 	anim.CrossFade("Jawsh_Idle", 0);
		// }
    }
}
