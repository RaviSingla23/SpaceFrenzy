using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collisionhandler : MonoBehaviour {
    [SerializeField] float loadDelay = 1f;
    [SerializeField] GameObject deathFx;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        startDeath();
    }

    private void startDeath()
    {
       SendMessage("DisableControls");
        deathFx.SetActive(true);
        GetComponent<MeshRenderer>().enabled = false;
        Invoke("RealoadLevel", loadDelay);
    }

    private void RealoadLevel() //string reference
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
