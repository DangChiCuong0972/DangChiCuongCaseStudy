using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventGameManager 
{
    public static GameEvent coinEvent;
}

public class GameEvent : UnityEvent<int>
{ 

}
