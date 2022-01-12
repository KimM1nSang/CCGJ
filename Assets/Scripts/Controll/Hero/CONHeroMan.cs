using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONHeroMan : CONHero
{
    // 히어로 개별 유닛이 가지는 특성 구현
    public override void Start()
    {
        base.Start();
        CharacterSetup(100, 10, 2, 0, Vector3.right, 5, .5f);
    }
    public override void Attack()
    {
        if (attackTarget == null)
        {
            attackTime = attackTimeMax;
            ChangeState(eState.Move);
        }
        else
        {
            attackTime -= Time.deltaTime;
            if (attackTime <= 0)
            {
                GetComponentInChildren<Animator>().SetTrigger("attack");
                attackTime = attackTimeMax;
                attackTarget.Damage(ATK);
            }
        }
    }
}
