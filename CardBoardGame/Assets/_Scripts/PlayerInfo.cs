using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerInfo : NetworkBehaviour
{ 
    public PlayerCard[] playerCardsInHand;

    public GameObject playerCardPrefab;
    public GameObject networkPlayerCard;
    public Vector3 goodScale = new Vector3(0.09f, 0.09f, 0.2f);

    public GameObject playerCardToSpawn = null;
    // Use this for initialization
    void Start()
    {
        // Fetch all card assets
        playerCardsInHand = fetchDataFromBundle();
        reshuffle(playerCardsInHand);

        GenerateCards();
        SetDropZone();
    }
    [Command]
    public void CmdSpawnNetworkCard()
    {
        GameObject networkCardToSpawn = Instantiate(networkPlayerCard);
        NetworkCard nc = networkCardToSpawn.GetComponent<NetworkCard>();
        nc.playerCard = playerCardToSpawn;
        nc.player = this;
        NetworkServer.Spawn(networkCardToSpawn);
    }

    private void SetDropZone()
    {
        if (isLocalPlayer)
        {
            GameObject go = GameObject.Find("WorldCanvas/Me_M_Panel");
            go.GetComponent<DropZone>().currentPlayer = this;
        }
    }


    private PlayerCard[] fetchDataFromBundle() {

        AssetBundle asb = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, "AssetBundles/cards"));
        PlayerCard[] playerCards = asb.LoadAllAssets<PlayerCard>();
        asb.Unload(false);

        return playerCards;
    }


    private void reshuffle(Object[] data)
    {
        for (int t = 0; t < data.Length; t++)
        {
            Object aux = data[t];
            int r = Random.Range(t, data.Length);
            data[t] = data[r];
            data[r] = aux;
        }
    }

    void GenerateCards()
    {

        if (isLocalPlayer)
        {

            for (int i = 0; i < 10; i++)
            {
                GameObject hands = GameObject.Find("ScreenSpaceCanvas/Hands");

                GameObject card = Instantiate(playerCardPrefab);
                card.transform.SetParent(hands.transform);
                card.transform.localScale = goodScale;
                Vector3 localPos = card.transform.localPosition;
                card.transform.localPosition = new Vector3(localPos.x, localPos.y, 0);
                CardDisplay cardDisplayComponent = card.GetComponent<CardDisplay>();
                cardDisplayComponent.card = playerCardsInHand[i];
                cardDisplayComponent.UpdateDisplay();

            }
        }
    }
}

 
