using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellContainerUI : MonoBehaviour
{    
    [SerializeField] Image[] imageSpell1;
    [SerializeField] Image[] imageSpell2;
    [SerializeField] Image[] imageSpell3;
    private Image[][] imageSpells;

    [SerializeField] TextMeshProUGUI[] textSpell1;
    [SerializeField] TextMeshProUGUI[] textSpell2;
    [SerializeField] TextMeshProUGUI[] textSpell3;
    private TextMeshProUGUI[][] textSpells;

    [SerializeField] Button[] buttonSpell1;
    [SerializeField] Button[] buttonSpell2;
    [SerializeField] Button[] buttonSpell3;
    private Button[][] promotionButtons;

    public void GetBattleUI()
    {
        imageSpells = new Image[][] { imageSpell1, imageSpell2, imageSpell3 };
        textSpells = new TextMeshProUGUI[][] { textSpell1, textSpell2, textSpell3 };
        promotionButtons = new Button[][] { buttonSpell1, buttonSpell2, buttonSpell3 };
    }

    public void UpdateSpellUI()
    {
        int[,] spellCount = BattleManager.Instance.SpellContainer.SpellCount;

        for(int i = 0; i < spellCount.GetLength(0); i++)
        {
            for(int j = 0; j < spellCount.GetLength(1); j++)
            {
                if (spellCount[i,j] > 0)
                {
                    imageSpells[i][j].color = Color.red;
                }
                else
                {
                    imageSpells[i][j].color = Color.white;
                }

                textSpells[i][j].text = spellCount[i, j].ToString();
            }
        }
    }
    
    public void GetSpellCanPromotion(int row, int column)
    {
        promotionButtons[row][column].enabled = true;
    }

    public void OnClickPromotionSpell(SpellIndex spell)
    {
        SpellContainer spellContainer = BattleManager.Instance.SpellContainer;

        spellContainer.GetRandomSpell(spell.RankIndex + 1);
        spellContainer.SpellPromotion(spell.ElementIndex, spell.RankIndex);

        UpdateSpellUI();
    }
}
