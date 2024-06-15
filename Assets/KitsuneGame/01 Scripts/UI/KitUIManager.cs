using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[AddComponentMenu("KitScript/KitUIManager")]
public class KitUIManager : MonoBehaviour
{
    public TextMeshProUGUI textCoin;
    // Start is called before the first frame update
    void Start()
    {
        textCoin.text = KitDataManager.DataCoin.ToString();
        KitEventManager.coinUpdateEvent.AddListener(UpdateCoin);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void UpdateCoin(int coin)
    {
        textCoin.text = coin.ToString();
    }
}
