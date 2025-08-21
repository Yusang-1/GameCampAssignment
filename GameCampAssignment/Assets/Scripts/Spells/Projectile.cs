using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int damage;
    private float speed;
    private float deltaTime;
    private Vector2 position;
    private Vector2 spawnPosition;
    private Vector2 deadPosition;

    private const string enemyTag = "Enemy";
    
    private void Update()
    {
        ProjectileMove();
        CheckDeadPoint();
    }

    public void InitData(SpellProjectileData spellData, Vector2 spawnPos)
    {
        damage = spellData.SpellDamage;
        speed = spellData.SpellSpeed;
        position = gameObject.transform.position;
        spawnPosition = spawnPos;
        deadPosition = StageManager.Instance.SpawnPoint.position;
    }

    private void ProjectileMove()
    {
        deltaTime = Time.deltaTime;
        position.y -= speed * deltaTime;
        gameObject.transform.position = position;
    }

    private void CheckDeadPoint()
    {
        if(transform.position.y <= deadPosition.y)
        {            
            DeActive();
        }
    }

    private void DeActive()
    {
        transform.position = spawnPosition;
        position = transform.position;        
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(enemyTag))
        {
            collision.GetComponent<Enemy>().I_Enemy.TakeDamage(damage);

            DeActive();
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