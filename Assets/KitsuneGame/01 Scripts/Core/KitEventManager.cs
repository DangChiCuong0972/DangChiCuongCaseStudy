using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("KitScript/KitEventManager")]
public static class KitEventManager 
{
    public static KitGameEvent coinEvent;

    public static KitGameEvent coinUpdateEvent;
}

public class KitGameEvent : UnityEvent<int>
{
   
}
