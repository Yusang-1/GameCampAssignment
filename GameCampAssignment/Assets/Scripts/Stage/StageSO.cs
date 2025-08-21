using UnityEngine;

[CreateAssetMenu(fileName = "StageSO", menuName = "StageSO/Stage")]
public class StageSO : ScriptableObject
{
    public int StageIndex;
    public EnemySO Enemy;
    public int EnemyCount;    
}
