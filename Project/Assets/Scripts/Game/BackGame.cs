// Created by DenyStark © AXIOM 2017 //
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGame : MonoBehaviour {
    Animation Anim;
    bool IsEnd;
    
    void Awake() {Anim = GameObject.Find("Bar/Back").GetComponent<Animation>();}

    public void Show() {Anim.clip = Anim.GetClip("+Back"); Anim.Play();}
    public void Hide(bool isEnd) {
        IsEnd = isEnd;
        Anim.clip = Anim.GetClip("-Back"); Anim.Play();
    }
 
    void EndGame() {if(IsEnd) SceneManager.LoadScene(0);}
}