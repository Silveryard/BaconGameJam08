using UnityEngine;
using System.Collections;

public class ScoreResetter : MonoBehaviour {

    protected void Awake(){
        Score.ResetScore();
        Events.ResetEvents();
    }
}