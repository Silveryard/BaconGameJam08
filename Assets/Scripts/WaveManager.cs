using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour{

    public List<EnemyInformation> Enemies;
    public List<Transform> Spawns;

    public float MinDelay;
    public float MaxDelay;

    public int EnemiesToKill;
    public int EnemiesKilled;
    public int CurWave;

    protected void Awake(){
        StartCoroutine(Startup());
    }

    private IEnumerator Startup(){
        yield return new WaitForSeconds(4);
        StartWave();
    }

    public void StartWave(){
        CurWave++;
        EnemiesKilled = 0;
        EnemiesToKill = 0;

        Events.OnWaveChanged(CurWave);

        List<GameObject> enemies = new List<GameObject>();
        Dictionary<GameObject, int> spawnInfo = new Dictionary<GameObject, int>();
        foreach (EnemyInformation info in Enemies){
            if (CurWave >= info.FirstAllowedWave){
                int number = Random.Range((CurWave - info.FirstAllowedWave + 1)/2, CurWave - info.FirstAllowedWave + 1);

                if (number == 0)
                    number++;

                spawnInfo.Add(info.Prefab, number);
                EnemiesToKill += number;
            }
        }

        StartCoroutine(Spawn(spawnInfo));
    }

    private IEnumerator Spawn(Dictionary<GameObject, int> info){
        Dictionary<GameObject, int> counter = new Dictionary<GameObject, int>();
        foreach (var pair in info){
            counter.Add(pair.Key, 0);
        }
        int spawned = 0;
        while (spawned < EnemiesToKill){
            List<GameObject> enemies = counter.Keys.ToList();

            int index = Random.Range(0, enemies.Count);
            GameObject prefab = enemies[index];

            if (counter[prefab] < info[prefab]){
                Transform spawner = Spawns[Random.Range(0, Spawns.Count)];
                Instantiate(prefab, spawner.transform.position, spawner.transform.rotation);
                counter[prefab]++;
                spawned++;

                yield return new WaitForSeconds(Random.Range(MinDelay, MaxDelay));
            }
            else{
                counter.Remove(prefab);
            }
        }
    }

    public void Died(GameObject sender){
        EnemiesKilled++;
    }

    protected void Update(){
        if (EnemiesKilled >= EnemiesToKill && CurWave > 0){
            StartWave();
        }
    }

}