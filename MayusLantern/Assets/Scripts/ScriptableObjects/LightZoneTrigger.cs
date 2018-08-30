using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Interactables/LightZoneTrigger")]
public class LightZoneTrigger : TriggerBehavior
{
    public override void Behavior(TriggerZoneBehaviorController controller)
    {
        LightZone(controller);
    }

    void LightZone(TriggerZoneBehaviorController controller)
    {
      controller.player.GetComponent<PlayerController>().localPlayerData.isHidden = true;
     
    }
}
