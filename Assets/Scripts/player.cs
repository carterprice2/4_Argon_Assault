using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class player : MonoBehaviour {

    [Header("General")]
    [Tooltip("in ms^-1")][SerializeField] float xSpeed = 20f;
    [Tooltip("in ms^-1")] [SerializeField] float ySpeed = 20f;
    [Tooltip("in m")] [SerializeField] float yrange = 4f;
    [Tooltip("in m")] [SerializeField] float xrange = 7f;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = -5f;
    
    [Header("Control-Throw Based")]
    [SerializeField] float controlRollFactor = -20f;
    [SerializeField] float controlPitchFactor = -20f;

    float xThrow, yThrow;
    bool control_enabled = true;

    // Use this for initialization
    void Start () {
		
	}

    void OnPlayerDeath(bool state)  //called by string Reference
    {
        //print("Controls Frozen");
        control_enabled = state;
    }
   
    // Update is called once per frame
    void Update ()
    {
        if (control_enabled)
        {
            ProcessingTranslation();
            ProcessingRotation();
        }
        

    }

    private void ProcessingRotation()
    {
        float pitchDuetoPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDuetoControl = yThrow * controlPitchFactor;
        float pitch = pitchDuetoPosition + pitchDuetoControl;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
      
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);

    }

    private void ProcessingTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float rawNewXpos = transform.localPosition.x + xOffset;
        float ClampedPosX = Mathf.Clamp(rawNewXpos, -xrange, xrange);
        
        float rawNewYpos = transform.localPosition.y + yOffset;
        float ClampedPosY = Mathf.Clamp(rawNewYpos, -yrange, yrange);

        transform.localPosition = new Vector3(ClampedPosX, ClampedPosY, transform.localPosition.z);
    }
}
