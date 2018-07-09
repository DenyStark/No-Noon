// Created by DenyStark © AXIOM 2017 //
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    Animation Anim;
    Text Count;
	
    void Awake() {
        Count = transform.Find("Count").GetComponent<Text>();
        Anim = GetComponent<Animation>();
	}
	
    public void Show() {Anim.clip = Anim.GetClip("+Score"); Anim.Play();}
    public void Hide() {Anim.clip = Anim.GetClip("-Score"); Anim.Play();}

    public void SetValue(int New) {Count.text = New.ToString();}
    public void CheckRecord(int New) {
        int Old = PlayerPrefs.GetInt("Score");
        if(Old < New) {
            PlayerPrefs.SetInt("Score", New);
            Count.text = New.ToString();
        } else Count.text = Old.ToString();
    }
}