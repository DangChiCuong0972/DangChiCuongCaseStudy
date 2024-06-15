using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KasaSkillQ : MonoBehaviour
{
    private KasaSkillManager kasaSkillManager;

    //private bool canUseSkill = true;

    public GameObject skillQ3Physic;

    public GameObject skillQ3Tornado;

    public Transform pointSkillToradoQ3;

    public Transform pointBulletQ3;

    // Start is called before the first frame update
    void Start()
    {
        kasaSkillManager = FindObjectOfType<KasaSkillManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SkillQ3()
    {
       if(skillQ3Physic != null)
        {
            Instantiate(skillQ3Physic, pointBulletQ3.position,pointBulletQ3.rotation);
        }
    }

    public void SkillTornadoQ3()
    {
        if (skillQ3Tornado != null)
        {
            Instantiate(skillQ3Tornado, pointSkillToradoQ3.position, Quaternion.identity);
        }
    }
}
