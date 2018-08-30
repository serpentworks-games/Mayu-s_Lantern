using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    public Text soulsCountText;
    PlayerController pController;



    private void Update()
    {
        pController = FindObjectOfType<PlayerController>();

    }

    void UpdateSoulCount()
    {
        soulsCountText.text = "Souls: " + pController.localNumOfSouls;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }


}
