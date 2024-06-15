using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[AddComponentMenu("ErzaScript/ErzaUIManager")]
public class ErzaUIManager : MonoBehaviour
{
    public TextMeshProUGUI textPower;
    // Start is called before the first frame update
    void Start()
    {
        textPower.text = ErzaDataManager.DataPower.ToString();
        ErzaGameManager.Instance.powerUpdateEvent.AddListener(UpdatePower);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void UpdatePower(int updatePower)
    {
        textPower.text = updatePower.ToString();
    }
}
