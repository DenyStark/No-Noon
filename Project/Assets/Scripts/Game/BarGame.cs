// Created by DenyStark © AXIOM 2017 //
using UnityEngine;
using UnityEngine.UI;

public class BarGame : MonoBehaviour {
    BackGame BackButton;
    Particles[] PS;

    Animation ScoreAnim;
    Text Score;

    float Timer;
    bool IsGame;
    int Level; 

	void Awake () {
        ScoreAnim  = transform.Find("Score").GetComponent<Animation>();
        Score = transform.Find("Score").GetComponent<Text>();
        BackButton = transform.Find("Back").GetComponent<BackGame>();

        PS = new Particles[4]; for(int i = 0; i < PS.Length; i++) PS[i] = GameObject.Find("Particle System" + i).GetComponent<Particles>();
    }

    void Start() {StartTimer();}

    void Update() {
        if(IsGame) {
            Timer += Time.deltaTime;
            int NewScore = (int)Mathf.Pow(Timer, 2) * (Static.Mode + 1);
            ChangeScore(NewScore);

            if(NewScore > Mathf.Pow(3, Level)) {
                Level++; PS[Random.Range(0, PS.Length)].ParticleUp();
            }
        }
    }

    public void StartTimer() {
        Level = 0; Timer = 0;
        IsGame = true;
    }
    public int StopTimer() {
        for(int i = 0; i < PS.Length; i++) PS[i].ParticleStop();
        IsGame = false;
        return (int)Mathf.Pow(Timer, 2) * (Static.Mode+1);
    } 

    void ChangeScore(int NewScore) {
        Score.text = NewScore.ToString();
    }

    public void Pause() {
        ScoreAnim.clip = ScoreAnim.GetClip("-Obj"); ScoreAnim.Play();
        BackButton.Show();
    }
    public void Play() {
        ScoreAnim.clip = ScoreAnim.GetClip("+Obj"); ScoreAnim.Play();
        BackButton.Hide(false);
    }

    public void Back() {BackButton.Hide(true);}
}