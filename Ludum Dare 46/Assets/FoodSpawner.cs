using System.Collections;
using System.Collections.Generic;
using TwitchLib.Client.Events;
using UnityEngine;
using UnityEngine.Serialization;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    private TwitchChatClient _twitchChatClient;

    void Start()
    {
        Instantiate(foodPrefab, new Vector2(3, 3), Quaternion.identity);
        _twitchChatClient = GetComponent<TwitchChatClient>();
        _twitchChatClient.AddOnCommandReceived(OnCommand);
    }

    private void OnCommand(object sender, OnChatCommandReceivedArgs e)
    {
        Debug.Log(e.Command.CommandText);
    }
}
