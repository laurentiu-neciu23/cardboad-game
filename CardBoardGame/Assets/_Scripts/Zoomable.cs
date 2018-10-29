using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;

public class Zoomable : MonoBehaviour, IPointerClickHandler
{
    Vector3 goodPositon = new Vector3(0, 0, 0);
    Vector3 goodScale = new Vector3(0.2f, 0.2f, 0.2f);
    Quaternion goodRotation = Quaternion.Euler(0f, 0f, 0f);


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount >= 2) {
            GameObject playerCardZoomed = Instantiate(this.gameObject);
            GameObject parent = GameObject.Find("ScreenSpaceCanvas");
            playerCardZoomed.transform.SetParent(parent.transform);
            playerCardZoomed.transform.localRotation = goodRotation;
            playerCardZoomed.transform.localScale = goodScale;
            playerCardZoomed.transform.localPosition = goodPositon;
         
            Destroy(playerCardZoomed.GetComponent<Zoomable>());
            playerCardZoomed.AddComponent<Hiddenable>();
        }
    }
}