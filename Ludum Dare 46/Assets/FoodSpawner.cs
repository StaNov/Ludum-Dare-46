using System;
using TwitchLib.Client.Events;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public CoordinatesHolder holder;
    public DebugInput debugInput;
    public CurrentScoreHolder currentScoreHolder;
    private TwitchChatClient _twitchChatClient;

    void Start()
    {
        #if NOT_TWITCH
        debugInput.AddListener((command) => ProcessCommand(command));
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
            if (command.Length < 2 || command.Length > 3)
            {
                throw new Exception("Bad format");
            }

            char column = command[0];
            int row = int.Parse(command.Substring(1));

            GameObject food = Instantiate(foodPrefab, holder.getPositionOfCoordinates(column, row),
                Quaternion.identity);
            food.GetComponent<Food>().currentScoreHolder = currentScoreHolder;
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
