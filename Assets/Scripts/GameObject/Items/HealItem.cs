using UnityEngine;
using System.Collections;

public class HealItem : Item
{
    [SerializeField]
    private int heal;

    protected override void Apply(SpaceCraft spaceCraft)
    {
        spaceCraft.Heal(heal);
    }
}
