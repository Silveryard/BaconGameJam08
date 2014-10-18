using UnityEngine;
using System.Collections;

public class Timebomb : MonoBehaviour{

    public float Delay;

    protected void Start(){
        Destroy(gameObject, Delay);
    }

}
