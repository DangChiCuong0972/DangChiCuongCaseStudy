using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyScript/MyCanTakeDamage")]
public interface MyCanTakeDamage
{
    void TakeDamage(int damage,Vector2 force,GameObject instigattor);
   
}
