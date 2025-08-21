using UnityEngine;
using System;

[Serializable]
public class SpellData
{
    [SerializeField] string spellName;
    private Player player;
    private GameObject[] Projectiles;

    private int currentIndex;
    private int maxIndex;

    private int spellDamage;
    private float spellCoolTime;
    private float spellSpeed;

    private float spellTime;
    private float deltaTime;

    public int   SpellDamage => spellDamage;
    public float SpellCoolTime => spellCoolTime;
    public float    SpellSpeed => spellSpeed;

    public SpellData(SpellSO spellSO)
    {
        spellDamage = spellSO.SpellDamage;
        spellCoolTime = spellSO.SpellCoolTime;
        spellSpeed = spellSO.SpellSpeed;
        spellName = spellSO.SpellName;
        deltaTime = Time.deltaTime;
        player = BattleManager.Instance.Player;
        maxIndex = spellSO.PoolingCount;
        Projectiles = new GameObject[maxIndex];
        currentIndex = -1;
    }

    public void ActiveSpell()
    {
        spellTime = 0;
        currentIndex = -1;
    }

    public void GetProjectiles(int index, GameObject projectile)
    {
        Projectiles[index] = projectile;
    }

    public void CheckCoolTIme()
    {
        spellTime += deltaTime;

        if(spellTime >= spellCoolTime)
        {
            ShootProjectile();
            spellTime = 0;
        }
    }

    private void ShootProjectile()
    {
        currentIndex++;

        if(currentIndex >=  maxIndex)
        {
            currentIndex = 0;
        }

        player.ShootProjectile(Projectiles[currentIndex]);
    }
}
