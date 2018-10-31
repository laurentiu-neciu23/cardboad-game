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
    public void CmdSpawnCard(GameObject playerCardToSpawn)
    {
        Debug.Log("execute");
        Debug.Log(playerCardToSpawn);
        NetworkServer.Spawn(playerCardToSpawn);
    }


    [Command]
    public void CmdSpawnNetworkCard(string playerCardToSpawn, uint playerInfo)
    {
        Debug.Log("Please kill me");
        GameObject networkCardToSpawn = Instantiate(networkPlayerCard);
        NetworkCard nc = networkCardToSpawn.GetComponent<NetworkCard>();

        PlayerCard foundPc = null;

        var playerInfos = GameObject.FindObjectsOfType<PlayerInfo>();


        PlayerInfo player = null;
        foreach (PlayerInfo p in playerInfos)
        {
            if (p.netId.Value == playerInfo)
            {
                player = p;
            }
        }

        var playerCards =  player.GetComponent<PlayerInfo>().playerCardsInHand;
        foreach (PlayerCard pc in playerCards) {
            if (pc.PlayerName == playerCardToSpawn)
            {
                foundPc = pc;
                break;
            }

        }


        GameObject playerPref = Instantiate(playerCardPrefab);
        var cd = playerPref.GetComponent<CardDisplay>();
        cd.card = foundPc;



       

        Debug.Log(playerCardToSpawn);
        Debug.Log(playerInfo);
        nc.playerCard = playerPref;
 

        nc.player = player.gameObject;

        nc.typeOfCard = "m";
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

 
