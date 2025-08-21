using System;
using UnityEngine;
using static SpellSO;

[CreateAssetMenu(fileName = "Spells", menuName = "Spells/Spell")]
public class SpellSO : ScriptableObject
{
    public enum ElementType
    {
        Fire,
        Eearth,
        Water
    }

    public SpellProjectileData ProjectileData;
    public SpellFieldData FieldData;
    public SpellMineData MineData;
}

[Serializable]
public struct SpellProjectileData
{
    public bool UseThis;

    public string SpellName;
    public int SpellRank;
    public ElementType Element;
    public int SpellDamage;
    public float SpellCoolTime;
    public float SpellSpeed;
    public GameObject Projectile;
    public int PoolingCount;
}

[Serializable]
public struct SpellFieldData
{
    public bool UseThis;

    public string SpellName;
    public int SpellRank;
    public ElementType Element;
    public int SpellDamage;
    public float spellDurationTime;
    public float DamageCoolTime;
    public float SpellCoolTime;    
    public GameObject Projectile;
    public int PoolingCount;
    public float SpawnYMax;
    public float SpawnYMin;
}

[Serializable]
public struct SpellMineData
{
    public bool UseThis;

    public string SpellName;
    public int SpellRank;
    public ElementType Element;
    public int SpellDamage;
    public float SpellCoolTime;    
    public GameObject Projectile;
    public int PoolingCount;
    public float SpawnYMax;
    public float SpawnYMin;
}
