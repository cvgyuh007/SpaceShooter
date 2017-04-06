using UnityEngine;
using System.Collections;
using System;

public class ShieldItem : Item
{
    [SerializeField]
    private GameObject _shieldPrefab;

    protected override void Apply(SpaceCraft spaceCraft)
    {
        GameObject shield = (GameObject)Instantiate(_shieldPrefab, spaceCraft.transform.position, spaceCraft.transform.rotation);
        shield.transform.SetParent(spaceCraft.transform);
    }
}
