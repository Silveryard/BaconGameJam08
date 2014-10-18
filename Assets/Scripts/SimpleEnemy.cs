using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SimpleEnemy : Enemy{
    private GameObject _player;

    protected void Awake(){
        _player = GameObject.FindWithTag("Player");
    }
    
    protected override void Move(){
        float step = Speed*Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, step);
        transform.LookAt(_player.transform);
    }
}