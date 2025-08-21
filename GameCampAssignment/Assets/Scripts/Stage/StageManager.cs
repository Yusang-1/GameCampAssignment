using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageManager : MonoBehaviour
{
    #region 싱글톤 구현
    private static StageManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static StageManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    #endregion

    [SerializeField] StageSO[] stageSOs;
    [SerializeField] Transform enemyContainer;
    public Transform SpawnPoint;
    public Transform AttackPoint;

    private List<GameObject> enemyList;
    private int stageIndex;
    private int enemyCount;

    public int StageIndex => stageIndex;

    private void Start()
    {
        enemyList = new List<GameObject>();
        stageIndex = -1;
    }

    public void StartNewStage()
    {
        stageIndex++;
        
        StageSO stageData = stageSOs[stageIndex];

        GameObject go = stageData.Enemy.Prefab;
        GameObject temp;
        Enemy enemy;

        enemyCount = stageData.EnemyCount;

        for (int i = 0; i < enemyCount; i++)
        {
            temp = Instantiate(go, SpawnPoint.position, Quaternion.identity ,enemyContainer);
            temp.SetActive(false);
            enemyList.Add(temp);
            enemy = enemyList[i].GetComponent<Enemy>();
            enemy.InitData(stageSOs[stageIndex].Enemy, temp);
        }

        UIManger.Instance.NextStage(StageIndex + 1);
        StartCoroutine(EnemyStartMoving());
    }

    IEnumerator EnemyStartMoving()
    {        
        WaitForSeconds wait = new WaitForSeconds(1);

        yield return wait;

        for (int i = 0; i < stageSOs[stageIndex].EnemyCount; i++)
        {
            enemyList[i].SetActive(true);
            
            yield return wait;
        }
    }

    public void EnemyDead(GameObject enemy)
    {
        enemyCount--;

        Destroy(enemy);
        if(enemyCount == 0)
        {
            StageClear();
        }
    }

    public void StageClear()
    {
        enemyList.Clear();
        StartNewStage();
    }
}
