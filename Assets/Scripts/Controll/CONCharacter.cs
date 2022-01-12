using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONCharacter : CONEntity
{
    // 캐릭터가 가지고 있는 고유 스탯 선언
    public float Hp { get; set; }
    public float ATK { get; set; }
    public float DEF { get; set; }

    public float MoveSpeed { get; set; } = 1;

    public Vector3 moveDir = new Vector3();
    // FSM, Detect 기능 등
    public enum eState
    {
        None = -1,
        Idle,
        Move,
        Attack,
        Die
    }
    public eState state;
    // 고유 캐릭터 스탯 데이터
    // 애니메이션 정보

    public override void Awake()
    {
        base.Awake();
        state = eState.None;
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void cleanUpOnDisable()
    {

    }

    protected override void firstUpdate()
    {
        base.firstUpdate();
    }

    public override void Update()
    {
        StateCheck();
        base.Update();
    }
    public void StateCheck()
    {
        switch (state)
        {
            case eState.None:
                break;
            case eState.Idle:
                Idle();
                break;
            case eState.Move:
                Move();
                break;
            case eState.Attack:
                Attack();
                break;
            case eState.Die:
                Die();
                break;
            default:
                break;
        }
    }
    public void ChangeState(eState state)
    {
        switch (this.state)
        {
            case eState.None:
                break;
            case eState.Idle:
                ExitIdle();
                break;
            case eState.Move:
                ExitMove();
                break;
            case eState.Attack:
                ExitAttack();
                break;
            case eState.Die:
                ExitDie();
                break;
            default:
                break;
        }
        this.state = state;
        switch (state)
        {
            case eState.None:
                break;
            case eState.Idle:
                IdleEnter();
                break;
            case eState.Move:
                MoveEnter();
                break;
            case eState.Attack:
                AttackEnter();
                break;
            case eState.Die:
                DieEnter();
                break;
            default:
                break;
        }
    }

    public virtual void ExitIdle()
    {

    }

    public virtual void ExitMove()
    {

    }

    public virtual void ExitAttack()
    {

    }

    public void ExitDie()
    {

    }

    public virtual void IdleEnter()
    {

    }

    public virtual void MoveEnter()
    {

    }

    public virtual void AttackEnter()
    {

    }

    public virtual void DieEnter()
    {

    }

    public virtual void Idle()
    {

    }
    public virtual void Move()
    {
        moveDir.z = 0;
        gameObject.transform.Translate(moveDir * MoveSpeed * Time.deltaTime);
    }
    public virtual void Attack()
    {

    }
    public virtual void Die()
    {

    }
}
