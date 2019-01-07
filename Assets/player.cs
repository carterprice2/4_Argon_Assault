using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class player : MonoBehaviour {

    [Tooltip("in ms^-1")][SerializeField] float xSpeed = 20f;
    [Tooltip("in m")] [SerializeField] float xrange = 7f;

    [Tooltip("in ms^-1")] [SerializeField] float ySpeed = 20f;
    [Tooltip("in m")] [SerializeField] float yMax = 4f;
    [Tooltip("in m")] [SerializeField] float yMin = -4f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = -5f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessingTranslation();
        ProcessingRotation();

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
        float ClampedPosY = Mathf.Clamp(rawNewYpos, yMin, yMax);

        transform.localPosition = new Vector3(ClampedPosX, ClampedPosY, transform.localPosition.z);
    }
}
