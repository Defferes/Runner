using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data 
{
    private static int score = 0;
    public static int Score
    {
        get => score;
        set => score = value;
    }
}
