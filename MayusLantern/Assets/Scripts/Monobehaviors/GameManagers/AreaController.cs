using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Last Known Player Sighting
    public Vector3 position = new Vector3(1000f, 1000f, 1000f);
    public Vector3 resetPosition = new Vector3(1000f, 1000f, 1000f);

    private bool alarmOn;

    void Update()
    {
        SwitchAlarms();
    }

    void SwitchAlarms()
    {
        alarmOn = (position != resetPosition);

        if (position != resetPosition)
        {
            Debug.Log("WEEE OOO WWEEE OOO YOUVE BEEN SPOTTED");
        } else if(position == resetPosition)
        {
            return;
        }
     }

}
