using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player/Player")]
public class PlayerSO : ScriptableObject
{
    public string PlayerName;
    public int MaxHP;
}
