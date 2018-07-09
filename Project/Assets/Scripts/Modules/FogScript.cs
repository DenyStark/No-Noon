// Created by DenyStark © AXIOM 2017 //
using UnityEngine;

public class FogScript : MonoBehaviour {
    Animation Anim;

	void Awake() {Anim = GetComponent<Animation>();}
	
    public void ShowFogMiddle() {Anim.clip = Anim.GetClip("+FogMiddle"); Anim.Play();}
    public void HideFogMiddle() {Anim.clip = Anim.GetClip("-FogMiddle"); Anim.Play();}
    public void ShowFogFull() {Anim.clip = Anim.GetClip("+FogFull"); Anim.Play();}
}