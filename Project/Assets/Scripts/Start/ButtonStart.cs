// Created by DenyStark © AXIOM 2017 //
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonStart : MonoBehaviour {
    Animation Anim;
    Image Button;

    void Awake() {
        Anim = GetComponent<Animation>();
        Button = GetComponent<Image>();
    }

    public void StartAnim() {Anim.Play();}

    void OpenButton() {
        Anim.clip = Anim.GetClip("-Button");
        GameObject.Find("Player").GetComponent<SpriteRenderer>().color = Static.PlayerColor;
    }
    void CloseButton() {SceneManager.LoadScene(1);}

    public void ChangeButtonColor(Color startColor, Color endColor) {
        StartCoroutine(ChangeColor(startColor, endColor));
    }

    IEnumerator ChangeColor(Color startColor, Color endColor) {
        float timer = 0f;
        Button.color = startColor;

        while (timer < 1f) {
            Button.color = Color.Lerp(startColor, endColor, timer);
            timer += Time.deltaTime*8;
            yield return null;
        }
        Button.color = endColor;
    }
}