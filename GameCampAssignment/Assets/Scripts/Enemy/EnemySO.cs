using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Enemy")]
public class EnemySO : ScriptableObject
{
    public string EnemyName;
    public int EnemyMaxHP;
    public int EnemyAtk;
    public float EnemyAtkSpeed;
    public float EnemyMoveSpeed;
    public GameObject Prefab;
    public int CoinDrop;
}
