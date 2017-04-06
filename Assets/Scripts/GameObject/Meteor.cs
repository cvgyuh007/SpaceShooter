using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour
{
    public Sprite[] sprites;

	// Use this for initialization
	void Start ()
    {
        //显示随机颜色的陨石图片
        GetComponent<SpriteRenderer>().sprite = sprites[UnityEngine.Random.Range(0, sprites.Length)];
	}
}
