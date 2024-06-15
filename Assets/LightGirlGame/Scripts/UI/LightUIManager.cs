using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[AddComponentMenu("LightScript/LightUIManager")]
public class LightUIManager : MonoBehaviour
{
    public TextMeshProUGUI textCoin;
    // Start is called before the first frame update
    void Start()
    {
        textCoin.text = LightDataManager.DataCoin.ToString();
        LightGameManager.Instance.coinUpdateEvent.AddListener(UpdateCoin);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void UpdateCoin(int coin)
    {
        textCoin.text = coin.ToString();
    }
}
