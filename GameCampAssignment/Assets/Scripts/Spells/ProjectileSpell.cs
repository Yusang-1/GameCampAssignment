using UnityEngine;
using System;

[Serializable]
public class ProjectileSpell : ISpell
{
    [SerializeField] string spellName;
    private Player player;
    private GameObject[] spellObjects;

    private int currentIndex;
    private int maxIndex;

    private int spellDamage;
    private float spellCoolTime;
    private float spellSpeed;

    private float spellTime;

    public int SpellDamage => spellDamage;
    public float SpellCoolTime => spellCoolTime;
    public float SpellSpeed => spellSpeed;

    public ProjectileSpell(SpellProjectileData data)
    {
        spellDamage = data.SpellDamage;
        spellCoolTime = data.SpellCoolTime;
        spellSpeed = data.SpellSpeed;
        spellName = data.SpellName;
        player = BattleManager.Instance.Player;
        maxIndex = data.PoolingCount;
        spellObjects = new GameObject[maxIndex];
        currentIndex = -1;
    }

    public void ActiveSpell()
    {
        spellTime = 0;
        currentIndex = -1;
    }

    public void GetProjectiles(int index, GameObject projectile)
    {
        spellObjects[index] = projectile;
    }

    public void CheckCoolTIme()
    {
        spellTime += Time.deltaTime;

        if (spellTime >= spellCoolTime)
        {
            ShootProjectile();
            spellTime = 0;
        }
    }

    public void ShootProjectile()
    {
        currentIndex++;

        if (currentIndex >= maxIndex)
        {
            currentIndex = 0;
        }

        player.ShootProjectile(spellObjects[currentIndex]);
    }
}
