using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ok as long as only this script handles loading scenes

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In seconds")]
    [SerializeField]
    private float _levelLoadDelay = 5.0f;

    [Tooltip("Explosion Particle effects prefab on Player")]
    [SerializeField]
    private GameObject _deathFX = null;

    private Coroutine _loadingLevelCoroutine = null;
    private int _sceneIndexForFirstLevel = 1;

    /// <summary>
    /// testing triggering
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player triggered with somethings");
        StartDeathSequence();
    }


    /// <summary>
    /// 
    /// </summary>
    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        _deathFX.SetActive(true);

        if (_loadingLevelCoroutine == null)
        {
            _loadingLevelCoroutine = StartCoroutine("LoadingLevelAgain");
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerator LoadingLevelAgain()
    {
        yield return new WaitForSeconds(_levelLoadDelay);
        // Code to execute after the delay

        SceneManager.LoadScene(_sceneIndexForFirstLevel);
        _loadingLevelCoroutine = null;
    }
}
