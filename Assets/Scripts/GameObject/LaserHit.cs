using UnityEngine;
using System.Collections;

public class LaserHit : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _sprites;
    [SerializeField]
    private float _existTime = 0.05f;

	// Use this for initialization
	void Start ()
    {
        //随机显示一张图片
        GetComponent<SpriteRenderer>().sprite = _sprites[UnityEngine.Random.Range(0, _sprites.Length)];
        Destroy(gameObject, _existTime);//一定时间后销毁
	}
}
