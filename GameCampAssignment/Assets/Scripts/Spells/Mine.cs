using UnityEngine;

public class Mine : MonoBehaviour
{
    private int damage;
    private Vector2 spawnPosition;
    private float yMax, yMin;

    private const string enemyTag = "Enemy";

    public void OnEnable()
    {
        float y = Random.Range(yMin, yMax);
        spawnPosition = new Vector2(0, y);
        gameObject.transform.position = spawnPosition;
    }

    public void InitData(SpellMineData spellData)
    {
        damage = spellData.SpellDamage;
        yMax = spellData.SpawnYMax;
        yMin = spellData.SpawnYMin;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemyTag))
        {
            collision.GetComponent<Enemy>().I_Enemy.TakeDamage(damage);

            Deactive();
        }
    }

    public void Deactive()
    {
        transform.position = spawnPosition;
        gameObject.SetActive(false);
    }

    public void Active()
    {
        gameObject.SetActive(true);
    }
}
