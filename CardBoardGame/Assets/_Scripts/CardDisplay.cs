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

    public PlayerCard card;

	// Use this for initialization
	void Start () {
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
}
