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

    public enum AudioSource
    {
        OneShot = 0,
        SFX = 1,
        SFX_Loop = 2,
        BGM = 3
    }

    public enum Sound_SFX
    {
        CraneMove = 0,
        CraneExtendOrUnextend = 1,
        ClawOpenOrClose = 2,
        Congratulations = 3,
    }

    public enum Sound_BGM
    {
        BGM1 = 0
    }
}
