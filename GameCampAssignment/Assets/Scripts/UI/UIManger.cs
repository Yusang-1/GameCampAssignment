using UnityEngine;
using TMPro;

public class UIManger : MonoBehaviour
{
    #region 싱글톤 구현
    private static UIManger instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static UIManger Instance
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

    [SerializeField] GameObject BattleUI;
    [SerializeField] GameObject TitleUI;

    public SpellContainerUI SpellContainerUI;
    [SerializeField] TextMeshProUGUI stageText;
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] GameObject gameOverPanel;

    public void TurnBattleUI(bool value)
    {
        BattleUI.SetActive(value);
        TitleUI.SetActive(!value);
    }

    public void NextStage(int stageIndex)
    {
        stageText.text = stageIndex.ToString();
    }

    public void UpdateCoinText(int amount)
    {
        coinText.text = amount.ToString();
    }

    public void TurnGameOverPanel(bool value)
    {
        gameOverPanel.SetActive(value);
    }

    public void OnClickReturn()
    {
        BattleManager.Instance.ExitBattle();
        gameOverPanel.SetActive(false);
    }

    public void OnClickStart()
    {
        GameManager.Instance.LoadBattleScene();
    }
}
