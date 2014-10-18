using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreLoader : MonoBehaviour {

    protected void Awake(){
        this.GetComponent<Text>().text = "" + Score.GetScore();
    }
	
}