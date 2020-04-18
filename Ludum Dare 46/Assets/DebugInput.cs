using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugInput : MonoBehaviour
{
    private Action<String> _processCommand;
    private InputField _inputField;

    void Start()
    {
#if !NOT_TWITCH
        Destroy(GetComponentInParent<Canvas>().gameObject);
#endif
        _inputField = GetComponent<InputField>();
    }

    public void OnInputSent()
    {
        _processCommand(_inputField.text);
        _inputField.text = "";
    }

    public void AddListener(Action<string> processCommand)
    {
        _processCommand = processCommand;
    }
}
