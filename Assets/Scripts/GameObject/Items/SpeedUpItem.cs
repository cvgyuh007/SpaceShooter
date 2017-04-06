using UnityEngine;
using System.Collections;
using System;

public class SpeedUpItem : Item
{
    [SerializeField]
    private string _buffName;
    [SerializeField]
    private float _duration;
    [SerializeField]
    private float _percent;

    protected override void Apply(SpaceCraft spaceCraft)
    {
        spaceCraft.AddBuff(new SpeedUpBuff(_buffName, _duration, _percent));
    }
}
