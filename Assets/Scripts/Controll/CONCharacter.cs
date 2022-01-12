using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CONCharacter : CONEntity
{
    // 캐릭터가 가지고 있는 고유 스탯 선언
    public float Hp;
    public float HpMax;
    public float ATK;
    public float DEF;

    public float MoveSpeed = 1;

    public float attackRadius = 2;

    public CONCharacter attackTarget = null;

    public LayerMask myMask;
    public LayerMask attackLayer;

    [SerializeField]
    protected float attackTime;
    protected float attackTimeMax = 10;

    [SerializeField]
    protected Image HpBar;
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

        Hp = HpMax;

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
        HpBar.rectTransform.localScale = new Vector3(Hp / HpMax, 1, 1);
    }

    public override void Update()
    {
        if(state != eState.Attack)
        {
            Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, attackRadius, attackLayer);
            if (col.Length > 0)
            {
                ChangeState(eState.Attack);
            }
            else
            {
                ChangeState(eState.Move);
            }
        }
        

        StateCheck();
        base.Update();
    }
    public void CharacterSetup(float hp,float atk,float def,float moveSpeed,Vector3 moveDir,float attackRadius,float attackTime)
    {
        HpMax = hp;
        Hp = HpMax;
        ATK = atk;
        DEF = def;
        MoveSpeed = moveSpeed;
        this.myVelocity = moveDir;
        this.attackRadius = attackRadius;
        this.attackTimeMax = attackTime;
    }
    public virtual void Damage(float damage)
    {
        if((damage - DEF) >= Hp)
        {
            Hp = 0;
            ChangeState(eState.Die);
        }
        else
        {
            Hp -= damage - DEF >= 0 ? (damage - DEF) : 1;
        }
        HpBar.rectTransform.localScale = new Vector3(Hp / HpMax, 1, 1);

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
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, attackRadius, attackLayer);
        attackTarget = col[UnityEngine.Random.Range(0, col.Length)].GetComponent<CONCharacter>();
    }

    public virtual void DieEnter()
    {
        SetActive(false);
    }

    public virtual void Idle()
    {

    }
    public virtual void Move()
    {
        float nextYpos = myTrm.position.y + myVelocity.y * Time.deltaTime;

        myTrm.position = new Vector3(myTrm.position.x + myVelocity.x * MoveSpeed * Time.deltaTime, nextYpos, myTrm.position.z);
    }
    public virtual void Attack()
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
                attackTime = attackTimeMax;
                attackTarget.Damage(ATK);
            }
        }
      
    }
    public virtual void Die()
    {

    }
    #endregion
}
