using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class DoubleFire : MonoBehaviour{
    public float Duration;

    protected void Awake(){
        StartCoroutine(Enumerator());
    }

    private IEnumerator Enumerator(){
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.parent.GetComponent<Shooting>().ShootDelay /= 5f;

        yield return new WaitForSeconds(Duration);

        player.transform.parent.GetComponent<Shooting>().ShootDelay *= 5f;

        yield return null;
        Destroy(gameObject);
    }
}