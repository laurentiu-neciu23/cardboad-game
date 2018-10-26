using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPlacer : MonoBehaviour {
    //this script places the player's card on its respective tile, A, M or F
    public GameObject my_A_panel;
    public GameObject my_M_panel;
    public GameObject my_F_panel;

    public GameObject card_prefab;
    
    //remove this; it's for testing the feature
    public PlayerCard test;

    // Use this for initialization
    void Start () {
        //remove this test thing later
        PlceCardOnField(test);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlceCardOnField(PlayerCard card)
    {
        //depending on player type (position), parent it to the according Panel
        Transform the_parent = null;
        if (card.position == "A")
            the_parent = my_A_panel.transform;
        if (card.position == "M")
            the_parent = my_M_panel.transform;
        if (card.position == "F")
            the_parent = my_F_panel.transform;


        //creating the actual card template
        GameObject this_card = Instantiate(card_prefab, the_parent);
        //assigning the template its player information to display
        this_card.GetComponent<CardDisplay>().AssignCard(card);
        //eventually add this_card to a list of instantiated cards or something, to check them later
    }


}
