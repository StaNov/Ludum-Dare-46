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
        _twitchChatClient = TwitchChatClient.Instance;
        _twitchChatClient.AddOnCommandReceived(OnCommand);
        #endif
    }

    #if !NOT_TWITCH
    private void OnDestroy()
    {
        _twitchChatClient.RemoveOnCommandReceived(OnCommand);
    }
    #endif

    private void OnCommand(object sender, OnChatCommandReceivedArgs e)
    {
        ProcessCommand(e.Command.CommandText, e.Command.ChatMessage.Username);
    }

    private void ProcessCommand(string command, string userName=null)
    {
        try
        {
            string[] coordinates = command.Split(',');

            Instantiate(foodPrefab, holder.getPositionOfCoordinates(int.Parse(coordinates[0]), int.Parse(coordinates[1])),
                Quaternion.identity);
        }
        catch (Exception ex)
        {
            Debug.LogWarning("Command '" + command + "' not recognized: " + ex.Message);
            #if !NOT_TWITCH
            _twitchChatClient.SendChatMessage(userName + ": Command " + command + " not recognized. Correct format is '!xx,yy'.");
            #endif
        }
    }
}
