using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class WallBottom : MonoBehaviour{
    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.parent.GetComponent<PlayerMovement>().CanMoveDown = false;
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.parent.GetComponent<PlayerMovement>().CanMoveDown = true;
        }
    }

    protected void Update()
    {
        transform.Translate(Vector3.zero);
    }
}