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


    // Use this for initialization
    void Start()
    {
        // Fetch all card assets
        playerCardsInHand = fetchDataFromBundle();
        reshuffle(playerCardsInHand);

        GenerateCards();
        SetDropZone();
        Debug.Log(this.netId);
    }


    [Command]
    public void CmdSpawnNetworkCard(string playerCardToSpawn, uint playerInfo)
    {
        GameObject networkCard = Instantiate(networkPlayerCard);
        NetworkServer.Spawn(networkCard);
        RpcSetTypeToCard(networkCard, playerCardToSpawn, playerInfo);
        setDataCorrectly(networkCard, playerCardToSpawn, playerInfo);
    }


    [ClientRpc]
    private void RpcSetTypeToCard(GameObject networkCard, string playerCardToSpawn, uint playerInfo) {
        setDataCorrectly(networkCard, playerCardToSpawn, playerInfo);
    }

    private void setDataCorrectly(GameObject networkCard, string playerCardToSpawn, uint playerInfo) {

        NetworkCard nc = networkCard.GetComponent<NetworkCard>();
        PlayerInfo player = null;
        var playerInfos = FindObjectsOfType<PlayerInfo>();
        foreach (PlayerInfo p in playerInfos)
        {
            if (p.netId.Value == playerInfo)
            {
                player = p;
            }
        }

        PlayerCard foundPc = null;
        var playerCards = player.GetComponent<PlayerInfo>().playerCardsInHand;
        foreach (PlayerCard pc in playerCards)
        {
            if (pc.PlayerName == playerCardToSpawn)
            {
                foundPc = pc;
                break;
            }

        }
        nc.card = foundPc;
        nc.player = player.gameObject;
    }

    private void SetDropZone()
    {
        if (isLocalPlayer)
        {
            GameObject.Find("WorldCanvas/Me_M_Panel").GetComponent<DropZone>().currentPlayer = this;
            GameObject.Find("WorldCanvas/Me_F_Panel").GetComponent<DropZone>().currentPlayer = this;
            GameObject.Find("WorldCanvas/Me_A_Panel").GetComponent<DropZone>().currentPlayer = this;
        }
    }


    private PlayerCard[] fetchDataFromBundle() {

        AssetBundle asb = null;
        PlayerCard[] playerCards = null;
        try
        {
            asb = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "AssetBundles/cards"));
            playerCards = asb.LoadAllAssets<PlayerCard>();
        }
        catch (System.Exception e)
        {
            playerCards = Resources.FindObjectsOfTypeAll<PlayerCard>();
        }
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

 
