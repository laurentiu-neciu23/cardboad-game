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

    public PlayerCard card;

    public Sprite templateA;
    public Sprite templateM;
    public Sprite templateF;

    // Use this for initialization
    void Start () {
        if(card.artwork!=null)
            artwork.sprite = card.artwork;
        ChooseTemplate();
        UpdateDisplay();
	}

    private void Update()
    {
        UpdateDisplay();
    }


    public void UpdateDisplay()
    {
        Name.text = card.PlayerName;
        Attack.text = card.AttackPoints.ToString();
        Defense.text = card.DefensePoints.ToString();
        Description.text = card.Description;
        Team.text = card.Team;
    }

    public void ChooseTemplate()
    {
        if (card.position == "A")
            template.sprite = templateA;
        if (card.position == "M")
            template.sprite = templateM;
        if (card.position == "F")
            template.sprite = templateF;
    }
}
