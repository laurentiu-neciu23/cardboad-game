using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkCard : MonoBehaviour {

    public string typeOfCard;
    public GameObject player = null;
    public GameObject playerCardPrefab = null;
    public PlayerCard card= null;
    

	// Use this for initialization
	void Start () {
        Debug.Log("Spawning" + card.name);
        if (player == null)
            return;

        if (player.GetComponent<PlayerInfo>().isLocalPlayer) {
            GameObject parent = determineDropZone("Me");
            transformAccordingToGrid(parent);
        }
        else {
            GameObject parent = determineDropZone("Adv");
            transformAccordingToGrid(parent);
        }

   	}

    private GameObject determineDropZone(string prefix)
    {
        GameObject dropZone = null;
        string position = card.position;

        if (position == "M")
        {
            dropZone = GameObject.Find("WorldCanvas(Clone)/" + prefix + "_M_Panel/Grid");
        }
        else if (position == "F")
        {
            dropZone = GameObject.Find("WorldCanvas(Clone)/" + prefix + "_F_Panel/Grid");
        }
        else
        {
            dropZone = GameObject.Find("WorldCanvas(Clone)/" + prefix + "_A_Panel/Grid");
        }

        return dropZone;
    }

    private void transformAccordingToGrid(GameObject parent) {

        GameObject playerCard = Instantiate(playerCardPrefab);
        playerCard.GetComponent<CardDisplay>().card = card;

        playerCard.transform.SetParent(parent.transform, false);
        float canvasWidth = playerCard.GetComponentsInChildren<RectTransform>()[1].sizeDelta.y;
        float gridWitdth = playerCard.GetComponent<RectTransform>().sizeDelta.y;

        float prefferedScale = gridWitdth / canvasWidth;

        playerCard.transform.localScale = new Vector3(prefferedScale, prefferedScale, 1);
        Destroy(playerCard.GetComponent<Draggable>());

    }


}
