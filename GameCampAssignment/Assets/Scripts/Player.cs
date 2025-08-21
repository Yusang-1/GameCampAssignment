using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{   
    public PlayerData PlayerData;

    private List<SpellSO> spellSOList;
    [SerializeField] List<SpellData> spellList;
    [SerializeField] PlayerSO playerSO;
    private Dictionary<SpellSO, SpellData> spellDataDictionary;

    private int coinCount;

    public void Start()
    {
        PlayerData = new PlayerData(this, playerSO);
        spellSOList = new List<SpellSO>();
        spellList = new List<SpellData>();
        spellDataDictionary = new Dictionary<SpellSO, SpellData>();
    }

    public void Update()
    {
        Attack();
    }

    private void Attack()
    {
        foreach(SpellData spell in spellList)
        {
            spell.CheckCoolTIme();
        }
    }

    public void AddSpell(SpellSO spell)
    {
        if (spellSOList.Contains(spell)) return;

        spellSOList.Add(spell);
        
        List<Projectile> projectileList = new List<Projectile>();
        Projectile projectile;

        if(spellDataDictionary.ContainsKey(spell))
        {            
            spellDataDictionary[spell].ActiveSpell();
            spellList.Add(spellDataDictionary[spell]);
        }
        else
        {
            SpellData spellData = new SpellData(spell);
            spellList.Add(spellData);
            
            for (int i = 0; i < spell.PoolingCount; i++)
            {
                GameObject temp = Instantiate(spell.Projectile, gameObject.transform.position, Quaternion.identity, gameObject.transform);
                projectile = temp.GetComponent<Projectile>();
                projectile.InitData(spellData, transform.position);
                spellData.GetProjectiles(i, temp);
                temp.SetActive(false);
                projectileList.Add(projectile);
            }
            spellDataDictionary.Add(spell, spellData);
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
