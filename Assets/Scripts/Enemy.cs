using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particles collided with enemy " + gameObject.name);
        Destroy(gameObject);
    }
}
