using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KasaFXHeartQ1 : MonoBehaviour
{
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy != null)
        {
            transform.position = enemy.transform.position + new Vector3(0, 0, -1f);

        }
    }
}
