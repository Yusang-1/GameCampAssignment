using UnityEngine;
using System;

[Serializable]
public class MineSpell : ISpell
{
    [SerializeField] string spellName;
    private Player player;
    private GameObject[] spellObjects;

    private int maxIndex;

    private int spellDamage;
    private float spellCoolTime;
    private int currentMineCount;

    private float spellTime;

    public int SpellDamage => spellDamage;
    public float SpellCoolTime => spellCoolTime;

    public MineSpell(SpellMineData data)
    {
        spellName = data.SpellName;
        spellDamage = data.SpellDamage;
        spellCoolTime = data.SpellCoolTime;
        player = BattleManager.Instance.Player;
        maxIndex = data.PoolingCount;
        spellObjects = new GameObject[maxIndex];
    }

    public void ActiveSpell()
    {
        currentMineCount = 0;
        spellTime = 0;
    }

    public void GetProjectiles(int index, GameObject projectile)
    {
        spellObjects[index] = projectile;
    }

    public void CheckCoolTIme()
    {
        if (currentMineCount == maxIndex) return;

        spellTime += Time.deltaTime;

        if (spellTime >= spellCoolTime)
        {
            ShootProjectile();
            spellTime = 0;
        }
    }

    public void ShootProjectile()
    {
        foreach(GameObject go in spellObjects)
        {
            if(go.activeSelf == false)
            {
                player.ShootProjectile(go);
                return;
            }
        }        
    }
}