using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[AddComponentMenu("MyScript/UIManager")]
public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI textCoin;
    // Start is called before the first frame update
    void Start()
    {
        textCoin.text = DataManager.DataCoin.ToString();
        GameManager.Instance.coinEventUpdate.AddListener(AddUiCoin);
        //EventGameManager.coinEvent.AddListener(AddUiCoin);
    }

    void AddUiCoin(int coin)
    {
        textCoin.text = coin.ToString();
    }
   
}
