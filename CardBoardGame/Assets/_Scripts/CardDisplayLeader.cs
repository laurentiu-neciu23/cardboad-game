using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplayLeader : MonoBehaviour
{

    public Text Description;
    public Text Name;
    public Image Artwork;

    [Header("Card info to be displayed:")]
    public LeaderCard card;

    void Start()
    {
        if (card.artwork != null)
            Artwork.sprite = card.artwork;
        UpdateDisplay();
    }

    private void Update()
    {
        UpdateDisplay(); // does this every frame, not efficient
    }


    public void UpdateDisplay()
    {

        Artwork.sprite = card.artwork; 
        Name.text = card.name.ToString();
        Description.text = card.Description;
    }

    public void AssignCard(LeaderCard _card)
    {
        card = _card;
    }
}
