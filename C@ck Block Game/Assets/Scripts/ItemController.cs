using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public GameObject[] Items;
    public GameObject[] FakeProposalItems;
    public GameObject[] FakeProposalNPCs;
    public GameObject Jawsh;
    public GameObject Todd;
    public GameObject Linda;
    public GameObject[] OperationCheatItems;
    public GameObject[] OperationCheatNPCs;

    private bool allPickedUpFP = true;
    private bool allPickedUpOC = true;
    private bool bothTalkedTo = true;

    //UI Variables
    public GameObject UIWaiterBundle;
    public Sprite SpriteWaiterBundle;
    public GameObject UIFlowers;
    public Sprite SpriteFlowers;
    public GameObject UIChampagne;
    public Sprite SpriteChampagne;
    public GameObject UIRing;
    public Sprite SpriteRing;

    void Update()
    {
        foreach(GameObject i in Items)
        {
            SpriteRenderer sRend = i.GetComponent<SpriteRenderer>();
            if(i.name == "Waiter Bundle" && !sRend.enabled)
            {
                GameObject j = GameObject.Find("Jawsh");
                JawshMovement jMove = j.GetComponent<JawshMovement>();
                jMove.hasWaiterDisguise = true;
            }

            //UI Check
            GameObject checkWaiterBundle = GameObject.Find("Waiter Bundle");
            Item itemScript1 = checkWaiterBundle.GetComponent<Item>();
            if (itemScript1.isPickedUp)
            {
                UIWaiterBundle.GetComponent<Image>().overrideSprite = SpriteWaiterBundle;
            }

            GameObject checkFlowers = GameObject.Find("Flowers");
            Item itemScript2 = checkFlowers.GetComponent<Item>();
            if (itemScript2.isPickedUp)
            {
                UIFlowers.GetComponent<Image>().overrideSprite = SpriteFlowers;
            }

            GameObject checkChampagne = GameObject.Find("Champagne");
            Item itemScript3 = checkChampagne.GetComponent<Item>();
            if (itemScript3.isPickedUp)
            {
                UIChampagne.GetComponent<Image>().overrideSprite = SpriteChampagne;
            }

            GameObject checkRing = GameObject.Find("Ring");
            Item itemScript4 = checkRing.GetComponent<Item>();
            if (itemScript4.isPickedUp)
            {
                UIRing.GetComponent<Image>().overrideSprite = SpriteRing;
            }
        }

        foreach(GameObject i in FakeProposalItems)
        {
            GameObject checkItem = GameObject.Find(i.name);
            Item itemScript = checkItem.GetComponent<Item>();
            //Debug.Log(itemScript.isPickedUp);
            if(!itemScript.isPickedUp)
            {
                allPickedUpFP = false;
                //Debug.Log("Nay!");
            }
        }
        if(allPickedUpFP)
        {
            GameObject t = GameObject.Find("Todd");
            Formal_script tAct= t.GetComponent<Formal_script>();
            tAct.triggered = true;
            GameObject l = GameObject.Find("Linda");
            Linda_script lAct = l.GetComponent<Linda_script>();
            lAct.triggered = true;
            //Debug.Log("yay!");
        }
        else if(!allPickedUpFP)
        {
            allPickedUpFP = true;
        }


        foreach (GameObject n in OperationCheatNPCs)
        {
            NPC npcScript = n.GetComponent<NPC>();
            if(n.tag == "youngBoy" && !npcScript.yBTalked)
            {
                //Debug.Log("a");
                bothTalkedTo = false;
            }
            if(n.tag == "marriedLady" && !npcScript.mLTalked)
            {
                //Debug.Log("b");
                bothTalkedTo = false;
            }
        }
        //Debug.Log(bothTalkedTo);
        if(bothTalkedTo)
        {
            NPC npcScript = OperationCheatNPCs[0].GetComponent<NPC>();
            //Debug.Log("here?");
            npcScript.triggered = true;
            Item iScript = OperationCheatItems[0].GetComponent<Item>();
            iScript.isVisible = true;
            if(!iScript.isPickedUp)
            {
                SpriteRenderer sr = OperationCheatItems[0].GetComponent<SpriteRenderer>();
                sr.enabled = true;
            }
        }

        bothTalkedTo = true;

        foreach (GameObject i in OperationCheatItems)
        {
            GameObject checkItem = GameObject.Find(i.name);
            Item itemScript = checkItem.GetComponent<Item>();
            //Debug.Log(itemScript.isPickedUp);
            if (!itemScript.isPickedUp)
            {
                allPickedUpOC = false;
                //Debug.Log("Nay!");
            }
        }
        if (allPickedUpOC)
        {
            foreach(GameObject npc in OperationCheatNPCs)
            {
                NPC_Interaction nInt = npc.GetComponent<NPC_Interaction>();
                nInt.triggered = true;
            }
        }
        else if (!allPickedUpOC)
        {
            allPickedUpOC = true;
        }
    }
}
