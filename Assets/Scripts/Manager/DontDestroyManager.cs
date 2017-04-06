using UnityEngine;
using System.Collections;

public class DontDestroyManager : MonoBehaviour
{
    private static DontDestroyManager _instance;

    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            DestroyImmediate(this.gameObject);
        }
    }
}
