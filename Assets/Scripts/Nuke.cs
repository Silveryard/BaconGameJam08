using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Nuke : MonoBehaviour{

    public GameObject WaveEnd;

    public float Speed;
    public float Range;

    protected void Update(){
        Speed += Speed * (Time.deltaTime*9.81f);

        transform.position -= new Vector3(0, Speed, 0);

        if (transform.position.y >= 2) return;

        Instantiate(WaveEnd, transform.position, transform.rotation);

        List<GameObject> objects = GameObject.FindObjectsOfType<GameObject>().ToList();
        Queue<GameObject> queue = new Queue<GameObject>(objects);

        while (queue.Count > 0)
        {
            GameObject cur = queue.Dequeue();
            Enemy e = cur.GetComponent<Enemy>();
            if (e == null) continue;
            if(Vector3.Distance(transform.position, cur.transform.position) > Range) continue;
            e.Damage(100);
        }

        Destroy(gameObject);
    }

}