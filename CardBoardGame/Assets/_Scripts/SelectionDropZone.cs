using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionDropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public PlayerInfo currentPlayer;
    public GameObject dropEffect;
    private int counter = 0;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject pointerDrag = eventData.pointerDrag;

        if (pointerDrag != null)
        {
            pointerDrag.GetComponent<SelectionDraggable>().parentToReturn = this.gameObject.transform;
            GameObject effect = Instantiate(dropEffect, transform.position, Quaternion.identity);
            effect.transform.SetParent(transform.parent);
            Destroy(effect, 3);
            counter++;
            if (counter == 12) {
                currentPlayer.TriggerFinishRoundPlayer();
            }
        }


    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
}