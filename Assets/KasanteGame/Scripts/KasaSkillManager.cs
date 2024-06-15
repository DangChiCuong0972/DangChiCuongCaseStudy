using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KasaSkillManager : MonoBehaviour
{
    public static KasaSkillManager Instan;

    public int powerQ = 0;
    // Start is called before the first frame update
    void Start()
    {
        Instan = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPower(int addPower)
    {
        powerQ+= addPower;
    }

    public int GetPowerQ()
    {
        return powerQ;
    }
}
