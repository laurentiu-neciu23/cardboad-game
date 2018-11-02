using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler  {

    public Transform parentToReturn = null;
    public bool transformData = false;
    public Vector3 goodScale = new Vector3(0.16f, 0.16f, 1f);
    public Vector3 goodRotation = new Vector3(10f, 0, 0);


    GameObject placeholder = null;

    public void OnBeginDrag(PointerEventData eventData) {
        // Bind this object to the canvas 
        parentToReturn = this.transform.parent;
        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
        this.transform.SetParent(parentToReturn.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        GameObject dropZone = determineDropZone();
        setColourAlpha(dropZone, 1);
        this.transform.position = eventData.position;

    }

    public void OnEndDrag(PointerEventData eventData)
    {

        GameObject dropZone = determineDropZone();
        setColourAlpha(dropZone, 0.3921f);
        
        if (parentToReturn == null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            Debug.Log("Return to hell");
            this.transform.SetParent(parentToReturn.transform);
        }    

    }


    private GameObject determineDropZone() {
        GameObject dropZone = null;
        string position = gameObject.GetComponent<CardDisplay>().card.position;

        if (position == "M")
        {
            dropZone = GameObject.Find("WorldCanvas/Me_M_Panel");
        }
        else if (position == "F")
        {
            dropZone = GameObject.Find("WorldCanvas/Me_F_Panel");
        }
        else {
            dropZone = GameObject.Find("WorldCanvas/Me_A_Panel");
        }

        return dropZone;
    }

    private void setColourAlpha(GameObject dropZone, float alpha) {
        Image imageComponent = dropZone.GetComponent<Image>();
        Color color = imageComponent.color;
        color.a = alpha;
        imageComponent.color = color;
        Destroy(placeholder);
    }
}
