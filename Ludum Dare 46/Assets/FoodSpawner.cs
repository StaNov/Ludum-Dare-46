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
    public PlayerFoodManager playerFoodManager;
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
        if (e.Command.CommandText.ToLower() == "help")
        {
            _twitchChatClient.SendChatMessage("How to play: Keep the guy alive by putting food in his path! Type '!d3' to put food on D3 cell. Type '!food' to change the food you place.");
            return;
        }
        
        if (e.Command.CommandText.ToLower() == "food")
        {
            if (e.Command.ArgumentsAsString.Length == 0)
            {
                _twitchChatClient.SendChatMessage("You can choose from !food icecream, !food candy, !food cupcake and !food heart.");
                return;
            }
            
            playerFoodManager.SetFoodForPlayer(
                e.Command.ChatMessage.Username, 
                e.Command.ArgumentsAsString.ToLower()
            );
            return;
        }
        
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
            food.GetComponent<SpriteRenderer>().sprite = playerFoodManager.GetFoodForPlayer(userName);
            MusicPlayer.Instance.PlayFoodPlop();
        }
        catch (Exception ex)
        {
            Debug.LogWarning("Command '" + command + "' not recognized: " + ex.Message);
            #if !NOT_TWITCH
            _twitchChatClient.SendChatMessage(userName + ": Command " + command + " not recognized. Correct format is '!a1' or '!f11'.");
            #endif
        }
    }
}
