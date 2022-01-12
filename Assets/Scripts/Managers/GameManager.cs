using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    private SpawnManager SPM;
    private int wave = 0;
    public int Wave
    {
        get
        {
            return wave;
        }
        set
        {
            wave = value;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void IncreaseWave()
    {
        GameManager.Instance.Wave++;
        GameManager.Instance.StartCoroutine(GameManager.Instance.Spawn());
    }

    IEnumerator Spawn()
    {
        for(int i = 0; i < 10; i++)
        {
            GameSceneClass.gMGPool.CreateObj(ePrefabs.MonsterSlime, Random.insideUnitCircle);
            yield return new WaitForSeconds(Random.Range(0.4f, 0.7f));
        }
    }
}
