using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class WallRight : MonoBehaviour{
    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.parent.GetComponent<PlayerMovement>().CanMoveRight = false;
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.parent.GetComponent<PlayerMovement>().CanMoveRight = true;
        }
    }

    protected void Update()
    {
        transform.Translate(Vector3.zero);
    }
}