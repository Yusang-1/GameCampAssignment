using UnityEngine;
using System.Collections.Generic;

public class Field : MonoBehaviour
{
    private int damage;
    private float damageCoolTime;
    private float duration;
    private float durationTime;
    private Vector2 spawnPosition;

    private const string enemyTag = "Enemy";

    private List<Enemy> enemyOnField;
    private List<float> checkDamageCoolTIme;

    private float yMax;
    private float yMin;

    private void Update()
    {
        CheckDuration();
        DamageCount();
    }

    private void OnEnable()
    {
        float y = Random.Range(yMin, yMax);
        spawnPosition = new Vector2(0, y);
        gameObject.transform.localPosition = spawnPosition;
    }

    public void InitData(SpellFieldData spellData)
    {
        damage = spellData.SpellDamage;
        damageCoolTime = spellData.DamageCoolTime;
        duration = spellData.spellDurationTime;
        enemyOnField = new List<Enemy>();
        yMax = spellData.SpawnYMax;
        yMin = spellData.SpawnYMin;

        checkDamageCoolTIme = new List<float>();
    }

    private void CheckDuration()
    {
        durationTime += Time.deltaTime;        

        if (durationTime >= duration)
        {
            DeActive();
        }
    }

    private void DamageCount()
    {
        for(int i = 0; i < checkDamageCoolTIme.Count; ++i)
        {
            checkDamageCoolTIme[i] += Time.deltaTime;

            if(checkDamageCoolTIme[i] >= damageCoolTime)
            {
                enemyOnField[i].I_Enemy.TakeDamage(damage);
            }
        }
    }

    private void DeActive()
    {
        durationTime = 0;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemyTag))
        {
            Enemy enemy = collision.GetComponent<Enemy>();

            if (enemyOnField.Contains(enemy)) return;
            else
            {
                enemyOnField.Add(enemy);
                checkDamageCoolTIme.Add(0);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(enemyTag))
        {
            Enemy enemy = collision.GetComponent<Enemy>();

            if (enemyOnField.Contains(enemy))
            {
                int index = enemyOnField.IndexOf(enemy);
                enemyOnField.Remove(enemy);
                checkDamageCoolTIme.RemoveAt(index);
            }
        }
    }

    public void Deactive()
    {
        gameObject.SetActive(false);
    }

    public void Active()
    {
        gameObject.SetActive(true);
    }
}
