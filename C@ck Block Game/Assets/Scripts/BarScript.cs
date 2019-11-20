using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{

    private Animator anim;
	private SpriteRenderer sr;

    public float speed=10;
	//public float maxDistanceFromWall = .1f;
	//public float moveForce = 40f;
	Vector2 ExitPosition;
	public float xPos=0;
	public float yPos = 0;
	private Vector2 target;
	private Vector2 position;

	//public LayerMask blockingLayer=wallTest;

	// Start is called before the first frame update
	void Start()
    {

       // capsuleCollider = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
		sr = GetComponent<SpriteRenderer>();

		//ExitPosition = new Vector2(2, 2);
		target = new Vector2(5.0f, 0f);
		position = gameObject.transform.position;

	}

    // Update is called once per frame
    void Update()
    {
		//xPos += speed*Time.deltaTime;
		//yPos += speed*Time.deltaTime;

		float step = speed * Time.deltaTime;
		transform.position = Vector2.MoveTowards(transform.position, target, step);

        position= gameObject.transform.position;

		if (position==target)
		{
			//target = new Vector2(0f, 0f);
			target = ChooseDirection();

		}


			// if (transform.position==target)
			//{
			

		//}


		//ExitPosition = Vector2(xPos, yPos);

		//transform.position = new Vector3(xPos, yPos, 0);

		//if (transform.position.x < 3.0f)
		//{
		//transform.position.x += moveForce * Time.deltaTime;

		//transform.position = Vector2.Lerp(transform.position , ExitPosition, speed * Time.deltaTime);

		//transform.position = new Vector2(xPos, yPos);

         //}
    }

	public Vector2 ChooseDirection()
	{
		System.Random ran = new System.Random();
		int i = ran.Next(0, 3);
		Vector2 temp = new Vector2();

        if (i==0)
		{
			temp = new Vector2(0f, 0f);

		}

        else if (i==1)
		{
			temp = new Vector2(5f, 5f);

		}
		else if (i == 2)
		{
			temp = new Vector2(5f, 0f);

		}
		else if (i == 3)
		{

			temp = new Vector2(0f, 5f);
		}

		return temp;


	}

}
