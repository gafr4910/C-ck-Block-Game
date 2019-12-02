using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linda_script : MonoBehaviour
{

    private Animator anim;
    private SpriteRenderer sr;

    public float speed = 10;
    public Vector2[] vecArray = new Vector2[4];
    public int waitMin = 2;
    public int waitMax = 4;
    public Vector2 dest;
    public Vector2 dest2;

    public Vector2 position1;
    public Vector2 position2;
    public Vector2 position3;
    public Vector2 position4;

    //public float maxDistanceFromWall = .1f;
    //public float moveForce = 40f;
    Vector2 ExitPosition;
    //public float xPos = 0;
    //public float yPos = 0;
    private Vector2 target;
    private Vector2 position;
    public bool triggered = false;



    //public LayerMask blockingLayer=wallTest;

    // Start is called before the first frame update
    void Start()
    {

        // capsuleCollider = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        //ExitPosition = new Vector2(2, 2);
        vecArray[0] = new Vector2(0f, 0f);

        position = gameObject.transform.position;
        target = ChooseDirection();

        //StartCoroutine("Move");

    }

    // Update is called once per frame
    void Update()
    {


        if (target != position && !triggered)
        {
            position = gameObject.transform.position;
            float step = Time.deltaTime * speed;
            //  Debug.Log(step);
            // anim.CrossFade("Old_Man_Walk", 0);
            transform.position = Vector2.MoveTowards(transform.position, target, step);

            //Debug.Log("shit");
        }

        else if (!triggered)
        {
            StartCoroutine("MoveManager");
        }


        if (triggered)
        {

            StopCoroutine("MoveManager");

            //Debug.Log("here");

            position = gameObject.transform.position;
            float step = Time.deltaTime * speed;

            transform.position = Vector2.MoveTowards(transform.position, dest, step);

        }


        //else if(triggered && position == dest && dest2!=null)
        // {
        //     Debug.Log("nice");
        //     position = gameObject.transform.position;
        //     float step = Time.deltaTime * speed;
        //     transform.position = Vector2.MoveTowards(transform.position, dest2, step);

        // }



        //else if(triggered)
        //{
        //    StartCoroutine("MoveSomewhere");
        //}

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

    //public IEnumerator MoveSomewhere()
    //{
    //    float f = (int)Random.Range(waitMin, waitMax);

    //    //Debug.Log(f);
    //     yield return new WaitForSeconds(f);

    //    Vector2 dest = new Vector2(12f, 12f);

    //    StopCoroutine("MoveSomewhere");

    //    //yield return null;

    //}

    public IEnumerator MoveManager()
    {
        float f = (int)Random.Range(waitMin, waitMax);

        //Debug.Log(f);


        yield return new WaitForSeconds(f);
        target = ChooseDirection();
        StopCoroutine("MoveManager");

        //yield return null;

    }


    public Vector2 ChooseDirection()
    {
        System.Random ran = new System.Random();
        int i = ran.Next(0, 3);
        //Vector2 temp = new Vector2();
        int count = 0;
        if (i == 0)
        {
            //vecArray[0] = new Vector2(0f, 0f);

            vecArray[0] = position1;

            count = 0;

        }

        else if (i == 1)
        {
            //vecArray[1] = new Vector2(5f, 5f);
            vecArray[1] = position2;
            count = 1;

        }
        else if (i == 2)
        {
            //vecArray[2] = new Vector2(5f, 0f);
            vecArray[2] = position3;
            count = 2;

        }
        else if (i == 3)
        {

            //vecArray[3] = new Vector2(0f, 5f);
            vecArray[3] = position4;
            count = 3;

        }

        return vecArray[count];

    }

}
