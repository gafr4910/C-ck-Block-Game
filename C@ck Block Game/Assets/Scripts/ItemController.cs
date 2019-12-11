using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject[] Items;
    public GameObject[] FakeProposalItems;
    public GameObject[] FakeProposalNPCs;
    public GameObject Jawsh;
    public GameObject Todd;
    public GameObject Linda;

    private bool allPickedUp = true;

    void Update()
    {
        foreach(GameObject i in Items)
        {
            if(i.name == "Waiter Bundle" && !i.activeSelf)
            {
                GameObject j = GameObject.Find("Jawsh");
                JawshMovement jMove = j.GetComponent<JawshMovement>();
                jMove.hasWaiterDisguise = true;
            }
        }

        foreach(GameObject i in FakeProposalItems)
        {
            GameObject checkItem = GameObject.Find(i.name);
            Item itemScript = checkItem.GetComponent<Item>();
            //Debug.Log(itemScript.isPickedUp);
            if(!itemScript.isPickedUp)
            {
                allPickedUp = false;
                //Debug.Log("Nay!");
            }
        }
        if(allPickedUp)
        {
            GameObject t = GameObject.Find("Todd");
            Formal_script tAct= t.GetComponent<Formal_script>();
            tAct.triggered = true;
            GameObject l = GameObject.Find("Linda");
            Linda_script lAct = l.GetComponent<Linda_script>();
            lAct.triggered = true;
            //Debug.Log("yay!");
        }
        else if(!allPickedUp)
        {
            allPickedUp = true;
        }
    }
}
