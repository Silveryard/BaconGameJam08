using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemManager : MonoBehaviour{
    public List<ItemInformation> Items;
    public float SpawnPropability;

    public void SpawnItem(GameObject enemy){
        if (Random.Range(0f, 1f) > SpawnPropability) return;

        List<GameObject> pool = new List<GameObject>();
        foreach (ItemInformation info in Items){
            for (int i = 0; i < info.Propability; i++){
                pool.Add(info.Item);
            }
        }

        GameObject item = pool[Random.Range(0, pool.Count)];

        Instantiate(item, enemy.transform.position, enemy.transform.rotation);
    }
}