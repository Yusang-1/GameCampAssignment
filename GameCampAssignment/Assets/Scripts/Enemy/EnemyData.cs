using UnityEngine;

public class EnemyData : IDamagable
{
    private int maxHP;
    private int currentHP;
    private int atk;
    private float atkSpeed;
    private float moveSpeed;
    private GameObject prefab;
    private int coinDrop;

    public int MaxHP => maxHP;
    public int CurrentHP => currentHP;
    public int Atk => atk;
    public float AtkSpeed => atkSpeed;
    public float MoveSpeed => moveSpeed;
    public GameObject Prefab => prefab;

    public EnemyData(EnemySO enemySO, GameObject enemy)
    {
        maxHP = enemySO.EnemyMaxHP;
        currentHP = maxHP;
        atk = enemySO.EnemyAtk;
        atkSpeed = enemySO.EnemyAtkSpeed;
        moveSpeed = enemySO.EnemyMoveSpeed;
        prefab = enemy;
        coinDrop = enemySO.CoinDrop;
    }

    public void TakeDamage(int damage)
    {
        if (currentHP == 0) return;

        currentHP = Mathf.Clamp(currentHP - damage, 0, maxHP);

        if(currentHP == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        StageManager.Instance.EnemyDead(prefab);
        BattleManager.Instance.GetCoin(coinDrop);
    }
}
