using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkCard : MonoBehaviour {


    public PlayerInfo player = null;
    public GameObject playerCard = null;
    public Quaternion goodRotation = Quaternion.Euler(10.0f, 0f, 0f);
    public Vector3 goodScale = new Vector3(0.16f, 0.16f, 0.2f);


	// Use this for initialization
	void Start () {
        if (player == null)
            return;

        if (player.isLocalPlayer) {
            GameObject parent = GameObject.Find("WorldCanvas/Me_M_Panel/Grid");
            GameObject card = Instantiate(playerCard);
            Destroy(playerCard);
            card.transform.SetParent(parent.transform);
            Destroy(card.GetComponent<Draggable>());
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

    private void correctlyPosition(GameObject card) {
        Destroy(card.GetComponent<Draggable>());
        card.transform.localRotation = goodRotation;
        card.transform.localScale = goodScale;
        Vector3 pos = card.transform.localPosition;
        card.transform.localPosition = new Vector3(pos.x, pos.y, 0);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
