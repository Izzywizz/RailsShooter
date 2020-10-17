using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField]
    private float _timeDelayForDestruct = 5.0f;
    private void Start()
    {
        // TODO Allow customisation
        Destroy(gameObject, _timeDelayForDestruct);
    }
}
