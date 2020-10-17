using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject _deathFXParticle = null;

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
            Instantiate(_deathFXParticle, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
