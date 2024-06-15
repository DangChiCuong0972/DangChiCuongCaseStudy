using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KasaUISkillManager : MonoBehaviour
{
    public Image timeSkillQ1;
    public Image timeToSkill02;
    public Image timeSkillQ2;
    public Image timeCanSkillQ3;
    public Image timeEndSkillQ3;

    public GameObject skillQ01;
    public GameObject timeToSkillQ02;
    public GameObject skillQ02;

    public GameObject canSkillQ3;
    public GameObject endSkillQ3;

    public float timeCoolDown1 = 3;
    public float timeCoolDown2 = 6;
    public float timeCoolDown3 = 3;
    public float timeEndCoolDown3 = 7f;

   

    private bool isCoolDownQ1 = false;
    private bool isCoolDownQ2 = false;
    private bool isCoolDownQ3 = false;
    private bool isCoolDownEndQ3 = false;

    private KasaUseSkill kasaUseSkill;
    // Start is called before the first frame update
    void Start()
    {
        
        timeSkillQ1.fillAmount = 0;
        timeSkillQ2.fillAmount = 0;
        timeCanSkillQ3.fillAmount = 0;
        timeEndSkillQ3.fillAmount = 0;
        kasaUseSkill = FindObjectOfType<KasaUseSkill>();
        timeToSkillQ02.SetActive(false);
        skillQ02.SetActive(false);
        canSkillQ3.SetActive(false);
        endSkillQ3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        AbilityQ1();
       
        AbilityToQ2();

        AbilityQ3();

        EndAbilityQ3();
    }

    void AbilityQ1()
    {

      
        if (!isCoolDownQ1)
        {
            isCoolDownQ1 = true;
            timeSkillQ1.fillAmount = 1;
        }

        if(isCoolDownQ1)
        {
            if (!kasaUseSkill.canUseSkillQ1)
            {
                timeSkillQ1.fillAmount -= 1 / timeCoolDown1 * Time.deltaTime;

            }
            else if (kasaUseSkill.canUseSkillQ1)
            {
                timeSkillQ1.fillAmount = 0;
                isCoolDownQ1 = false;
            }

        }

    }

    void AbilityToQ2()
    {
        bool isSKillToQ2 = false;
        if(KasaSkillManager.Instan.powerQ == 1)
        {
            timeToSkillQ02.SetActive(true);
            skillQ02.SetActive(true);
        }

        if(!isCoolDownQ2 && KasaSkillManager.Instan.powerQ == 1)
        {

            isCoolDownQ2 = true;
            timeToSkill02.fillAmount = 1;
            timeSkillQ2.fillAmount = 1;
        }
        if(isCoolDownQ2 )
        {        
                timeToSkill02.fillAmount -= 1 / timeCoolDown2 * Time.deltaTime;
                timeSkillQ2.fillAmount -= 1 / (timeCoolDown2 + 1f) * Time.deltaTime;

                if(timeToSkill02.fillAmount <= 0 || KasaSkillManager.Instan.powerQ == 2)
              {
                timeToSkill02.fillAmount = 0;
                isCoolDownQ2 = false;
                timeToSkillQ02.SetActive(false);
                skillQ02.SetActive(false);
                
              }

                if(timeSkillQ2.fillAmount <= 0.55f)
              {

                timeSkillQ2.fillAmount = 0;
              }

        }

    }

    void AbilityQ3()
    {
        if(KasaSkillManager.Instan.powerQ == 2)
        {
            canSkillQ3.SetActive(true);
            
        }
        if (KasaSkillManager.Instan.powerQ == 0)
        {
            canSkillQ3.SetActive(false);
            isCoolDownQ3 = false;
        }

        if (!isCoolDownQ3 && KasaSkillManager.Instan.powerQ == 2 )
        {
            isCoolDownQ3 = true;
            timeCanSkillQ3.fillAmount = 1;
        }

        if(isCoolDownQ3)
        {
            timeCanSkillQ3.fillAmount -= 1 / timeCoolDown3 * Time.deltaTime;

            if(timeCanSkillQ3.fillAmount <= 0 )
            {
                timeCanSkillQ3.fillAmount = 0;    
              
            }
        }
     

    }

    void EndAbilityQ3()
    {
        if (KasaSkillManager.Instan.powerQ == 2)
        {
            endSkillQ3.SetActive(true);
        }

        if (KasaSkillManager.Instan.powerQ == 0)
        {
            endSkillQ3.SetActive(false);
        }
        if (!isCoolDownEndQ3 && KasaSkillManager.Instan.powerQ == 2)
        {
            isCoolDownEndQ3 = true;
            timeEndSkillQ3.fillAmount = 1;
        }

        if(isCoolDownEndQ3)
        {
            timeEndSkillQ3.fillAmount -= 1/timeEndCoolDown3 * Time.deltaTime;

            if(timeEndSkillQ3.fillAmount <= 0)
            {
                    timeEndSkillQ3.fillAmount = 0;             
                    isCoolDownEndQ3 = false;
                   endSkillQ3.SetActive(false);
               
            }
        }
    }

}
