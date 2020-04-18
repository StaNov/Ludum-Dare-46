using System;
using TwitchLib.Client.Events;
using UnityEngine;

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
        string command = e.Command.CommandText;
        Debug.Log(command);

        try
        {
            string[] coordinates = command.Split(',');

            Instantiate(foodPrefab, new Vector2(int.Parse(coordinates[0]), int.Parse(coordinates[1])),
                Quaternion.identity);
        }
        catch (Exception ex)
        {
            Debug.LogWarning("Command " + command + " not recognized: " + ex.Message);
            _twitchChatClient.SendChatMessage("Command " + command + " not recognized.");
        }
    }
}
