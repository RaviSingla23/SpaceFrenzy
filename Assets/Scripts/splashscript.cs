using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class splashscript : MonoBehaviour {


    private void Awake()
    {
        int num = FindObjectsOfType<splashscript>().Length;
        if(num>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Use this for initialization
    void Start()
    {
    }

    
	
	// Update is called once per frame
	void Update () {
        
	}
}
