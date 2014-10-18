using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class WallLeft : MonoBehaviour{
    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.parent.GetComponent<PlayerMovement>().CanMoveLeft = false;
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.parent.GetComponent<PlayerMovement>().CanMoveLeft = true;
        }
    }

    protected void Update(){
        transform.Translate(Vector3.zero);
    }
}