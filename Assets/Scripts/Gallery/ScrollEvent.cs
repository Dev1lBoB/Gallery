using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollEvent : MonoBehaviour
{
    bool dragging;
    bool galeryOpened;
    Collider coll;
    float mouseXPos;
    Vector3 newPos;
    float xPos;
    float rightEdge;
    public int   target;

    int castRayToSelectCard()
    {
        // Detect the card at the middle of the screen and select it
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); // Ray to the center of the screen
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {           
            Card card = hit.transform.parent.GetComponent<Card>();
            if (card)
            {
                card.isSelected = true;
                return card.cardInfo.index;
            }
        }
        return 0;
    }

    int scroll()
    {
        // Scroll gallery to the left/right
        if ((xPos < 0 || newPos[0] < 0) && (xPos > 0 || newPos[0] > rightEdge))
        {
            newPos[0] += xPos / 10000;
            transform.position = newPos;
            return castRayToSelectCard();
        }
        return 0;
    }

    void Start()
    {
        mouseXPos = 0f;
        dragging = false;
        galeryOpened = false;
        coll = GetComponent<Collider>();
        newPos = transform.position;
        xPos = 0f;
        float size = transform.localScale[0];
        float step = size / GetComponent<Galery>().GetNumOfCards();
        rightEdge = -size + step;
    }

    public void Begin()
    {
        galeryOpened = true;
        castRayToSelectCard();
    }

    public void End()
    {
        newPos[0] = 0;
        transform.position = newPos;
        galeryOpened = false;
    }

    void Update()
    {
        if (galeryOpened == false) // Do nothing if we aren't in the gallery yet
            return;
        
        // Scroll to the target at the moment of the openning of the gallery
        if (target != 0)  
        {
            xPos = -300f;
            if (scroll() == target)
                target = 0;
        }

        if (Input.GetMouseButtonDown(0))
        {
            dragging = true;
            mouseXPos = Input.mousePosition[0];
        }

        if (dragging)
        {
            xPos = Input.mousePosition[0] - mouseXPos;
            scroll();
        }
        else if (xPos != 0f) // Save some inertia for smoothness
        {
            xPos -= 3f * Mathf.Sign(xPos);
            scroll();
            if (Mathf.Abs(xPos) < 10f)
                xPos = 0f;
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
            mouseXPos = 0f;
        }
    }
}
