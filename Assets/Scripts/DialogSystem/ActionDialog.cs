﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//[CreateAssetMenu(fileName = "ActionDialog", menuName = "ScriptableObjects/ActionDialog", order = 3)]
public class ActionDialog : Dialog
{
    [SerializeField]
    UnityEvent action;

    public override DialogResult next()
    {
        if (index + 1 < lines.Length)
            return base.next();
        action.Invoke();
        return new DialogResult(DialogResult.ResultType.End);
    }
}
