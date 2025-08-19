using UnityEngine;

public class SpellContainer : MonoBehaviour
{
    private const int spellCount = 3;
    private const int spellRankCount = 6;

    [SerializeField] float[] rankProbability;

    public int[,] SpellCount = new int[spellCount,spellRankCount];
    [SerializeField] SpellSO[] spellsFire;
    [SerializeField] SpellSO[] spellsEarth;
    [SerializeField] SpellSO[] spellsWater;
    private SpellSO[][] spellSOs;

    private void Start()
    {
        spellSOs = new SpellSO[][] {spellsFire, spellsEarth, spellsWater};
    }

    public void GetRandomSpell(int lowestRank = 0)
    {
        SpellSO spell;
        SpellContainerUI spellContainerUI = UIManger.Instance.SpellContainerUI;

        int rank = GetRank(lowestRank); // 0 ~ 5

        int element = Random.Range(0, spellCount); // 0 ~ 2

        SpellCount[element, rank]++;
        spell = spellSOs[element][rank];

        spellContainerUI.UpdateSpellUI();

        if (SpellCount[element, rank] >= 3 && rank != spellRankCount - 1)
        {
            spellContainerUI.GetSpellCanPromotion(element, rank);
        }
    }

    public void SpellPromotion(int row, int column)
    {
        SpellCount[row, column] -= 3;
    }

    public int GetRank(int lowestRank)
    {
        float randNum = Random.Range(0, 100.0f);
        float compareNum = 0; ;

        for(int i = 0; i < spellRankCount; i++)
        {
            compareNum += rankProbability[i];

            if(i >= lowestRank && randNum <= compareNum)
            {
                Debug.Log($"randNum : {randNum}, rank : {i}");
                return i;
            }
        }

        return -1;
    }
}
