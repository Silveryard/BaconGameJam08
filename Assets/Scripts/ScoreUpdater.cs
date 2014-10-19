using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour{
    protected void Awake(){
        Events.ScoreChanged += OnScoreChanged;
    }

    public void Unregister(){
        Events.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int i){
        this.GetComponent<Text>().text = "" + i;
    }
}