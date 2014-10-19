using UnityEngine;

public class DoubleFireItem : Item{
    public GameObject FireManager;

    protected override void OnCollect(){
        Instantiate(FireManager);
    }
}