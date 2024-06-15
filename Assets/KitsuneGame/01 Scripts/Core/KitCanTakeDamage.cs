using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("KitScript/KitCanTakeDamage")]
public interface KitCanTakeDamage 
{
    void TakeDamage(int damge, Vector2 force, GameObject intergor);
}
