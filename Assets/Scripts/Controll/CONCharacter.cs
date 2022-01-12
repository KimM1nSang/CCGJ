using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONCharacter : CONEntity
{
    // 캐릭터가 가지고 있는 고유 스탯 선언
    public float Hp;
    public float ATK;
    public float DEF;

    public float MoveSpeed = 1;

    public float attackRadius = 2;

    public CONCharacter attackTarget = null;

    public LayerMask attackLayer;

    protected float attackTime;
    protected float attackTimeMax = 10;
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
        attackTime = attackTimeMax;
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
    public void CharacterSetup(float hp,float atk,float def,float moveSpeed,Vector3 moveDir,float attackRadius,float attackTime)
    {
        Hp = hp;
        ATK = atk;
        DEF = def;
        MoveSpeed = moveSpeed;
        this.myVelocity = moveDir;
        this.attackRadius = attackRadius;
        this.attackTimeMax = attackTime;
    }
    public virtual void Damage(float damage)
    {
        Hp -= damage - DEF >= 0 ? (damage - DEF): 1;
    }
    #region FSM
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
        myVelocity.z = 0;
        gameObject.transform.Translate(myVelocity * MoveSpeed * Time.deltaTime);
    }
    public virtual void Attack()
    {

    }
    public virtual void Die()
    {

    }
    #endregion
}
