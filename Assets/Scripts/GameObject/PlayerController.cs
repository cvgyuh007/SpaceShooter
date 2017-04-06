using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpaceCraft))]
public class PlayerController : MonoBehaviour
{
    private SpaceCraft _spaceCraft;

    void Awake()
    {
        _spaceCraft = GetComponent<SpaceCraft>();
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        bool engine = Input.GetKey(KeyCode.W);
        float rotate = Input.GetAxis("Horizontal");
        bool shoot = Input.GetMouseButton(0);

        _spaceCraft.UpdateInput(engine, rotate, shoot);
    }
}
