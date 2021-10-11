using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct CardInfo
{
    // All the information about the card
    public int          index;
    [System.NonSerialized]
    public Transform    objectModel;
    [System.NonSerialized]
    public Transform    titleText;
    [System.NonSerialized]
    public Transform    descriptionText;
    [System.NonSerialized]
    public Transform    statusText;
    public bool         isSelected;
    public bool         isOpened;
}
