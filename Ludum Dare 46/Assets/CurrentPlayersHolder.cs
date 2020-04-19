using System.Collections;
using System.Collections.Generic;
using TwitchLib.Client.Events;
using UnityEngine;

public class CurrentPlayersHolder : MonoBehaviour
{
    private TwitchChatClient _twitchChatClient;
    public DebugInput debugInput;
    public List<string> currentPlayers = new List<string>();
    
    void Awake()
    {
        #if !NOT_TWITCH
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

    private void OnCommand(object sender, OnChatCommandReceivedArgs command)
    {
        OnCommand(command);
    }

    private void OnCommand(OnChatCommandReceivedArgs command)
    {
        string userName = command.Command.ChatMessage.Username;
        if (!currentPlayers.Contains(userName))
        {
            currentPlayers.Add(userName);
        }
    }
}
