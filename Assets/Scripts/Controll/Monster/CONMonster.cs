using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONMonster : CONCharacter
{
    public override void Start()
    {
        myVelocity = Vector3.left;
        base.Start();
    }
    public override void Update()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, attackRadius, attackLayer);
        if(col != null)
        {
            state = eState.Attack;
        }
        else
        {
            state = eState.Move;
        }

        base.Update();
    }
    public override void AttackEnter()
    {
        base.AttackEnter();
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, attackRadius, attackLayer);
        attackTarget = col[UnityEngine.Random.Range(0, col.Length)].GetComponent<CONCharacter>();
    }
    public override void Attack()
    {
        base.Attack();
        if(attackTarget == null)
        {

        }
        attackTime -= Time.deltaTime;
        if (attackTime <= 0)
        {
            attackTime = attackTimeMax;
            attackTarget.Damage(ATK);
        }
    }
    public override void DieEnter()
    {
        base.DieEnter();
        Destroy(this.gameObject);
    }
}
