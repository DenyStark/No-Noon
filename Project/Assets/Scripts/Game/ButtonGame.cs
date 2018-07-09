// Created by DenyStark © AXIOM 2017 //
using UnityEngine;
using UnityEngine.UI;

public class ButtonGame : MonoBehaviour {
    CanvasGame Canvas;

    Animation Anim;
    Button ButtonComp;

    void Awake() {
        Anim = GetComponent<Animation>();
        ButtonComp = GetComponent<Button>();
        Canvas = GameObject.Find("Canvas").GetComponent<CanvasGame>();
        GetComponent<Image>().color = Static.PlayerColor;
    }

    public void StartAnim() {Anim.Play(); ButtonComp.interactable = false;}

    void OpenButton() {
        Anim.clip = Anim.GetClip("-Button");
        GameObject.Find("Player").GetComponent<SpriteRenderer>().color = Static.PlayerColor;
        ButtonComp.interactable = true;
    }
    void CloseButton() {Anim.clip = Anim.GetClip("+Button");}
}