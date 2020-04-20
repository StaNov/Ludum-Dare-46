using System;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Unity;
using UnityEngine;

public class TwitchChatClient : MonoBehaviour
{
	public static TwitchChatClient Instance
	{
		get
		{
			if (_instance == null)
			{
				Initialize();
			}

			return _instance;
		}
	}

	private static void Initialize()
	{
		GameObject gameObject = new GameObject("TwitchChatClient");
		_instance = gameObject.AddComponent<TwitchChatClient>();
	}

	private static TwitchChatClient _instance;

	private Client _client;
	private string _channel;

	private void Awake()
	{
#if NOT_TWITCH
		return;
#endif
		ConnectionCredentials credentials = new ConnectionCredentials(Secrets.USERNAME_FROM_OAUTH_TOKEN, Secrets.OAUTH_TOKEN);

		_client = new Client();
		_client.Initialize(credentials, Secrets.USERNAME_FROM_OAUTH_TOKEN);
		_client.OnConnected += OnConnected;
		_client.OnJoinedChannel += OnJoinedChannel;
		_client.OnMessageReceived += OnMessageReceived;
		_client.Connect();
	}

	private void OnConnected(object sender, TwitchLib.Client.Events.OnConnectedArgs e)
	{
		Debug.Log($"The bot {e.BotUsername} successfully connected to Twitch.");

		if (!string.IsNullOrWhiteSpace(e.AutoJoinChannel))
			Debug.Log($"The bot will now attempt to automatically join the channel provided when the Initialize method was called: {e.AutoJoinChannel}");
	}

	private void OnJoinedChannel(object sender, TwitchLib.Client.Events.OnJoinedChannelArgs e)
	{
		Debug.Log($"The bot {e.BotUsername} just joined the channel: {e.Channel}");
		_channel = e.Channel;
	}

	public void AddOnCommandReceived(EventHandler<OnChatCommandReceivedArgs> action)
	{
#if NOT_TWITCH
		return;
#endif
		_client.OnChatCommandReceived += action;
	}
	
	public void RemoveOnCommandReceived(EventHandler<OnChatCommandReceivedArgs> action)
	{
#if NOT_TWITCH
		return;
#endif
		_client.OnChatCommandReceived -= action;
	}

	public void SendChatMessage(string message)
	{
#if NOT_TWITCH
		return;
#endif
		_client.SendMessage(_channel, message);
	}

	private void OnMessageReceived(object sender, TwitchLib.Client.Events.OnMessageReceivedArgs e)
	{
		Debug.Log($"Message received from {e.ChatMessage.Username}: {e.ChatMessage.Message}");
	}
}