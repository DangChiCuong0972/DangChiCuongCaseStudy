using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KasaUIShootManager : MonoBehaviour
{

    public TextMeshProUGUI textCoin;
    public GameObject panelWin;
    public int coinValueWin = 20;
     
    private bool isWin = false;
    private float timeWin = 4f;
    // Start is called before the first frame update
    void Start()
    {
        panelWin.SetActive(false);
        KasaShootManager.Instan.coinEvent.AddListener(UpdateCoin);
        textCoin.text = KasaShootManager.Instan.GetCoin().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(KasaShootManager.Instan.coin >= 50 && !isWin )
        {
            panelWin.SetActive(true);
            timeWin -= Time.deltaTime;
            if(timeWin <= 0)
            {
                panelWin.SetActive(false);
                isWin = true;
            }
        }
    }

    public void UpdateCoin()
    {
        textCoin.text = KasaShootManager.Instan.GetCoin().ToString();
    }
}
