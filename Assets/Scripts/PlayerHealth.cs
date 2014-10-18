using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour{

    public int MaxHealth;
    public GameObject EndGame;

    private int _curHealth;

    protected void Awake(){
        _curHealth = MaxHealth;
    }

    protected void Start(){
        Events.OnPlayerHealthChanged(_curHealth);
    }

    public void Damage(int x){
        _curHealth -= x;

        if (_curHealth < 0){
            _curHealth = 0;
        }

        Events.OnPlayerHealthChanged(_curHealth);

        if (_curHealth <= 0){
            StartCoroutine("GameOver");
        }
    }

    private IEnumerator GameOver(){
        

        yield return new WaitForSeconds(0.2f);

        Instantiate(EndGame);

        List<GameObject> objects = GameObject.FindObjectsOfType<GameObject>().ToList();
        Queue<GameObject> queue = new Queue<GameObject>(objects);

        while (queue.Count > 0){
            GameObject cur = queue.Dequeue();
            Enemy e = cur.GetComponent<Enemy>();
            if (e == null) continue;
            e.Die();
        }
        GameObject.FindWithTag("Wavemanager").SetActive(false);
        
        GameObject.FindWithTag("MainCamera").GetComponent<Animator>().SetTrigger("Trigger");

        yield return new WaitForSeconds(4.8f);

        Application.LoadLevel("GameOver");

        yield return null;
    }
}
