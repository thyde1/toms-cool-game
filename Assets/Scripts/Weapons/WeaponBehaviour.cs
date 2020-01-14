using UnityEngine;
using System.Collections;

public interface WeaponBehaviour
{
    KeyCode HotKey { get; }

    void Fire();
}
