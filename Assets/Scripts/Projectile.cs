using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour{

    public float Speed;
    public float Power;

    protected void Start(){
        Destroy(gameObject, 10);
    }

    protected void Update(){
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }

    protected void OnTriggerEnter(Collider other){
        
        if (other.CompareTag("Enemy")){
            other.gameObject.SendMessage("Damage", Power, SendMessageOptions.DontRequireReceiver);
        }
        if(!other.CompareTag("Player"))
            Destroy(this.gameObject);
    }
}
