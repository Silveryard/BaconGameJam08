using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour{

    public float Speed;
    public float Health;
    public float Power;
    public int ScoreValue;
    public AudioClip DieClip;
    public GameObject AudioPlayer;

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
            ItemManager im = GameObject.FindWithTag("ItemManager").GetComponent<ItemManager>();
            im.SpawnItem(this.gameObject);
            Die();
        }
    }

    public void Die(){
        GameObject player = (GameObject) Instantiate(AudioPlayer, transform.position, transform.rotation);
        player.GetComponent<AudioSource>().clip = DieClip;
        player.GetComponent<AudioSource>().Play();
        Instantiate(ParticelManager, transform.position, transform.rotation);
        GameObject go = GameObject.FindWithTag("Wavemanager");
        WaveManager wm = go.GetComponent<WaveManager>();
        wm.Died(this.gameObject);
        Destroy(this.gameObject);
    }

    protected void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            other.gameObject.transform.parent.SendMessage("Damage", Power, SendMessageOptions.DontRequireReceiver);
            Die();
        }
    }

}
