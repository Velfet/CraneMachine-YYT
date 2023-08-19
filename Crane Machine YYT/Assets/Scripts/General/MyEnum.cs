using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyEnum
{
    public enum CraneClawState
    {
        Open = 0,
        Opening = 1,
        Close = 2,
        Closing = 3
    }

    public enum CraneExtendStatus
    {
        Up = 0,
        Going_Down = 1,
        Down = 2,
        Going_Up = 3
    }

    public enum CameraPositionStatus
    {
        Left = 0,
        Middle = 1,
        Right = 2
    }
}
