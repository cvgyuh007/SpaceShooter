using UnityEngine;
using System.Collections;

public abstract class Buff
{
    private readonly string _buffName;
    public string buffName { get { return _buffName; } }
    private readonly float _duration;
    public float duration { get { return _duration; } }

    private float _remainTime;
    public float remainTime { get { return _remainTime; } }
    public bool isFinished { get { return _remainTime <= 0.0f; } }

    public Buff(string buffName,float duration)
    {
        _buffName = buffName;
        _duration = duration;
    }

    public virtual void OnAdd(SpaceCraft spaceCraft)
    {
        _remainTime = _duration;
    }
    public virtual void OnUpdate(SpaceCraft spaceCraft)
    {
        _remainTime -= Time.deltaTime;
    }
    public virtual void OnRemove(SpaceCraft spaceCraft) { }

    public void Reset()
    {
        _remainTime = _duration;
    }
}