﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Leader Card")]
public class LeaderCard : ScriptableObject 
{
    public string Name;
    public string Description;
    public string Forte;
    [Header("Please use a 1200 x 800 px image imported as Sprite(2D and UI)")]
    public Sprite artwork;
    [Header("Link to a prefab containing a Component that inherits the Ability abstract class")]
    public GameObject ability;

    public void UseAbility()
    {
        if(ability!=null)
            ability.GetComponent<Ability>().PerformAbility();
    }
}