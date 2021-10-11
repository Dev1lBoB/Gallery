using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenGalleryEvent : MonoBehaviour
{
    Camera      menuCam;
    Camera      mainCam;
    GameObject  settingsButton;
    GameObject  exitButton;
    GameObject  closeGalleryButton;
    GameObject  openGalleryButton;
    GameObject  menuTitle;

    public void OpenGallery()
    {
        // Hide/show all the necessery UI
        menuCam.enabled = !menuCam.enabled;
        mainCam.enabled = !mainCam.enabled;
        settingsButton.SetActive(true);
        exitButton.SetActive(false);
        closeGalleryButton.SetActive(true);
        MainClass.OpenGallery();
        openGalleryButton.SetActive(false);
        menuTitle.SetActive(false);
    }

    void Start()
    {
        menuCam = GameObject.Find("Menu Camera").GetComponent<Camera>();
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        openGalleryButton = GameObject.Find("OpenGalleryButton");
        closeGalleryButton = GameObject.Find("CloseGalleryButton");
        settingsButton = GameObject.Find("UserSettingsButton");
        exitButton = GameObject.Find("ExitButton");
        settingsButton.SetActive(false);
        closeGalleryButton.SetActive(false);
        menuTitle = GameObject.Find("MenuTitle");
    }
}
