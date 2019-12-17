using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Interaction : MonoBehaviour
{

    private Animator anim;
    private SpriteRenderer sr;
    private Canvas co;
    Text instruction;

    public Image textbox;
    public Text text;
    public string npcName;
    public bool isInRange = false;
    //public bool isPickedUp = false;
    public string[] barks;

    public float speed = 8;
    public Vector2[] vecArray = new Vector2[4];
    public int waitMin = 2;
    public int waitMax = 4;
    public Vector2 dest;
    public Vector2 dest2;
    public Vector2[] positions;
    public Vector2[] destinations;
    public int waitDestTime;
    public string[] animations;

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


    void Start()
    {
        textbox.enabled = false;
        text.enabled = false;
        Debug.Log("Start?");
        npcName = name;

        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        //co = GameObject.Find("DialogCanvas").GetComponent<Canvas>();
        //instruction = GameObject.Find("/DialogCanvas/Image/Text").GetComponent<Text>();



        //ExitPosition = new Vector2(2, 2);

        vecArray[0] = new Vector2(0f, 0f);

        position = gameObject.transform.position;
        target = ChooseDirection();

        index = 0;
        Debug.Log("Start");
    }

    void Update()
    {
        //Debug.Log(isInRange);
        if(isInRange && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("yep");
            //isPickedUp = true;
            //this.gameObject.SetActive(false);
            textbox.enabled = true;
            text.enabled = true;
            int rand = Random.Range(0, barks.Length);
            text.text = barks[rand];
            Invoke("ClearText", 5);
            Debug.Log("1?");
        }

        if (target != position && !triggered)
        {
            //Debug.Log("2: " );
            anim.CrossFade(animations[0], 0);
            position = gameObject.transform.position;
            float step = Time.deltaTime * speed;
            //  Debug.Log(step);
            // anim.CrossFade("Old_Man_Walk", 0);

            // Debug.Log(position2.x - gameObject.transform.position.x);

            if (position2.x - gameObject.transform.position.x > 0)
            {
                sr.flipX = true;

            }
            else
            {
                sr.flipX = false;
            }

            transform.position = Vector2.MoveTowards(transform.position, target, step);

            //For loop for all of the destination points and create a vector of destinations 
            //Debug.Log("shit");
        }

        else if (!triggered)
        {
            anim.CrossFade(animations[1], 0);
            StartCoroutine("MoveManager");
        }


        if (triggered)
        {

            //anim.CrossFade("Old_woman", 0);
            StopCoroutine("MoveManager");

            //Debug.Log("3: " + index);

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

                    //Debug.Log("2: " + index);
                    //  Debug.Log(destinations.Length);

                    if (index >= destinations.Length)
                    {

                        //anim.CrossFade("oldWoman_Idle", 0);
                        anim.CrossFade(animations[1], 0);
                        StartCoroutine("MoveDestManager");

                    }
                }

            }
   
        }
     
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherGO = other.gameObject;
        Debug.Log(other);
        if (otherGO.name == "Jawsh")
        {
            isInRange = true;
        }
        else if ((otherGO.tag == "marriedLady") && (this.tag == "youngBoy"))
        {
            NPC_Interaction nInt = otherGO.GetComponent<NPC_Interaction>();
            nInt.triggered = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GameObject otherGO = other.gameObject;
        //Debug.Log(other);
        if(otherGO.name == "Jawsh")
        {
            isInRange = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other);
        GameObject otherGO = other.gameObject;
        //Debug.Log(other);
        if(otherGO.name == "Jawsh")
        {
            isInRange = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        GameObject otherGO = other.gameObject;
        if(otherGO.name == "Jawsh")
        {
            isInRange = false;
        }
    }

    private void ClearText()
    {
        textbox.enabled = false;
        text.enabled = false;
    }

    public IEnumerator MoveManager()
    {
        float f = (int)Random.Range(waitMin, waitMax);

//        Debug.Log(f);

        yield return new WaitForSeconds(f);
        position2 = gameObject.transform.position;
        target = ChooseDirection();
        StopCoroutine("MoveManager");

        //yield return null;

    }

    public IEnumerator MoveDestManager()
    {
        //  Debug.Log("1: " + index);
        yield return new WaitForSeconds(waitDestTime);
        index = 0;
        triggered = false;
        StopCoroutine("MoveDestManager");
    }



    public Vector2 ChooseDirection()
    {
        System.Random ran = new System.Random();
        int r = positions.Length;

        int i = ran.Next(0, 4);

        //Vector2 temp = new Vector2();

        int count = 0;


        if (i == 0)
        { 
            vecArray[0] = positions[0];

          
            count = 0;

        }

        else if (i == 1)
        {
           
            vecArray[1] = positions[1];
           
            count = 1;


        }
        else if (i == 2)
        {
            
            vecArray[2] = positions[2];
            
            count = 2;

        }
        else if (i == 3)
        {
    

            vecArray[3] = positions[3];
            count = 3;

        }

        return vecArray[count];

    }

}

