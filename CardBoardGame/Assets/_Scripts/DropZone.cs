﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    private float normalScale = 0.16f;
    private double normalRotation = 10;
    public PlayerInfo currentPlayer = null;


    public void OnDrop(PointerEventData eventData)
    {
        GameObject pointerDrag = eventData.pointerDrag;

        if (pointerDrag != null) {
            currentPlayer.playerCardToSpawn = pointerDrag;
            currentPlayer.CmdSpawnNetworkCard();
        }

        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
}