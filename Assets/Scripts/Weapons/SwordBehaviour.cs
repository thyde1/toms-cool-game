using UnityEngine;
using System.Collections;

public class SwordBehaviour : MonoBehaviour, WeaponBehaviour
{
    public KeyCode HotKey => KeyCode.Alpha1;

    public void Fire()
    {
        throw new System.NotImplementedException();
    }
}
