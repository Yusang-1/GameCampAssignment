using UnityEngine;

public class PlayerData : IDamagable
{
    private int maxHP;
    private int currentHP;
    private GameObject prefab;
    private Player player;

    public int MaxHP => maxHP;
    public int CurrentHP => currentHP;  
    public GameObject Prefab => prefab;

    public PlayerData(Player player, PlayerSO playerSO)
    {
        maxHP = playerSO.MaxHP;
        currentHP = maxHP;
        this.player = player;
    }

    public void TakeDamage(int damage)
    {
        if (currentHP == 0) return;

        currentHP = Mathf.Clamp(currentHP -= damage, 0, maxHP);
        Debug.Log(currentHP);
        if(currentHP == 0)
        {
            PlayerDead();
        }
    }

    private void PlayerDead()
    {
        Debug.Log("게임 오버");
        UIManger.Instance.TurnGameOverPanel(true);
        player.GameOver();
    }
}
