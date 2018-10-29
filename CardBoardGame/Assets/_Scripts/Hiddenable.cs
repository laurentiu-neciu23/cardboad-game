using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Hiddenable : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount > 0) {
            Destroy(this.gameObject);
        }

    }
}
