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
        playerCardsInHand = GetAtPath<PlayerCard>("_Cards");
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
    public static T[] GetAtPath<T>(string path)
    {

        ArrayList al = new ArrayList();
        string[] fileEntries = Directory.GetFiles(Application.dataPath + "/" + path);
        foreach (string fileName in fileEntries)
        {
            char[] delimiterChars = { '\\' };

            string[] arr = fileName.Split(delimiterChars);
            string finalFileName = arr[arr.Length - 1];
            string localFileName = "Assets/" + path + "/" + finalFileName;

            Object t = AssetDatabase.LoadAssetAtPath(localFileName, typeof(T));

            if (t != null)
                al.Add(t);
        }
        T[] result = new T[al.Count];
        for (int i = 0; i < al.Count; i++)
            result[i] = (T)al[i];

        return result;
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

 
