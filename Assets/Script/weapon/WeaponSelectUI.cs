using UnityEngine;

public class WeaponSelectUI : MonoBehaviour
{
    public Attack tower; // ��ž�� ���� Attack ��ũ��Ʈ�� �巡�׷� ����

    public void OnSelectArrow()
    {
        tower.SetWeaponType(WeaponType.Arrow);
        Debug.Log("ȭ�켱��");
    }

    public void OnSelectStone()
    {
        tower.SetWeaponType(WeaponType.Stone);
        Debug.Log("������");
    }

    public void OnSelectIce()
    {
        tower.SetWeaponType(WeaponType.Ice);
        Debug.Log("��������");
    }

    public void OnSelectFire()
    {
        tower.SetWeaponType(WeaponType.Fire);
        Debug.Log("�� ����");
    }
}
