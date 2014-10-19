using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class HealthItem : Item{
    public GameObject ParticelSystem;
    public int Power;
    
    protected override void OnCollect(){
        GameObject player = GameObject.FindWithTag("Player");
        Instantiate(ParticelSystem, player.transform.position, player.transform.rotation);

        player.transform.parent.GetComponent<PlayerHealth>().Heal(Power);
    }
}