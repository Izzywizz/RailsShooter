using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject _deathFXParticle = null;

    [SerializeField]
    private Transform _parent;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
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
        if (_deathFXParticle != null)
        {
            GameObject deathParticleFX = Instantiate(_deathFXParticle, transform.position, Quaternion.identity);
            deathParticleFX.transform.parent = _parent;
        }
        Destroy(gameObject);
    }
}
