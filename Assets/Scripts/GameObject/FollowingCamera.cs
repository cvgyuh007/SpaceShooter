using UnityEngine;
using System.Collections;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    private float depth;

    // Use this for initialization
    void Start()
    {
        depth = transform.position.z;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Follow();
    }

    void Follow()
    {
        if(_target == null)
        {
            return;
        }
        transform.position = new Vector3(_target.position.x, _target.position.y, depth);
        transform.rotation = _target.rotation;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}