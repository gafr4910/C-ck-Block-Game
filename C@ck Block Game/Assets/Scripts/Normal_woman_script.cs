using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Normal_woman_script : MonoBehaviour
{

    private Animator anim;
    private SpriteRenderer sr;

    public float speed = 10;
    public Vector2[] vecArray = new Vector2[4];
    public int waitMin = 2;
    public int waitMax = 4;
    public Vector2 dest;
    public Vector2 dest2;
    public Vector2[] positions;
    public Vector2[] destinations;
    public int waitDestTime;
    public bool isInRange;
    Text instruction;
    private Canvas co;

    //public Vector2 position1;
    //public Vector2 position2;
    //public Vector2 position3;
    //public Vector2 position4;

    //public float maxDistanceFromWall = .1f;
    //public float moveForce = 40f;
    Vector2 ExitPosition;
    //public float xPos = 0;
    //public float yPos = 0;
    private Vector2 target;
    private Vector2 position;
    private Vector2 position2;
    private int index = 0;
    public bool triggered = false;



    //public LayerMask blockingLayer=wallTest;

    // Start is called before the first frame update
    void Start()
    {

        // capsuleCollider = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        co = GameObject.Find("DialogCanvas").GetComponent<Canvas>();
        instruction = GameObject.Find("/DialogCanvas/Image/Text").GetComponent<Text>();

        //ExitPosition = new Vector2(2, 2);
        vecArray[0] = new Vector2(0f, 0f);

        position = gameObject.transform.position;
        target = ChooseDirection();

        //StartCoroutine("Move");

    }

    // Update is called once per frame
    void Update()
    {

        //if (target != position && !triggered)
        //{
        //    anim.CrossFade("Normal_woman_walk", 0);
        //    position = gameObject.transform.position;
        //    float step = Time.deltaTime * speed;
        //    //  Debug.Log(step);
        //    // anim.CrossFade("Old_Man_Walk", 0);

        //    // Debug.Log(position2.x - gameObject.transform.position.x);

        //    if (position2.x - gameObject.transform.position.x > 0)
        //    {
        //        sr.flipX = true;

        //    }
        //    else
        //    {
        //        sr.flipX = false;
        //    }

        //    transform.position = Vector2.MoveTowards(transform.position, target, step);

        //    //For loop for all of the destination points and create a vector of destinations 
        //    //Debug.Log("shit");
        //}

        //else if (!triggered)
        //{
        //    anim.CrossFade("Normal_woman", 0);
        //    StartCoroutine("MoveManager");
        //}


        if (triggered)
        {

            StopCoroutine("MoveManager");

            Debug.Log("3: " + index);

            if (index < destinations.Length)
            {


                position = gameObject.transform.position;
                if (destinations[index] != position)
                {

                    // position = gameObject.transform.position;
                    float step = Time.deltaTime * speed;
                    transform.position = Vector2.MoveTowards(transform.position, destinations[index], step);
                    //Debug.Log(destinations[index]);

                }

                else
                {
                    index++;
                    Debug.Log("2: " + index);
                    Debug.Log(destinations.Length);

                    if (index >= destinations.Length)
                    {

                        anim.CrossFade("Normal_woman", 0);
                        StartCoroutine("MoveDestManager");
                    }
                }

                //if (destinations[i] == position)n\
                //{

                //    Debug.Log("here");
                //}



            }

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherGO = other.gameObject;
        //Debug.Log(other);
        if (otherGO.name == "Jawsh")
        {
            isInRange = true;
            Debug.Log("Jawsh");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GameObject otherGO = other.gameObject;
        //Debug.Log(other);
        co.enabled = true;
        instruction.text = "God help me";
        if (otherGO.name == "Jawsh")
        {
            isInRange = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherGO = other.gameObject;
        Debug.Log(other);
        if (otherGO.name == "Jawsh")
        {
            isInRange = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        GameObject otherGO = other.gameObject;
        if (otherGO.name == "Jawsh")
        {
            isInRange = false;
        }
    }

    public IEnumerator MoveManager()
    {
        float f = (int)Random.Range(waitMin, waitMax);

        //Debug.Log(f);

        yield return new WaitForSeconds(f);
        position2 = gameObject.transform.position;
        target = ChooseDirection();
        StopCoroutine("MoveManager");

        //yield return null;

    }

    public IEnumerator MoveDestManager()
    {
        Debug.Log("1: " + index);
        yield return new WaitForSeconds(waitDestTime);
        index = 0;
        triggered = false;
        StopCoroutine("MoveDestManager");


    }


    public Vector2 ChooseDirection()
    {
        System.Random ran = new System.Random();
        int r = positions.Length;

        int i = ran.Next(0, 3);

        //Vector2 temp = new Vector2();

        int count = 0;


        //for(int j=0; j<r; j++)
        //{
        //    vecArray[j] = positions[j];
        //    count = j;
        //    Debug.Log("Here");
        //}


        if (i == 0)
        {
            //vecArray[0] = new Vector2(0f, 0f);

            //anim.CrossFade("oldWoman_Walk", 0);
            vecArray[0] = positions[0];

            //if (positions[0].x-vecArray[0].x<=0)
            //{
            //    sr.flipX=false;
            //}
            //else
            //{
            //    sr.flipX = true;
            //}
            // Debug.Log(positions[0].x - vecArray[0].x);
            count = 0;


        }

        else if (i == 1)
        {
            //vecArray[1] = new Vector2(5f, 5f);
            // anim.CrossFade("oldWoman_Walk", 0);
            vecArray[1] = positions[1];
            //if (positions[1].x - vecArray[1].x <= 0)
            //{
            //    sr.flipX = false;
            //}
            //else
            //{
            //    sr.flipX = true;
            //}
            // Debug.Log(positions[1].x - vecArray[1].x);
            count = 1;


        }
        else if (i == 2)
        {
            //anim.CrossFade("oldWoman_Walk", 0);
            //vecArray[2] = new Vector2(5f, 0f);
            vecArray[2] = positions[2];
            //if (positions[2].x - vecArray[2].x <= 0)
            //{
            //    sr.flipX = false;
            //}
            //else
            //{
            //    sr.flipX = true;
            //}
            // Debug.Log(positions[2].x - vecArray[2].x);
            count = 2;

        }
        else if (i == 3)
        {
            //anim.CrossFade("oldWoman_Walk", 0);

            //vecArray[3] = new Vector2(0f, 5f);
            //if (positions[3].x - vecArray[3].x <= 0)
            ////if (positions[2].x - vecArray[2].x < 0)
            //{
            //    sr.flipX = false;
            //}
            //else
            //{
            //    sr.flipX = true;
            //}

            vecArray[3] = positions[3];
            count = 3;

        }

        // Debug.Log(vecArray[count]);

        //if (positions[count].x - vecArray[count].x <= 0)
        ////if (positions[2].x - vecArray[2].x < 0)
        //{
        //    sr.flipX = false;
        //}
        //else
        //{
        //    sr.flipX = true;
        //}

        ////Debug.Log(positions[count].x - vecArray[count].x);
        ////Debug.Log(vecArray[count].x - positions[count].x);
        //Debug.Log(positions[count].x);
        //Debug.Log(positions[count].x);
        return vecArray[count];

    }

}
