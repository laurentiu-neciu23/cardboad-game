using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Card", menuName = "Cards/Player Card")]
public class PlayerCard : ScriptableObject {

    [Header("Player Stats")]
    public string PlayerName;
    public int AttackPoints;
    public int DefensePoints;
    public string Description;
    public string Team;
    [Header("Position: A or M or F (atacant, mijlocas sau fundas)")]
    public string position;




    public Sprite artwork;


	void TakeAttack (int amount) {
        AttackPoints -= amount;
	}

    bool isAtacant() {
        if (position == "A")
            return true;
        return false;
    }

    bool isMijlocas() {
        if (position == "M")
            return true;
        return false;
    }

    bool isFundas() {
        if (position == "F")
            return true;
        return false;
    }


    // Update is called once per frame
    void Update () {
		
	}
}
