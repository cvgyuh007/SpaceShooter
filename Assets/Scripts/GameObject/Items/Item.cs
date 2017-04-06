using UnityEngine;
using System.Collections;

public abstract class Item : MonoBehaviour
{
    protected abstract void Apply(SpaceCraft spaceCraft);

    void OnTriggerEnter2D(Collider2D coll)
    {
        SpaceCraft spaceCraft = coll.GetComponent<SpaceCraft>();
        Apply(spaceCraft);
        Destroy(gameObject);
    }
}