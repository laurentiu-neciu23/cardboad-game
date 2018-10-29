using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyScoreCalculator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        GameObject myCardsDown = GameObject.Find("MyCardsDown");
        CardDisplay[] cardDatas = myCardsDown.GetComponentsInChildren<CardDisplay>();

        int sum = 0;
        foreach (CardDisplay card in cardDatas) {

            sum += System.Int32.Parse(card.Attack.text.ToString());
            sum += System.Int32.Parse(card.Defense.text.ToString());
        }

        Text textComponent = this.GetComponent<Text>();
        textComponent.text = "Score: " + sum.ToString();

    }
}
