using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkCard : MonoBehaviour {

    public string typeOfCard;
    public GameObject player = null;
    public GameObject playerCard = null;
    public Quaternion goodRotation = Quaternion.Euler(0f, 0f, 0f);
    public Vector3 goodScale = new Vector3(0.055f, 0.055f, 0.1f);


	// Use this for initialization
	void Start () {
        if (player == null)
            return;

        if (player.GetComponent<PlayerInfo>().isLocalPlayer) {
            Debug.Log("Hello I am the player and I put card down birb");
            GameObject parent = GameObject.Find("WorldCanvas/Me_M_Panel/Grid");
            GameObject card = Instantiate(playerCard);

            Destroy(playerCard);

            card.transform.SetParent(parent.transform, false);
            float canvasWidth = card.GetComponentsInChildren<RectTransform>()[1].sizeDelta.y;
            float gridWitdth = card.GetComponent<RectTransform>().sizeDelta.y;

            float prefferedScale = gridWitdth / canvasWidth;

            card.transform.localScale = new Vector3(prefferedScale, prefferedScale, 1);
            Destroy(card.GetComponent<Draggable>());

            //correctlyPosition(card);
        }
        else {
            Debug.Log("Whatever not done yet");

            GameObject parent = GameObject.Find("WorldCanvas/EnemyCardsDown");
            GameObject card = Instantiate(playerCard);
            card.transform.SetParent(parent.transform);
            correctlyPosition(card);

        }
        Destroy(this.gameObject);
   	}

    private void setRayCastBlockingFalse(GameObject parent) {
        CanvasGroup[] canvasGroups = parent.GetComponentsInParent<CanvasGroup>();

        foreach (CanvasGroup canvas in canvasGroups) {
            canvas.blocksRaycasts = true;
        }
       


    }

    private void correctlyScaleToGrid(GameObject element, GameObject grid) {


    }

    private void correctlyPosition(GameObject card) {
        Destroy(card.GetComponent<Draggable>());

    }

	// Update is called once per frame
	void Update () {
		
	}
}
