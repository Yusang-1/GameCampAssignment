using UnityEngine;

[CreateAssetMenu(fileName = "Spells", menuName = "Spells/Spell")]
public class SpellSO : ScriptableObject
{
    public enum ElementType
    {
        Fire,
        Eearth,
        Water
    }

    public string SpellName;
    public int SpellRank;
    public ElementType Element;
    public int SpellDamage;
    public float SpellCoolTime;
    public float SpellSpeed;
    public GameObject Projectile;
    public int PoolingCount;
}
