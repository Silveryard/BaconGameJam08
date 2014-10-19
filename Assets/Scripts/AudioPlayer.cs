using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioPlayer : MonoBehaviour{
    public List<AudioClip> Clips;

    private AudioSource _source;

    protected void Awake(){
        _source = GetComponent<AudioSource>();
    }

    protected void Update(){
        if (!_source.isPlaying){
            int index = Random.Range(0, Clips.Count);
            AudioClip clip = Clips[index];

            _source.clip = clip;
            _source.Play();
        }
    }
}