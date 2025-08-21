using UnityEngine;

public interface ISpell
{
    public void ActiveSpell();

    public void GetProjectiles(int index, GameObject projectile);

    public void CheckCoolTIme();

    public void ShootProjectile();
}



