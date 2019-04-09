using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    ScoreBoard scoreBoard;
    [SerializeField] int ScorePerHit = 25;
    [SerializeField] int hits=10;

    // Use this for initialization
    void Start () {
        addBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
	}

    private void addBoxCollider()
    {
        Collider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(ScorePerHit);
        hits--;
        if(hits<=0)
        {
            killEnemy();
        }
    }

    private void killEnemy()
    {
        Instantiate(deathFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
