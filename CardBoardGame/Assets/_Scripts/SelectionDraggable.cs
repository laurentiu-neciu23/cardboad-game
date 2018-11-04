using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectionDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Transform parentToReturn = null;


    GameObject placeholder = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
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

        GetComponent<CanvasGroup>().blocksRaycasts = true;
        this.transform.SetParent(parentToReturn.transform);
       

    }


    private GameObject determineDropZone()
    {
        GameObject dropZone = GameObject.Find("SelectionCanvas/SelectionDropZone");
        return dropZone;
    }

    private void setColourAlpha(GameObject dropZone, float alpha)
    {
        Image imageComponent = dropZone.GetComponent<Image>();
        Color color = imageComponent.color;
        color.a = alpha;
        imageComponent.color = color;
    }
}
