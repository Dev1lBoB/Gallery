using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectEvent : MonoBehaviour
{

    public Material     onClickMaterial;
    public Material     standardMaterial;
    public MeshRenderer mesh;
    public Transform    cardTrans;

    Vector2 mousePos;

    void Start()
    {
        mousePos = Vector2.zero;
    }

    public void OpenCard(Card card)
    {
        // Open/close the card
        if (card.cardInfo.isOpened == false)
        {
            mesh.material = onClickMaterial; // Special transparent material with shader with stencil effect
            card.SetStatus("Opened");
        }
        else
        {
            mesh.material = standardMaterial;
            card.SetStatus("Closed");
        }
        card.EnableDescription(card.cardInfo.isOpened);
    }

    void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
            mousePos = Input.mousePosition;
    }

    void OnMouseUp()
    {
        if (Vector2.Distance(mousePos, Input.mousePosition) > 1f) // Check if it was tap and not scroll
            return;
        Card card = transform.parent.GetComponent<Card>();
        if (card.isSelected)
            OpenCard(card);
    }
}
