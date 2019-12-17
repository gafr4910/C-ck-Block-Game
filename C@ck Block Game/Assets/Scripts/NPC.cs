using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{

    private Animator anim;
    private SpriteRenderer sr;

    public Image textbox;
    public Text text;
    public string npcName;
    public bool isInRange = false;
    public string[] barks;

    public float speed = 8;
    public int waitMin = 2;
    public int waitMax = 4;
    public Vector2[] positions;
    public Vector2[] destinations;
    public int waitDestTime;
    public string[] animations;
    
    private Vector2 target;
    private Vector2 position;
    private Vector2 position2;
    private int index = 0;
    public bool triggered = false;

    public int yBTalkNum;
    public int mLTalkNum;
    public bool yBTalked = false;
    public bool mLTalked = false;


    void Start()
    {
        textbox.enabled = false;
        text.enabled = false;
        npcName = name;

        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        position = gameObject.transform.position;
        target = ChooseDirection();

        if(target.x - position.x > 0)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }

        index = 0;
    }

    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.Space))
        {
            textbox.enabled = true;
            text.enabled = true;
            int rand = Random.Range(0, barks.Length);
            text.text = barks[rand];
            Invoke("ClearText", 5);
            
            if(tag == "youngBoy" && rand == yBTalkNum && !yBTalked)
            {
                yBTalked = true;
            }
            if(tag == "marriedLady" && rand == mLTalkNum && !mLTalked)
            {
                mLTalked = true;
            }
        }

        if (target != position && !triggered)
        {
            anim.CrossFade(animations[1], 0);
            position = gameObject.transform.position;
            float step = Time.deltaTime * speed;

            if (position2.x - gameObject.transform.position.x > 0)
            {
                sr.flipX = true;

            }
            else
            {
                sr.flipX = false;
            }

            transform.position = Vector2.MoveTowards(transform.position, target, step);
        }

        else if (!triggered)
        {
            //anim.CrossFade(animations[1], 0);
            StartCoroutine("MoveManager");
        }

        if (triggered)
        {
            StopCoroutine("MoveManager");

            if (index < destinations.Length)
            {
                position = gameObject.transform.position;
                if (destinations[index] != position)
                {
                    anim.CrossFade(animations[1], 0);
                    float step = Time.deltaTime * speed;
                    transform.position = Vector2.MoveTowards(transform.position, destinations[index], step);
                    if(destinations[index].x - position.x > 0)
                    {
                        sr.flipX = false;
                    }
                    else
                    {
                        sr.flipX = true;
                    }
                }

                else
                {
                    index++;

                    if (index >= destinations.Length)
                    {
                        anim.CrossFade(animations[0], 0);
                        position = transform.position;
                        //Debug.Log(target.x - position.x);
                        StartCoroutine("MoveDestManager");
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other);
        GameObject otherGO = other.gameObject;
        if(otherGO.name == "Jawsh")
        {
            isInRange = true;
        }
        if((this.tag == "youngBoy") && (otherGO.tag == "marriedLady"))
        {
            NPC nScript = otherGO.GetComponent<NPC>();
            nScript.triggered = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GameObject otherGO = other.gameObject;
        if(otherGO.name == "Jawsh")
        {
            isInRange = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log(other);
        GameObject otherGO = other.gameObject;
        if(otherGO.name == "Jawsh")
        {
            isInRange = true;
        }
        if((this.tag == "youngBoy") && (otherGO.tag == "marriedLady"))
        {
            NPC nScript = otherGO.GetComponent<NPC>();
            nScript.triggered = true;
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
        anim.CrossFade(animations[0],0);

        float f = (int)Random.Range(waitMin, waitMax);

        yield return new WaitForSeconds(f);
        position2 = gameObject.transform.position;
        target = ChooseDirection();
        StopCoroutine("MoveManager");
    }

    public IEnumerator MoveDestManager()
    {
        yield return new WaitForSeconds(waitDestTime);
        index = 0;
        triggered = false;
        position2 = gameObject.transform.position;
        StopCoroutine("MoveDestManager");
    }



    public Vector2 ChooseDirection()
    {
        int rand = Random.Range(0, positions.Length);
        if(positions.Length > 0)
        {
            return positions[rand];
        }
        else
        {
            return position;
        }
    }

}

