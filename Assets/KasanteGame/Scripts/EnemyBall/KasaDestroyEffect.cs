using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KasaDestroyEffect : MonoBehaviour
{
    public float timeDelay = 1f;
    public GameObject enemyBall;
    public string nameEnemyBall;
    // Start is called before the first frame update
    void Start()
    {
        enemyBall = GameObject.FindGameObjectWithTag(nameEnemyBall);
        Destroy(gameObject, timeDelay);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = enemyBall.transform.position;
    }
}
