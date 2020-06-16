using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{
    [Tooltip("metres per second")]
    [SerializeField]
    private float _xSpeed = 4.0f;

    [Tooltip("X Clamp Value")]
    [SerializeField]
    [Range(0.0f, 4.0f)]
    private float _xClampValue = 4.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * _xSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedRawXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -_xClampValue, _xClampValue);

        transform.localPosition = new Vector3(clampedRawXPos, transform.localPosition.y, transform.localPosition.z);
    }
}
