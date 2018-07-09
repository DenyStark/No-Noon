// Created by DenyStark © AXIOM 2017 //
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    Animation Anim;
    Image ClickField;

    Vector2 EndPos, StartPos;
    float Speed, Timer;
    bool IsMove;

    void Awake() {
        Anim = GetComponent<Animation>();
        ClickField = GameObject.Find("Canvas/ClickField").GetComponent<Image>();
        GetComponent<SpriteRenderer>().color = Static.PlayerColor;
    }

    void Update() {
        if(IsMove) {
            Timer += Time.deltaTime*4*Speed;
            transform.position = Vector3.Lerp(StartPos, EndPos, Timer);
            if(Timer > 1) {IsMove = false;}
        }
    }

    public void ScreenClick() {
        EndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        StartPos = transform.position;
        Speed = 1/Vector2.Distance(StartPos, EndPos);
        Timer = 0; IsMove = true;
    }

    public void Kill() {
        transform.GetComponent<PolygonCollider2D>().enabled = false;
        ClickField.raycastTarget = false; Anim.Play();
    }

    public void Restart() {
        StartCoroutine(Activate());
        transform.position = Vector3.zero;
        transform.localScale = Vector3.one*0.25f;
        ClickField.raycastTarget = true;
    }
    zz
    IEnumerator Activate() {
        yield return new WaitForSeconds(1);
        transform.GetComponent<PolygonCollider2D>().enabled = true;
    }
}