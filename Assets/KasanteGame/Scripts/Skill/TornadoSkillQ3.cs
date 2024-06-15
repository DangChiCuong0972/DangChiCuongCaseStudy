using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoSkillQ3 : MonoBehaviour
{
    private KasaUseSkill kasaUseSkill;

    public float timeToUseQ3 = 3f;

    private KasaController player;

    private GameObject kasaPlayer;

    private bool isPressQ = false;
    // Start is called before the first frame update
    void Start()
    {
        kasaPlayer = GameObject.FindGameObjectWithTag("Tornado");
        kasaUseSkill = FindObjectOfType<KasaUseSkill>();
        Destroy(gameObject, 7.2f);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = kasaPlayer.transform.position;

        if(!isPressQ)
        {
            timeToUseQ3 -= Time.deltaTime;
            if(timeToUseQ3 <= 0)
            {
                timeToUseQ3 = 3f;
                isPressQ = true;
            }
        }
        
        if(Input.GetKeyDown(KeyCode.Q) && isPressQ)
        {
            Debug.Log(kasaUseSkill.canSkillQ3);
            Destroy(gameObject);
        }

        
    }
}
