using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;

public class Zoomable : MonoBehaviour, IPointerClickHandler {


    public void OnPointerClick(PointerEventData eventData)
    {


        if (eventData.clickCount >= 1) {
            GameObject parent = GameObject.Find("CardPreview");
            if (parent.transform.childCount != 0)
            {
                GameObject parentChild = parent.transform.GetChild(0).gameObject;
                Destroy(parentChild);
            }
            GameObject playerCardZoomed = Instantiate(this.gameObject);
            playerCardZoomed.transform.SetParent(parent.transform);
            playerCardZoomed.transform.localScale = new Vector3(0.25f, 0.27f, 1f);


         
            Destroy(playerCardZoomed.GetComponent<Zoomable>());
            playerCardZoomed.AddComponent<Hiddenable>();
        }
    }


  
}