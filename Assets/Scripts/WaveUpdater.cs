using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class WaveUpdater : MonoBehaviour{
    protected void Awake(){
        Events.WaveChanged += OnWaveChanged;
    }

    public void Unregister(){
        Events.WaveChanged -= OnWaveChanged;
    }

    private void OnWaveChanged(int i){
        this.GetComponent<Text>().text = "" + i;
    }
}