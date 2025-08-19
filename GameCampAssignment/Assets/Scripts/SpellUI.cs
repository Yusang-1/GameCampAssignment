using UnityEngine;

public class SpellUI : MonoBehaviour
{
    public void OnClickMakeSpell()
    {
        BattleManager.Instance.SpellContainer.GetRandomSpell();
    }

    public void OnClickOpenReinforce()
    {

    }
}
