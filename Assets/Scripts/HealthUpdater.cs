using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class HealthUpdater : MonoBehaviour{
    protected void Awake(){
        Events.PlayerHealthChanged += OnPlayerHealthChanged;
    }

    public void Unregister(){
        Events.PlayerHealthChanged -= OnPlayerHealthChanged;
    }

    private void OnPlayerHealthChanged(int i){
        this.GetComponent<Text>().text = "" + i;
    }
}
