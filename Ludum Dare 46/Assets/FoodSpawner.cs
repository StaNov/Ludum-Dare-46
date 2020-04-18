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

            Instantiate(foodPrefab, new Vector2(int.Parse(coordinates[0]), int.Parse(coordinates[1])),
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
            Instantiate(foodPrefab, holder.getPositionOfCoordinates(2, 2), Quaternion.identity);
            Instantiate(foodPrefab, holder.getPositionOfCoordinates(3, 3), Quaternion.identity);
            Instantiate(foodPrefab, holder.getPositionOfCoordinates(4, 4), Quaternion.identity);
        }
    }
}
