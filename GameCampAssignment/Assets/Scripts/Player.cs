using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Experimental.AI;

public class Player : MonoBehaviour
{   
    public PlayerData PlayerData;

    private List<SpellSO> spellSOList;
    [SerializeField] List<ISpell> spellList;
    [SerializeField] PlayerSO playerSO;
    private Dictionary<SpellSO, ISpell> spellDataDictionary;

    private int coinCount;

    public void Start()
    {
        PlayerData = new PlayerData(this, playerSO);
        spellSOList = new List<SpellSO>();
        spellList = new List<ISpell>();
        spellDataDictionary = new Dictionary<SpellSO, ISpell>();
    }

    public void Update()
    {
        Attack();
    }

    private void Attack()
    {
        foreach(ISpell spell in spellList)
        {
            spell.CheckCoolTIme();
        }
    }

    public void AddSpell(SpellSO spell)
    {
        if (spellSOList.Contains(spell)) return;

        spellSOList.Add(spell);       
        
        if(spellDataDictionary.ContainsKey(spell))
        {            
            spellDataDictionary[spell].ActiveSpell();
            spellList.Add(spellDataDictionary[spell]);
        }
        else
        {
            ISpell I_Spell;
            if (spell.ProjectileData.UseThis)
            {
                I_Spell = new ProjectileSpell(spell.ProjectileData);

                Projectile projectile;
                for (int i = 0; i < spell.ProjectileData.PoolingCount; i++)
                {
                    GameObject temp = Instantiate(spell.ProjectileData.Projectile, gameObject.transform.position, Quaternion.identity, gameObject.transform);
                    projectile = temp.GetComponent<Projectile>();
                    projectile.InitData(spell.ProjectileData, transform.position);
                    I_Spell.GetProjectiles(i, temp);
                    temp.SetActive(false);
                }
            }
            else if (spell.FieldData.UseThis)
            {
                I_Spell = new FieldSpell(spell.FieldData);

                Field field;
                for (int i = 0; i < spell.FieldData.PoolingCount; i++)
                {
                    GameObject temp = Instantiate(spell.FieldData.Projectile, gameObject.transform.position, Quaternion.identity, gameObject.transform);
                    field = temp.GetComponent<Field>();
                    field.InitData(spell.FieldData);
                    I_Spell.GetProjectiles(i, temp);
                    temp.SetActive(false);
                }
            }
            else
            {
                I_Spell = new MineSpell(spell.MineData);

                Mine mine;
                for (int i = 0; i < spell.MineData.PoolingCount; i++)
                {
                    GameObject temp = Instantiate(spell.MineData.Projectile, gameObject.transform.position, Quaternion.identity, gameObject.transform);
                    mine = temp.GetComponent<Mine>();
                    mine.InitData(spell.MineData);
                    I_Spell.GetProjectiles(i, temp);
                    temp.SetActive(false);
                }
            }

            spellList.Add(I_Spell);
            spellDataDictionary.Add(spell, I_Spell);
        }                   
    }

    public void RemoveSpell(SpellSO spell)
    {
        int index = spellSOList.IndexOf(spell);

        spellSOList.Remove(spell);
        spellList.RemoveAt(index);                
    }

    public void ShootProjectile(GameObject go)
    {
        go.SetActive(true);
    }

    public void GameOver()
    {
        spellList.Clear();        
    }
}
