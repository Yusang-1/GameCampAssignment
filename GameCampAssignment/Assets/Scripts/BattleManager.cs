using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    #region 싱글톤 구현
    private static BattleManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public static BattleManager Instance 
    { 
        get
        {
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    #endregion

    public SpellContainer SpellContainer;
    public Player Player;
    public IDamagable I_Player;

    private int coinCount;

    [SerializeField] int spellPrice;
    [SerializeField] int initialCoin;

    private void Start()
    {
        UIManger.Instance.TurnBattleUI(true);
        I_Player = Player.PlayerData;
        GetCoin(initialCoin);
        StageManager.Instance.StartNewStage();
    }

    public void GetCoin(int amount)
    {
        coinCount += amount;
        UIManger.Instance.UpdateCoinText(coinCount);
    }

    public void SpendCoin(int amount)
    {
        coinCount -= amount;
        UIManger.Instance.UpdateCoinText(coinCount);
    }

    public void GetRandomSpell()
    {
        if (coinCount < spellPrice) return;

        SpendCoin(spellPrice);
        SpellContainer.GetRandomSpell();
    }

    public void ExitBattle()
    {
        UIManger.Instance.TurnBattleUI(false);
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }
}
