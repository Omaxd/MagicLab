using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput
{
    public static string Forward = "Forward";
    public static string Backward = "Backward";
    public static string Left = "Left";
    public static string Right = "Right";

    public static string Sprint = "Sprint";
    public static string Jump = "Jump";
    public static string Crouch = "Crouch";

    public static string Action = "Action";
    public static string SecondAction = "SecondAction";

    public static string Menu = "Menu";

    public static IList<string> Inputs = new List<string>()
    {
        Forward,
        Backward,
        Left,
        Right,

        Sprint,
        Jump,
        Crouch,

        Action,
        SecondAction,

        Menu
    };

    public static IDictionary<string, KeyCode> Keys = new Dictionary<string, KeyCode>()
    {
        { Forward, KeyCode.W },
        { Backward, KeyCode.S },
        { Left, KeyCode.A },
        { Right, KeyCode.D },

        { Sprint, KeyCode.LeftShift },
        { Jump, KeyCode.Space },
        { Crouch, KeyCode.LeftControl },

        { Action, KeyCode.Mouse0 },
        { SecondAction, KeyCode.Mouse1 },

        { Menu, KeyCode.Escape }
    };

}
