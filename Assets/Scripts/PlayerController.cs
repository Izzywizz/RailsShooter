using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour
{
    [Header("General")]

    [SerializeField]
    GameObject[] _guns;

    [Tooltip("metres per second")]
    [SerializeField]
    private float _controlSpeed = 20.0f;

    [Tooltip("The Min/ Max value the ship is contrained to in metres")]
    [SerializeField]
    [Range(0.0f, 10.0f)]
    private float _xClampValue = 5.0f;

    [Tooltip("The Min/ Max value the ship is contrained to in metres")]
    [SerializeField]
    [Range(0.0f, 10.0f)]
    private float _yClampedValue = 3.0f;

    [Header("Screen-Position Based")]

    [SerializeField]
    private float _positionPitchFactor = -5.0f;

    [SerializeField]
    private float _positionYawFactor = 5.0f;

    [Header("Control-Throw Based")]
    [SerializeField]
    private float _controlPitchFactor = -20.0f;

    [SerializeField]
    private float _controlRollFactor = -20.0f;

    private float _xThrow = 0.0f;
    private float _yThrow = 0.0f;
    private bool _isControlsEnabled = true;

    /// Update is called once per frame
    void Update()
    {
        if (_isControlsEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }


    /// <summary>
    /// 
    /// </summary>
    private void ProcessTranslation()
    {
        // X - Direction
        _xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = _xThrow * _controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float xClampedRawPos = Mathf.Clamp(rawXPos, -_xClampValue, _xClampValue);

        // Y - Direction Movement
        _yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = _yThrow * _controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float yClampedRawPos = Mathf.Clamp(rawYPos, -_yClampedValue, _yClampedValue);

        transform.localPosition = new Vector3(xClampedRawPos, yClampedRawPos, transform.localPosition.z);
    }


    /// <summary>
    /// 
    /// </summary>
    private void OnPlayerDeath()
    {
        _isControlsEnabled = false;
    }


    /// <summary>
    /// 
    /// </summary>
    private void ProcessRotation()
    {
        // Rotation - x, y, z
        // Rotation - pitch, yaw, roll
        // Order matters with rotation

        float pitchDuetoPosition = transform.localPosition.y * _positionPitchFactor;

        // recall that the Throw is the value that is taken from the movement of the control stick
        // so when it left stick pushes up it points the nose of the place up based on that throw value
      
        float pitchDueToControlThrow = _yThrow * _controlPitchFactor;
        float pitch = pitchDuetoPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * _positionYawFactor;

        float roll = _xThrow * _controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }


    /// <summary>
    /// 
    /// </summary>
    private void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
        }
        else
        {
            DeactivateGuns();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void ActivateGuns()
    {
        for (int i = 0; i < _guns.Length; i++)
        {
            _guns[i].SetActive(true);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    private void DeactivateGuns()
    {
        for (int i = 0; i < _guns.Length; i++)
        {
            _guns[i].SetActive(false);
        }
    }



}
