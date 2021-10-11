using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public CardInfo cardInfo;
    SelectEvent selectEvent;

    public bool isSelected
    {
        get
        {
            return cardInfo.isSelected;
        }
        set
        {
            if (value == true)
                transform.parent.GetComponent<Galery>().activeCardIndex = cardInfo.index;
            cardInfo.statusText.GetComponent<Text>().enabled = value;
            cardInfo.titleText.GetComponent<Text>().enabled = value;
            if (cardInfo.isOpened == true || value == false)
                cardInfo.descriptionText.GetComponent<Text>().enabled = value;
            cardInfo.isSelected = value;
        }
    }

    public void SetCardInfo(CardInfo ci)
    {
        // Set all information about the card
        cardInfo.index = ci.index;
        cardInfo.isSelected = ci.isSelected;
        cardInfo.isOpened = !ci.isOpened;
        
        // Open the card if it is necessary
        selectEvent.OpenCard(this);
    }

    public void SetStatus(string status)
    {
        // Change the opened/closed status
        cardInfo.statusText.GetComponent<Text>().text = status;
        if (status == "Opened")
            cardInfo.isOpened = true;
        else
            cardInfo.isOpened = false;
    }

    public void EnableDescription(bool status)
    {
        // Show description if the card is selected and opened
        if (cardInfo.isSelected == true && status == true)
        {
            cardInfo.descriptionText.GetComponent<Text>().enabled = true;
        }
        else
        {
            cardInfo.descriptionText.GetComponent<Text>().enabled = false;
        }
    }

    Transform FindWithTag(string tag)
    {
        // Find and return the child 3D model by the tag
        foreach (Transform t in GetComponentsInChildren<Transform>())
        {
            if (t.tag == tag) return t;
        }
        return null;
    }

    void Awake()
    {
        cardInfo.titleText = transform.Find("Canvas/Title");
        cardInfo.statusText = transform.Find("Canvas/Status");
        cardInfo.descriptionText = transform.Find("Canvas/Description");
        selectEvent = transform.Find("Quad").GetComponent<SelectEvent>();
    }
}
