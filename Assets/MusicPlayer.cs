using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

}
