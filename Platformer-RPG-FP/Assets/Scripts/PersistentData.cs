using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{

    public static PersistentData Instance;
    public string currentName;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }
}
