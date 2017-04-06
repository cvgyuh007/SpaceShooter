using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Laser : MonoBehaviour
{
    public int damage;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private GameObject _hitPrefab;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody2D>().velocity = (Vector2)transform.up * _speed;
	}

    void OnTriggerEnter2D (Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            return;
        }

        coll.gameObject.SendMessage("TakeDamage", damage);
        Instantiate(_hitPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
