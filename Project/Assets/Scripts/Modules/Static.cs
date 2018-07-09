// Created by DenyStark © AXIOM 2017 //
using UnityEngine;

public static class Static {
    static int mode;
    public static int Mode {
        get { return mode; }
        set { mode = value; }
    }

    static Color32 playerColor;
    public static Color32 PlayerColor {
        get { return playerColor; }
        set { playerColor = value; }
    }
}