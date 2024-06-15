using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[AddComponentMenu("LightScript/LightCanTakeDamage")]
public interface LightCanTakeDamage 
{
    void TakeDamage(int damage, Vector2 force, GameObject interger);

}
