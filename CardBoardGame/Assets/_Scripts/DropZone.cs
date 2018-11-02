using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    private float normalScale = 0.16f;
    private double normalRotation = 10;
    public PlayerInfo currentPlayer;


    public void OnDrop(PointerEventData eventData)
    {
        GameObject pointerDrag = eventData.pointerDrag;

        if (pointerDrag != null) {
            currentPlayer.CmdSpawnNetworkCard(pointerDrag.GetComponent<CardDisplay>().Name.text, currentPlayer.netId.Value);
            pointerDrag.GetComponent<Draggable>().parentToReturn = null;
        }

        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
}
