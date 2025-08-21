using UnityEngine;

public enum EnemyState
{
    Move,
    Attack
}

public class Enemy : MonoBehaviour
{
    private BattleManager battleManager;
    private Transform attackPoint;
    private EnemyData enemyData;
    public IDamagable I_Enemy;

    private Vector2 moveVec;

    private float attackTIme;
    private float deltaTime;

    private bool isInitCompleted;

    private EnemyState currentState;

    private void Start()
    {
        battleManager = BattleManager.Instance;        

        ChangeState(EnemyState.Move);
    }

    public void InitData(EnemySO enemySO, GameObject enemy)
    {
        enemyData = new EnemyData(enemySO, enemy);
        I_Enemy = enemyData;
        moveVec = gameObject.transform.position;
        attackPoint = StageManager.Instance.AttackPoint;
        isInitCompleted = true;
    }

    private void Update()
    {
        if(gameObject.transform.position.y >= attackPoint.position.y)
        {
            ChangeState(EnemyState.Attack);
        }

        UpdateState();
    }

    private void Move()
    {
        if (isInitCompleted == false) return;

        deltaTime = Time.deltaTime;
        moveVec.y += (enemyData.MoveSpeed * deltaTime);
        gameObject.transform.position = moveVec;
    }

    private void Attack()
    {
        attackTIme += deltaTime;

        if (attackTIme >= enemyData.AtkSpeed)
        {
            BattleManager battleManager = BattleManager.Instance;
            Debug.Log("에너미 어택");
            battleManager.I_Player.TakeDamage(enemyData.Atk);
            attackTIme = 0;
        }
    }

    private void ChangeState(EnemyState newState)
    {
        currentState = newState;
    }

    private void UpdateState()
    {
        switch (currentState)
        {
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
        }
    }
}
