using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WallTop : MonoBehaviour{

    protected void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            other.gameObject.transform.parent.GetComponent<PlayerMovement>().CanMoveUp = false;
        }
    }

    protected void OnTriggerExit(Collider other){
        if (other.CompareTag("Player")){
            other.gameObject.transform.parent.GetComponent<PlayerMovement>().CanMoveUp = true;
        }
    }

    protected void Update()
    {
        transform.Translate(Vector3.zero);
    }
}