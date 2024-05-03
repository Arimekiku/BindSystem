﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionProvider
{
    private readonly Dictionary<KeysAction, KeyCode> _actions;
    private readonly Dictionary<KeysAction, KeyCode> _defaultActions;
    
    public ActionProvider()
    {
        _actions = new Dictionary<KeysAction, KeyCode>
        {
            { KeysAction.PauseUnpause, KeyCode.Escape },
            { KeysAction.Dash, KeyCode.LeftShift },
            { KeysAction.Action, KeyCode.E },
            { KeysAction.MoveLeft, KeyCode.A },
            { KeysAction.MoveUp, KeyCode.W },
            { KeysAction.MoveRight, KeyCode.D },
            { KeysAction.MoveDown, KeyCode.S }
        };

        _defaultActions = new Dictionary<KeysAction, KeyCode>(_actions);
    }

    public KeysAction[] GetKeys()
    {
        return _actions.Keys.ToArray();
    }

    public KeyCode GetControl(KeysAction key)
    {
        var seekedKey = _actions.Keys.FirstOrDefault(k => k == key);
        return _actions[seekedKey];
    }

    public void ChangeControl(KeysAction key, KeyCode value)
    {
        var seekedKey = _actions.Keys.FirstOrDefault(k => k == key);
        _actions[seekedKey] = value;
    }

    public void ResetToDefaults()
    {
        foreach (var key in _defaultActions.Keys)
            _actions[key] = _defaultActions[key];
    }
}