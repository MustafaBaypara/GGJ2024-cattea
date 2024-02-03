using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Singleton
{
    public static bool Move = false;

    public static float Speed = 20;

    [Header("Player")]

    public static int Healthy = 2;

    public static bool Die;

    public static int Score;

    [Header("Manager")]

    public static bool Pause = false;
}
