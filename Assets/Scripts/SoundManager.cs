using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour{
    protected void Awake(){
        float volume = PlayerPrefs.GetFloat("Volume", 100);

        GetComponent<AudioSource>().volume *= (volume/100f);
    }
}
