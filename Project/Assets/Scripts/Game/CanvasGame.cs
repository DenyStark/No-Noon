// Created by DenyStark © AXIOM 2017 //
using UnityEngine;

public class CanvasGame : MonoBehaviour {
    BarGame Bar;
    ButtonGame Button;
    FogScript Fog;
    Score TotalScore, Record;
    PlayerScript Player;

    void Awake() {
        Bar    = transform.Find("Bar").GetComponent<BarGame>();
        Button = transform.Find("Button").GetComponent<ButtonGame>();
        Fog    = transform.Find("Fog").GetComponent<FogScript>();
        TotalScore = transform.Find("TotalScore").GetComponent<Score>();
        Record = transform.Find("Record").GetComponent<Score>();
        Player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    public void Back() {
        Bar.Back();
        Fog.ShowFogFull();

        Button.StartAnim();
        TotalScore.Hide(); Record.Hide();
    }

    public void EndGame() {
        Player.Kill();

        Button.StartAnim();
        Fog.ShowFogMiddle();
        TotalScore.SetValue(Bar.StopTimer()); TotalScore.Show();
        Record.CheckRecord(Bar.StopTimer()); Record.Show();
        Bar.Pause();
    }

    public void Restart() {
        Player.Restart();

        Button.StartAnim();
        Fog.HideFogMiddle();
        TotalScore.Hide(); Record.Hide();
        Bar.StartTimer(); Bar.Play();
    }
}