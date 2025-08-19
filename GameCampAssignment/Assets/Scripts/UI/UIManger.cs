using UnityEngine;

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

    public SpellContainerUI SpellContainerUI;
}
