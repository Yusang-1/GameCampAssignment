using UnityEngine;

public class BattleManager : MonoBehaviour
{
    #region 싱글톤 구현
    private static BattleManager instance;

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


}
