using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private MGPool mgPool;

    private void Awake() {
        mgPool = this.GetComponent<MGPool>();
    }

    public void Spawn()
    {
        mgPool.CreateObjAsChild(ePrefabs.MonsterSlime, this.transform.position, this.transform);
    }
}
