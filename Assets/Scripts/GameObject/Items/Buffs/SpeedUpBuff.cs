using UnityEngine;
using System.Collections;

public class SpeedUpBuff : Buff
{
    private readonly float _percent;
    public float percent { get { return _percent; } }

    public SpeedUpBuff(string buffName, float duration,float percent) : base(buffName, duration)
    {
        _percent = percent;
    }

    public override void OnAdd(SpaceCraft spaceCraft)
    {
        base.OnAdd(spaceCraft);
        spaceCraft.enginePower = spaceCraft.enginePower * (1 + _percent);
        spaceCraft.maxSpeed = spaceCraft.maxSpeed * (1 + _percent);
    }

    public override void OnRemove(SpaceCraft spaceCraft)
    {
        spaceCraft.enginePower = spaceCraft.enginePower / (1 + _percent);
        spaceCraft.maxSpeed = spaceCraft.maxSpeed / (1 + _percent);
    }
}
