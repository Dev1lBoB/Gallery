using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Galery : MonoBehaviour
{
    public bool userSettings;
    Card[]      cards;
    Text        userSettingsButtonText;

    private int _activeCardIndex;
    public int  activeCardIndex
    {
        get
        {
            return _activeCardIndex;
        }
        set
        {
            // Deactivate the current active card and set the new one
            cards[_activeCardIndex].isSelected = false;
            _activeCardIndex = value;
        }
    }

    void Start()
    {
        _activeCardIndex = 0;
        cards = GetComponentsInChildren<Card>();
    }

    public void Begin()
    {
        userSettingsButtonText = GameObject.Find("UserSettingsButton/Text").GetComponent<Text>();
        userSettings = !SaveLoad.savedSettings;
        ChangeUserSettings();
        int size = cards.Length;

        // Apply all the saved data to the relevant cards
        for (int i = 0; i < size; i++)
        {
            cards[i].SetCardInfo(SaveLoad.savedCards[i]);
            cards[i].cardInfo.index = i;
        }

        /*
        ** Detect the target for the scroll up at the openning monment
        ** depending on the user settings
        */
        int target = 0;
        foreach (var c in cards)
        {
            if (c.cardInfo.isOpened == userSettings)
            {
                target = c.cardInfo.index;
                break ;
            }
        }
        GetComponent<ScrollEvent>().target = target;
    }

    public void End()
    {
        // Hide all the UI of every card
        foreach (var c in cards)
        {
            c.cardInfo.titleText.GetComponent<Text>().enabled = false;
            c.cardInfo.statusText.GetComponent<Text>().enabled = false;
            c.cardInfo.descriptionText.GetComponent<Text>().enabled = false;
        }
    }

    void OnApplicationQuit()
    {
        // Save everything before quit
        MainClass.CloseGallery();
    }

    public CardInfo[] GetCardsInfo()
    {
        // Return the array of information about every card
        CardInfo[] cardInfo = new CardInfo[cards.Length];
        for (int i = 0; i < cards.Length; i++)
            cardInfo[i] = cards[i].cardInfo;
        return cardInfo;
    }

    public bool GetUserSettings()
    {
        // Return the information about user settings
        return userSettings;
    }

    public int GetNumOfCards()
    {
        // Return the count of all cards
        return cards.Length;
    }

    public void ChangeUserSettings()
    {
        // Change user settings and text on the settings button
        userSettings = !userSettings;
        if (userSettings == true)
            userSettingsButtonText.text = "Starting from opened";
        else
            userSettingsButtonText.text = "Starting from closed";
    }
}