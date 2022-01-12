using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    public List<CONEntity> conMonstersList = new List<CONEntity>();

    private int wave = 0;
    public int WaveVal
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

    private void Start()
    {
        
    }

    public static void IncreaseWave()
    {
        GameManager.Instance.WaveVal++;
        GameManager.Instance.StartCoroutine(GameManager.Instance.Spawn());
    }

    IEnumerator Spawn()
    {
        for(int i = 0; i < 10; i++)
        {
            CONEntity slime = GameSceneClass.gMGPool.CreateObj(ePrefabs.MonsterSlime, Random.insideUnitCircle);
            conMonstersList.Add(slime);
            yield return new WaitForSeconds(Random.Range(0.4f, 0.7f));
        }
    }
}
