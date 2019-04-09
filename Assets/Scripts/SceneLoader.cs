using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
    
    }

    public void loadGame()
    {
        SceneManager.LoadScene(1);
    }
}
