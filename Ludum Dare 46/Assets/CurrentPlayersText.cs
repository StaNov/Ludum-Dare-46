using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentPlayersText : MonoBehaviour
{
    public CurrentPlayersHolder currentPlayersHolder;
    private Text _text;
    void Awake()
    {
        _text = GetComponent<Text>();
    }

    void Update()
    {
        string newText = string.Join("\n", currentPlayersHolder.currentPlayers);

        if (!_text.text.Equals(newText))
        {
            _text.text = newText;
        }
    }
}
