using UnityEngine;

public abstract class TriggerBehavior : ScriptableObject
{ 
    public abstract void Behavior(TriggerZoneBehaviorController controller);

}