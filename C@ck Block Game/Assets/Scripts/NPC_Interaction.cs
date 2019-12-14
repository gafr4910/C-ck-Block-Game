using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Interaction : MonoBehaviour
{
    public Image textbox;
    public Text text;
    public string npcName;
    public bool isInRange = false;
    //public bool isPickedUp = false;
    public string[] barks;
    
    void Start()
    {
        textbox.enabled = false;
        text.enabled = false;
        npcName = name;
    }

    void Update()
    {
        //Debug.Log(isInRange);
        if(isInRange && Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("yep");
            //isPickedUp = true;
            //this.gameObject.SetActive(false);
            textbox.enabled = true;
            text.enabled = true;
            Invoke("ClearText", 2);
            Debug.Log("1?");
        }
        //Debug.Log(isPickedUp);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherGO = other.gameObject;
        //Debug.Log(other);
        if(otherGO.name == "Jawsh")
        {
            isInRange = true;
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
}
