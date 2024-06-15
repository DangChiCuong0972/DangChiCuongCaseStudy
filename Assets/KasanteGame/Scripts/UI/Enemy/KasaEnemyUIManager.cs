using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KasaEnemyUIManager : MonoBehaviour
{
    private KasaEnemyHealth kasaEnemyHealth;
    public Slider enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        kasaEnemyHealth = FindObjectOfType<KasaEnemyHealth>();
        enemyHealth.value = kasaEnemyHealth.GetHealth();
    }


    // Update is called once per frame
    void Update()
    {
        enemyHealth.value = kasaEnemyHealth.GetHealth();
    }


}
