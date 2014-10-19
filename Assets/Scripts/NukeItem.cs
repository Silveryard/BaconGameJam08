using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class NukeItem : Item{
    public GameObject Nuke;
    public float SpawnHeight;
    
    protected override void OnCollect(){
        GameObject player = GameObject.FindWithTag("Player");

        Vector3 pos = new Vector3(player.transform.position.x, SpawnHeight, player.transform.position.z);

        Instantiate(Nuke, pos, player.transform.rotation);
    }
}