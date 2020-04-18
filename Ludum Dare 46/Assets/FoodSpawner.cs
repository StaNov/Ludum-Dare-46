using System;
using TwitchLib.Client.Events;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public CoordinatesHolder holder;
    private TwitchChatClient _twitchChatClient;

    void Start()
    {
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

            Instantiate(foodPrefab, holder.getPositionOfCoordinates(int.Parse(coordinates[0]), int.Parse(coordinates[1])),
                Quaternion.identity);
        }
        catch (Exception ex)
        {
            Debug.LogWarning("Command " + command + " not recognized: " + ex.Message);
            _twitchChatClient.SendChatMessage("Command " + command + " not recognized.");
        }
    }

    private void Update()
    {
        if (holder.IsReady)
        {
            Instantiate(foodPrefab, holder.getPositionOfCoordinates(1, 1), Quaternion.identity);
            Instantiate(foodPrefab, holder.getPositionOfCoordinates(1, 12), Quaternion.identity);
            Instantiate(foodPrefab, holder.getPositionOfCoordinates(20, 1), Quaternion.identity);
            Instantiate(foodPrefab, holder.getPositionOfCoordinates(20, 12), Quaternion.identity);
        }
    }
}
