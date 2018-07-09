// Created by DenyStark © AXIOM 2017 //
using UnityEngine;
using UnityEngine.UI;

public class CanvasStart : MonoBehaviour {
    ButtonStart Button;
    Score       Record;

    SpriteRenderer Player;
    Button[]       Modes;

    void Awake() {
        Application.targetFrameRate = 60;

        Button = transform.Find("Button").GetComponent<ButtonStart>();
        Player = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        Record = transform.Find("Record").GetComponent<Score>();
        Modes  = transform.Find("Mode").GetComponentsInChildren<Button>();
    }
    void Start() {
        if(PlayerPrefs.HasKey("Score")) {
            Record.SetValue(PlayerPrefs.GetInt("Score"));
            Static.Mode = PlayerPrefs.GetInt("Mode");
        } else {
            PlayerPrefs.SetInt("Score", 0);
            PlayerPrefs.SetInt("Mode", 0);
        }

        ChangeMode(PlayerPrefs.GetInt("Mode"));
        foreach(Button button in Modes) button.interactable = true;

        Static.PlayerColor = CheckPlayerColor();
    }

    public void StartGame() {
        foreach(Button button in Modes) button.interactable = false;
        Button.StartAnim(); Record.Hide();
    }

    public void ChangeMode(int newMode) {
        PlayerPrefs.SetInt("Mode", newMode);
        Static.Mode = PlayerPrefs.GetInt("Mode");

        Color newColor;
        for(int i = 0; i < Modes.Length; i++) {
            newColor = Modes[i].GetComponent<Image>().color;

            if (i != PlayerPrefs.GetInt("Mode")) newColor.a = 0.25f;
            else newColor.a = 1;

            Modes[i].GetComponent<Image>().color = newColor;
        }

        Color32 OldColor = Static.PlayerColor;
        Static.PlayerColor = CheckPlayerColor();
        Button.ChangeButtonColor(OldColor, Static.PlayerColor);
        Player.color = Static.PlayerColor;
    }

    Color32 CheckPlayerColor() {
        switch(Static.Mode) {
            case 0: return new Color32( 83, 175,  88, 255);
            case 1: return new Color32( 39,  39,  39, 255);
            case 2: return new Color32(122, 129, 255, 255);
            default: return Color.black;
        }
    }
}