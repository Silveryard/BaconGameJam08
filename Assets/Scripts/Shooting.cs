using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour{

    public GameObject Projectile;
    public GameObject SpawnPoint;
    public float ShootDelay;

    private float _nextShot;

    protected void Update(){
        if (Input.GetButton("Fire1") && Time.time > _nextShot){
            _nextShot = Time.time + ShootDelay;
            Instantiate(Projectile, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
            AudioSource source = GameObject.FindWithTag("Shooting").GetComponent<AudioSource>();
            source.Play();
            source.Play();
        }
    }
}
