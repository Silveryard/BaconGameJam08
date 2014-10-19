using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Item : MonoBehaviour{

    protected void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            OnCollect();
            Destroy(this);
        }
    }


    protected virtual void OnCollect(){
        
    }
}