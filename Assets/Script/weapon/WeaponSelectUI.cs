using UnityEngine;

public class WeaponSelectUI : MonoBehaviour
{
    public Attack tower; // 포탑에 붙은 Attack 스크립트를 드래그로 연결

    public void OnSelectArrow()
    {
        tower.SetWeaponType(WeaponType.Arrow);
        Debug.Log("화살선택");
    }

    public void OnSelectStone()
    {
        tower.SetWeaponType(WeaponType.Stone);
        Debug.Log("돌선택");
    }

    public void OnSelectIce()
    {
        tower.SetWeaponType(WeaponType.Ice);
    }

    public void OnSelectFire()
    {
        tower.SetWeaponType(WeaponType.Fire);
    }
}
