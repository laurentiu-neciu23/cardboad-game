using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeaderSelectionDropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public PlayerInfo currentPlayer;
    public GameObject dropEffect;
    private void Update()
    {
        if (GetComponentsInChildren<CardDisplayLeader>().Length == 1 &&  currentPlayer != null)
        {
            Debug.Log("Futamas" + GetComponentsInChildren<CardDisplayLeader>().Length);
            currentPlayer.TriggerFinishLeaderRound();

        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject pointerDrag = eventData.pointerDrag;

        if (pointerDrag != null)
        {
            pointerDrag.GetComponent<LeaderSelectionDraggable>().parentToReturn = this.gameObject.transform;
            GameObject effect = Instantiate(dropEffect, transform.position, Quaternion.identity);
            effect.transform.SetParent(transform.parent);
            Destroy(effect, 3);
        }


    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
}