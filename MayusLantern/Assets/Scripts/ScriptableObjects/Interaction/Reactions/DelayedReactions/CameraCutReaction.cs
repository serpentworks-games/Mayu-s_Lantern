using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCutReaction : DelayedReaction
{
    public GameObject cutsceneCamera;
    public bool toggleCutsceneCamera;
    GameController gController;

    private void Awake()
    {
        gController = FindObjectOfType<GameController>();
    }

    protected override void ImmediateReaction()
    {
        SetCameraTarget();
        gController.inputEnabled = toggleCutsceneCamera;
    }

    void SetCameraTarget()
    {
        cutsceneCamera.SetActive(toggleCutsceneCamera);

    }
}
