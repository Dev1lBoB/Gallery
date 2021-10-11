using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainClass
{
    public static GameObject gallery = GameObject.Find("Gallery");

    public static CardInfo[] GetCardsInfo()
    {
        // Return the array of structures with information about all cards
        return gallery.GetComponent<Galery>().GetCardsInfo();
    }

    public static bool GetUserSettings()
    {
        /*
        ** Return the information about user setting
        ** (scroll to the first opened/closed card at the beggining)
        */
        return gallery.GetComponent<Galery>().GetUserSettings();
    }

    public static void OpenGallery()
    {
        // Load the saved data and start all the insidegallery processes
        SaveLoad.Load();
        gallery.GetComponent<Galery>().Begin();
        gallery.GetComponent<ScrollEvent>().Begin();
    }

    public static void CloseGallery()
    {
        // Save data and stop processes
        SaveLoad.Save(GetCardsInfo(), "CardsInfo");
        SaveLoad.Save(GetUserSettings(), "SettingsInfo");
        gallery.GetComponent<Galery>().End();
        gallery.GetComponent<ScrollEvent>().End();
    }
}
