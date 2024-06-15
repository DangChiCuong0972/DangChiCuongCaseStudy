using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class KasaUseSkill : MonoBehaviour
{
    public LayerMask enemyLayer;
    //public float nextSkillUse = 0;
    //public float rateSkillUse = 3f;
    [Header("Skill")]
    public float nextSkillUse = 3f;
    public float rateSkillUse = 3f;  
    public float nextTimeSkillQ2 = 6f;
    public float timeToSkillQ2 = 6f;

    public float timeQ3Skill = 1.5f;
    public float baseTimeQ3Skill = 1.5f;
    public float timeUseSkillQ3 = 3f;
    public float baseTimeUseSkillQ3 = 3f;

    public float timeDelaySkill = 0.3f;
    public float timeDelayVfxQ3 = 1f;

    public Transform pointSkillQ;
    public float rangeSkillQ = 0.3f;

    public int addPowerValue = 1;

    private Animator anim;
    private int isSkillQId;
    private int isSkillQ3Id;

    public bool canSkillQ3 = false;
    private bool canUseSkillQ3 = false;
    public bool canUseSkillQ1 = true;


    public float tornado = 1;
    private bool isTornado = false;

    private KasaSkillManager skillManager;
    private KasaSkillQ kasaSkillQ;
    private TornadoSkillQ3 tornadoSkillQ3;

    [Header("Damage")]
    public int damageToGive = 10;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        isSkillQId = Animator.StringToHash("isSkillQ");
        isSkillQ3Id = Animator.StringToHash("isSkillQ3");
        skillManager = FindObjectOfType<KasaSkillManager>();
        kasaSkillQ = FindObjectOfType<KasaSkillQ>();
    }

    [Header("Audio")]
    public AudioClip skillQ1;
    public AudioClip skillQ2;
    public AudioClip TimeUseskillQ301;
    public AudioClip TimeUseskillQ302;
    public AudioClip TimeUseskillQ303;
    public AudioClip skillQ3;
    public AudioClip skillQ3Bullet;
    public float audioDelaySkillQ1 = 0.3f;
    public float audioDelayTornadoQ3 = 0.4f;
    
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q) && canUseSkillQ1 && skillManager.powerQ <=1)
        {
            StartCoroutine(AudioSkillQ1(audioDelaySkillQ1));
          
            canUseSkillQ1 = false;
            GetSkillQ();
        }
        //if (skillManager.powerQ == 2)
        //{
        //    KasaAudioManager.Instance.SetSkillQ2Source(skillQ2);
        //    StartCoroutine(AudioSfxTornadoQ3(audioDelayTornadoQ3));
        //}

        if (!canUseSkillQ1)
            {
                TimeSkillQ1();
            }

           NextTimeSkillQ2();


        if(Input.GetKeyDown(KeyCode.Q) && skillManager.powerQ == 1)
        {
            //KasaAudioManager.Instance.SetSfxScource(skillQ2);
            //StartCoroutine(AudioSfxTornadoQ3(audioDelayTornadoQ3));
        }

        if (!canSkillQ3 && skillManager.powerQ == 2)
        {
           
           // KasaAudioManager.Instance.SetSfxScource(skillQ2);
            //KasaAudioManager.Instance.SetSfxScource(TimeUseskillQ302);
            //KasaAudioManager.Instance.SetSfxScource(TimeUseskillQ303);

            //StartCoroutine(AudioSfxTornadoQ3(audioDelayTornadoQ3));
            if(!isTornado)
            {
                tornado -= 0.9f;

            }
            if (tornado <= 0)
            {
                isTornado = true;
                kasaSkillQ.SkillTornadoQ3();
                tornado = 1;
            }
            

            timeQ3Skill -= Time.deltaTime;
                if (timeQ3Skill <= 0)
                {
                    timeQ3Skill = baseTimeQ3Skill;
                    //kasaSkillQ.SkillTornadoQ3();  
                    canSkillQ3 = true;
                }
           
           

        }
        else if (canSkillQ3 == true)
        {

            timeUseSkillQ3 -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Q))
            {
                KasaAudioManager.Instance.SetBulletQ3(skillQ3Bullet);
                KasaAudioManager.Instance.SetVolumeBullet(0.8f);
                KasaAudioManager.Instance.SetSfxScource(skillQ3);
                anim.SetTrigger(isSkillQ3Id);
                //kasaSkillQ.SkillQ3();
                StartCoroutine(TimeVfxSkillQ3(timeDelayVfxQ3));
                skillManager.powerQ = 0;
                tornado = 1;
                isTornado = false;
                timeUseSkillQ3 = baseTimeUseSkillQ3;
                canSkillQ3 = false;
            }
            else
            {    
                if (timeUseSkillQ3 <= 0)
                {
                    //KasaAudioManager.Instance.SetSfxVolume(0);
                    timeUseSkillQ3 = baseTimeUseSkillQ3;
                    skillManager.powerQ = 0;
                    canSkillQ3 = false;
                }
            }
        }


        
    }


    public void GetSkillQ()
    {

        //if (Time.time > nextSkillUse && skillManager.powerQ <= 1)
        //{
        //    anim.SetTrigger(isSkillQId);
        //    nextSkillUse = Time.time + rateSkillUse;

        //    StartCoroutine(SkillQUse(timeDelaySkill));
        //}

       
        if ( skillManager.powerQ <= 1)
        {
            anim.SetTrigger(isSkillQId);

            StartCoroutine(SkillQUse(timeDelaySkill));
        }


    }

    void TimeSkillQ1()
    {
        nextSkillUse -= Time.deltaTime;
        if (nextSkillUse <= 0 || skillManager.powerQ == 2 )
        {
            nextSkillUse = rateSkillUse;
            canUseSkillQ1 = true;
        }

    }

    void NextTimeSkillQ2()
    {
        if (skillManager.powerQ == 1) 
        {
            nextTimeSkillQ2 -= Time.deltaTime;
            if (nextTimeSkillQ2 <= 0 )
            {
                nextTimeSkillQ2 = timeToSkillQ2;
                skillManager.powerQ = 0;
            }
        }
        else if (skillManager.powerQ == 2)
        {
            nextTimeSkillQ2 = timeToSkillQ2;
        }

        //else
        //{ 
        //    nextTimeSkillQ2 = timeToSkillQ2;
        //}
    }

    IEnumerator TimeVfxSkillQ3(float delay)
    {
        yield return new WaitForSeconds(delay);
        kasaSkillQ.SkillQ3();
       
    }

    IEnumerator SkillQUse(float delay)
    {
        yield return new WaitForSeconds(delay);

       
        Collider2D[] hitSkill = Physics2D.OverlapCircleAll(pointSkillQ.position, rangeSkillQ, enemyLayer);


        foreach(var enemy in hitSkill)
        {
            if (enemy != null)
            {
                if(KasaSkillManager.Instan.powerQ == 1)
                {
                    KasaAudioManager.Instance.SetSkillQ2Source(skillQ2);
                    StartCoroutine(AudioSfxTornadoQ3(audioDelayTornadoQ3));
                }
                enemy.GetComponent<KasaCanTakeDamage>().TakeDamage(damageToGive, gameObject);
                skillManager.SetPower(addPowerValue);
                
                //KasaAudioManager.Instance.SetSfxVolume(0.87f);
            }
        }
    }


    IEnumerator AudioSkillQ1(float delay)
    {
        yield return new WaitForSeconds(delay);
        KasaAudioManager.Instance.SetSfxScource(skillQ1);
    }

    // IEnumerator Audio 
    IEnumerator AudioSfxTornadoQ3(float delay)
    {
        yield return new WaitForSeconds(delay);
        KasaAudioManager.Instance.SetSfxScource(TimeUseskillQ301);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        if(pointSkillQ != null)
        {
            Gizmos.DrawWireSphere(pointSkillQ.position, rangeSkillQ);
        }
    }
}
