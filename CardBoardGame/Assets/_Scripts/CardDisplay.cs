using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

    public Text Attack;
    public Text Defense;
    public Text Name;
    public Text Description;
    public Text Team;
    public Image artwork;
    public Image template;
    public Image type_icon;


    public Sprite templateA;
    public Sprite templateM;
    public Sprite templateF;

    public Sprite iconA;
    public Sprite iconM;
    public Sprite iconF;

    [Header("Card info to be displayed:")]
    public PlayerCard card;

    // Use this for initialization
    void Start () {
        if(card.artwork!=null)
            artwork.sprite = card.artwork;
        ChooseTemplate();
        UpdateDisplay();
	}

    private void Update()
    {
        UpdateDisplay(); // does this every frame, not efficient
    }


    public void UpdateDisplay()
    {
        ChooseTemplate();
        artwork.sprite = card.artwork; // do we need this here? prolly not
        Name.text = card.PlayerName;
        Attack.text = card.AttackPoints.ToString();
        Defense.text = card.DefensePoints.ToString();
        Description.text = card.Description;
        Team.text = card.Team;
    }

    public void ChooseTemplate()
    {
        if (card.position == "A")
        {
            template.sprite = templateA;
            type_icon.sprite = iconA;
        }
        if (card.position == "M")
        {
            template.sprite = templateM;
            type_icon.sprite = iconM;
        }
        if (card.position == "F")
        {
            template.sprite = templateF;
            type_icon.sprite = iconF;
        }
    }
}
