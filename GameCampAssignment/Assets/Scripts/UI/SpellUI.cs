using UnityEngine;

public class SpellUI : MonoBehaviour
{
    public void OnClickMakeSpell()
    {
        BattleManager.Instance.GetRandomSpell();
    }

    public void OnClickOpenReinforce()
    {

    }
}
