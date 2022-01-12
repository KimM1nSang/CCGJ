using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPrefab : MonoBehaviour
{
    void Update()
    {
        this.transform.right = GetComponent<Rigidbody2D>().velocity;

        if(this.transform.position.y < -10f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // 몬스터 데미지 처리

        Destroy(this.gameObject); // 나중에 풀링
    }
}
