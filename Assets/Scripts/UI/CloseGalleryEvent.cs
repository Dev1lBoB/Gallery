using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseGalleryEvent : MonoBehaviour
{
    Camera      menuCam;
    Camera      mainCam;
    GameObject  settingsButton;
    GameObject  exitButton;
    GameObject  closeGalleryButton;
    GameObject  openGalleryButton;
    GameObject  menuTitle;

    public void CloseGallery()
    {
        // Hide/show all the necessery UI
        menuCam.enabled = !menuCam.enabled;
        mainCam.enabled = !mainCam.enabled;
        MainClass.CloseGallery();
        exitButton.SetActive(true);
        settingsButton.SetActive(false);
        openGalleryButton.SetActive(true);
        closeGalleryButton.gameObject.SetActive(false);
        menuTitle.SetActive(true);
    }

    void Start()
    {
        menuCam = GameObject.Find("Menu Camera").GetComponent<Camera>();
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        closeGalleryButton = GameObject.Find("CloseGalleryButton");
        openGalleryButton = GameObject.Find("OpenGalleryButton");
        settingsButton = GameObject.Find("UserSettingsButton");
        exitButton = GameObject.Find("ExitButton");
        menuTitle = GameObject.Find("MenuTitle");
    }
}
