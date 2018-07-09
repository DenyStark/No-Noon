// Created by DenyStark © AXIOM 2017 //
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour {
    CanvasGame Canvas;

    ParticleSystem PS;
    ParticleSystem.EmissionModule Emission;
    ParticleSystem.MainModule Particle;
    ParticleSystem.RotationOverLifetimeModule Rotation;
    ParticleSystem.TrailModule Trail;
    ParticleSystemRenderer Renderer;

    void Awake() {
        Canvas = GameObject.Find("Canvas").GetComponent<CanvasGame>();
        PS = GetComponent<ParticleSystem>();
        Emission = PS.emission;
        Particle = PS.main;
        Rotation = PS.rotationOverLifetime;
        Trail = PS.trails;

        Renderer = GetComponent<ParticleSystemRenderer>();

        SetParticleMode(PlayerPrefs.GetInt("Mode"));
    }

    void OnParticleTrigger() {
        if(PS.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, new List<ParticleSystem.Particle>()) > 0) {
            Canvas.EndGame();
        }
    }

    public void ParticleUp() {
        int oldEmission = (int)Emission.rateOverTime.constantMin;
        Emission.rateOverTime = oldEmission+1;
    }
    public void ParticleStop() {Emission.rateOverTime = 0;}

    void SetParticleMode(int newMode) {
        GameObject meshObject;
        switch(newMode) {
            case 0:
                Particle.startColor = new ParticleSystem.MinMaxGradient(new Color32(0, 133, 188, 255), new Color32(41, 171, 226, 255));

                meshObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                Renderer.mesh = meshObject.GetComponent<MeshFilter>().mesh;
                Destroy(meshObject);
                        
                break;
            case 1:
                Particle.startSize = new ParticleSystem.MinMaxCurve(0.2f, 0.35f);
                Particle.startSpeed = new ParticleSystem.MinMaxCurve(2f, 4f);
                Particle.startLifetime = 7;
                Particle.startColor = new ParticleSystem.MinMaxGradient(new Color32(39, 39, 39, 255), new Color32(70, 70, 70, 255));
                Rotation.enabled = true;

                meshObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Renderer.mesh = meshObject.GetComponent<MeshFilter>().mesh;
                Renderer.material = Resources.Load<Material>("Materials/Dart");
                Renderer.trailMaterial = Resources.Load<Material>("Materials/Dart");
                Destroy(meshObject);

                break;
            case 2:
                Particle.startSpeed = new ParticleSystem.MinMaxCurve(4f, 8f);
                Particle.startLifetime = 4;
                Particle.startColor = new ParticleSystem.MinMaxGradient(new Color32(253, 128, 8, 255), new Color32(255, 255, 102, 255));

                Trail.widthOverTrail = 0.25f;

                Renderer.pivot = new Vector3(0, 0, -7);

                meshObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                Renderer.mesh = meshObject.GetComponent<MeshFilter>().mesh;
                Renderer.material = Resources.Load<Material>("Materials/Rocket");
                Destroy(meshObject);

                break;
        }
    }
}