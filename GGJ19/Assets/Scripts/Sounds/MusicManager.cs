using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour {
    public AudioMixer mixer;
    public AudioMixerSnapshot[] snapshots;
    public float transitionDuration = 10;

    void Start() {
        GameObject.FindObjectOfType<victoryManager>().OnStepIncrease.AddListener(SetTheme);
    }

    //void Update() {
    //    if (Input.GetKeyDown(KeyCode.Alpha1)) {
    //        SetTheme(1);
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha2)) {
    //        SetTheme(2);
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha3)) {
    //        SetTheme(3);
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha4)) {
    //        SetTheme(4);
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha5)) {
    //        SetTheme(5);
    //    }
    //}

    public void SetTheme(int id) {
        if (id < snapshots.Length)
         snapshots[id].TransitionTo(transitionDuration);
    }
}
