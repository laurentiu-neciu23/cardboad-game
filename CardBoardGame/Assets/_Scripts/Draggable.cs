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

    private GameObject getDropZone() {
        return null;        
    }


    public void OnDrag(PointerEventData eventData)
    {

        GameObject dropZone = GameObject.Find("WorldCanvas/Me_M_Panel");


        Image imageComponent = dropZone.GetComponent<Image>();
        Color color = imageComponent.color;
        color.a = 1.0f;
        imageComponent.color = color;
        this.transform.position = eventData.position;


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturn);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transformData)
        {
            this.transform.localScale = goodScale;
            this.transform.localEulerAngles = goodRotation;
            Vector3 givenPosition = this.transform.localPosition;
            givenPosition.z = 0;
            this.transform.localPosition = givenPosition;

        }


        GameObject dropZone = GameObject.Find("WorldCanvas/Me_M_Panel");
        Image imageComponent = dropZone.GetComponent<Image>();
        Color color = imageComponent.color;
        color.a = 0.3921f;
        imageComponent.color = color;
        Destroy(placeholder);
        Destroy(this);
    }
}
