using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPrefab : MonoBehaviour
{
    private float attackDamage = 5f;

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
        if(other.transform.CompareTag("Monster"))
        {
            other.gameObject.GetComponent<CONMonsterSlime>().Damage(attackDamage);
        }

        Destroy(this.gameObject); // 나중에 풀링
    }
}
