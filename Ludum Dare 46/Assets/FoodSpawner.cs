using System;
using TwitchLib.Client.Events;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public CoordinatesHolder holder;
    public DebugInput debugInput;
    private TwitchChatClient _twitchChatClient;

    void Start()
    {
        #if NOT_TWITCH
        debugInput.AddListener(ProcessCommand);
        #else
        _twitchChatClient = GetComponent<TwitchChatClient>();
        _twitchChatClient.AddOnCommandReceived(OnCommand);
        #endif
    }

    private void OnCommand(object sender, OnChatCommandReceivedArgs e)
    {
        string command = e.Command.CommandText;
        ProcessCommand(command);
    }

    private void ProcessCommand(string command)
    {
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
            #if !NOT_TWITCH
            _twitchChatClient.SendChatMessage("Command " + command + " not recognized.");
            #endif
        }
    }
}
