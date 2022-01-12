using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotArrow : MonoBehaviour
{
    const float shootingDelay = 1.5f;

    private GameObject arrowPrefab;

    private void Awake()
    {
        arrowPrefab = Resources.Load<GameObject>("Prefabs/Game/Archer/Arrow");
    }

    private void Start() // 나중에 게임 시작으로 바꾸기
    {
        StartCoroutine(ShootingArrow(shootingDelay));
    }

    IEnumerator ShootingArrow(float delay)
    {
        yield return new WaitForSeconds(1.2f);

        while (true)
        {
            // 화살 발사
            GameObject go = Instantiate(arrowPrefab, this.transform.position, Quaternion.Euler(0.0f, 0.0f, 50.0f));
            go.GetComponent<Rigidbody2D>().velocity = go.transform.right * 20;

            yield return new WaitForSeconds(delay);
        }
    }
}