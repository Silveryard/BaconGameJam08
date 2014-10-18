using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour{

    public float Speed;
    public float Health;
    public float Power;
    public int ScoreValue;

    public GameObject ParticelManager;

    protected void Update(){
        Move();
    }

    protected virtual void Move(){
        this.transform.Translate(Vector3.zero);
    }

    public void Damage(float value){
        Health -= value;

        if (Health <= 0){
            Score.AddScore(ScoreValue);
            Die();
        }
    }

    public void Die(){
        Destroy(this.gameObject);
        Instantiate(ParticelManager, transform.position, transform.rotation);
        GameObject go = GameObject.FindWithTag("Wavemanager");
        WaveManager wm = go.GetComponent<WaveManager>();
        wm.Died(this.gameObject);
    }

    protected void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            other.gameObject.transform.parent.SendMessage("Damage", Power, SendMessageOptions.DontRequireReceiver);
            Die();
        }
    }

}
