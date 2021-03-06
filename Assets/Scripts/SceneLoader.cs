﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private float _loadDelayTime = 5.0f;

    private int _sceneIndexForFirstLevel = 1;

    private Coroutine _loadingCoroutine = null;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        if (_loadingCoroutine == null)
        {
            _loadingCoroutine = StartCoroutine(DelaySceneLoadingAfterTime(_loadDelayTime));
        }

    }


    /// <summary>
    /// 
    /// </summary>
    private void OnDisable()
    {
        _loadingCoroutine = null;
    }


    /// <summary>
    /// Coroutine that loads the next after a delay
    /// </summary>
    /// <param name="_loadDelayTime"></param>
    /// <returns></returns>
    private IEnumerator DelaySceneLoadingAfterTime(float _loadDelayTime)
    {
        yield return new WaitForSeconds(_loadDelayTime);
        // Code to execute after the delay
        SceneManager.LoadScene(_sceneIndexForFirstLevel);

        _loadingCoroutine = null;
    }
}
