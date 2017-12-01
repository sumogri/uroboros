using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillingEffects : MonoBehaviour,IReset {
    private ParticleSystem[] effects;

    public void DoReset()
    {
        foreach(var e in effects)
        {
            e.Stop();
        }
    }

    // Use this for initialization
    void Start () {
        effects = gameObject.GetComponentsInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartEffect(string mode)
    {
        switch (mode)
        {
            case "fire":
                effects[0].Play();
                break;
            case "wind":
                effects[1].Play();
                break;
            case "water":
                effects[2].Play();
                break;
            case "sand":
                effects[3].Play();
                break;
            default:
                effects[4].Play();
                break;
        }
    }
}
