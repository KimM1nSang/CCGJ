using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    MGPool mgPool;

    private void Awake()
    {
        mgPool = GetComponent<MGPool>();
    }

    public void StartSpawn()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(0.2f);

        mgPool.CreateObjAsChild(ePrefabs.MonsterSlime, new Vector3(-5f, Random.Range(-2.0f, 2.0f), 0), this.transform);
    }
}
