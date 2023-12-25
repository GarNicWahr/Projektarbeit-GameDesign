using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public GameObject SlotItem;
    private bool moving;

    // starting Position
    private float startPosX;
    private float startPosY;

    private Vector3 slotPosition;
    

    private void Start()
    {
        slotPosition = this.transform.localPosition;
    }
    void Update()
    {
        if (moving)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;

        if (Mathf.Abs (this.transform.localPosition.x - SlotItem.transform.localPosition.x) <= 2f &&
            Mathf.Abs(this.transform.localPosition.y - SlotItem.transform.localPosition.y) <= 2f)
        {
            // Snap the item to the slot position
            this.transform.localPosition = new Vector3(SlotItem.transform.localPosition.x, SlotItem.transform.localPosition.y, SlotItem.transform.localPosition.z);
        }
        else
        {
            this.transform.localPosition = new Vector3(slotPosition.x, slotPosition.y, slotPosition.z);
        }
    }
}

