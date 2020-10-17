using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int _scorePerHit = 12;

    [SerializeField]
    private GameObject _deathFXParticle = null;

    [SerializeField]
    private int _hits = 3;

    [SerializeField]
    private Transform _parent;

    private ScoreBoard _scoreBoard;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        AddBoxCollider();
        _scoreBoard = FindObjectOfType<ScoreBoard>();
    }


    /// <summary>
    /// 
    /// </summary>
    private void AddBoxCollider()
    {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (_hits <= 0)
        {
            KillEnemy();
        }
    }


    /// <summary>
    /// 
    /// </summary>
    private void ProcessHit()
    {
        _scoreBoard.ScoreHit(_scorePerHit);
        _hits -= 1;
    }

    /// <summary>
    /// 
    /// </summary>
    private void KillEnemy()
    {
        if (_deathFXParticle != null && _parent != null)
        {
            GameObject deathParticleFX = Instantiate(_deathFXParticle, transform.position, Quaternion.identity);
            deathParticleFX.transform.parent = _parent;
        }
        Destroy(gameObject);
    }
}
