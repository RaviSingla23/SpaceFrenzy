using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class controlhandler : MonoBehaviour {
    [Tooltip("In m/s")][SerializeField] float speed = 10f;

    float xoffset;
    float xthrow;
    [SerializeField] float xrange = 8f;
    [SerializeField] float yawfactor = 4f;

    [SerializeField] float rollfactor = -25f;

    float yoffset;
    float ythrow;
    [SerializeField] float yrange = 5f;
    [SerializeField] float pitchfactor = -3f;
    [SerializeField] float controlpitch = -10f;
    float pitch;
    float yaw;
    float roll;
    [SerializeField] GameObject[] guns;
    [SerializeField] GameObject[] jets;

    bool controlsenabled = true;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(controlsenabled)
        {
            processTranslation();
            procssRotation();
            processFiring();
        }
    }

    private void processFiring()
    {
        if(CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
        }

        else
        {
            DeactivateGuns();
        }
    }

    private void procssRotation()
    {
        pitch = transform.localPosition.y * pitchfactor + ythrow * controlpitch;
        yaw = transform.localPosition.x * yawfactor;
        roll = xthrow * rollfactor;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    private void processTranslation()
    {
        xthrow = CrossPlatformInputManager.GetAxis("Horizontal");
        xoffset = speed * Time.deltaTime * xthrow;

        ythrow = CrossPlatformInputManager.GetAxis("Vertical");
        yoffset = speed * Time.deltaTime * ythrow;

        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x + xoffset, -xrange, xrange), Mathf.Clamp(transform.localPosition.y + yoffset, -yrange, yrange), transform.localPosition.z);
    }

    void DisableControls() //called from string reference
    {
        controlsenabled = false;
        DeactivateGuns();
        DeactivateJets();
    }

    void ActivateGuns()
    {
        foreach(GameObject gun in guns)
        {
            var emission=gun.GetComponent<ParticleSystem>().emission;
            emission.enabled = true;
        }
    }

    void DeactivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            var emission = gun.GetComponent<ParticleSystem>().emission;
            emission.enabled = false;
        }
    }

    void DeactivateJets()
    {
        foreach (GameObject jet in jets)
        {
            jet.SetActive(false);
        }
    }
}
