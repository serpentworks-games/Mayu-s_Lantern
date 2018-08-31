using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class PlayerController : ActorController {

    //Public
    [HideInInspector]
    public GameObject lanternHoldPoint;
    [HideInInspector] public int localNumOfSouls;
    public static PlayerController instance;

    [BoxGroup]
    public PlayerData localPlayerData = new PlayerData();

    //Private
    GameController gController;
    AreaController lController;
    Animator anim;
    Rigidbody rBody;
    float h;
    float v;
    [HideInInspector]
   public float speedDampTime = 0.1f;
    float turnSmoothing = 15f;
    bool sneak;
    bool playerDead;
    HashIDs hash;
    Light lanternLight;

    float lanternLightHighInt = 4f;
    float lanternLightLowInt = 1f;


    //Constants
    public const string startingPositionKey = "starting position";

    //Readonly


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        anim = GetComponentInChildren<Animator>();
        rBody = GetComponent<Rigidbody>();
        hash = FindObjectOfType<HashIDs>();
        gController = FindObjectOfType<GameController>();
        lController = FindObjectOfType<AreaController>();
        
        lanternLight = lanternHoldPoint.gameObject.GetComponentInChildren<Light>();
        lanternLightHighInt = lanternLight.intensity;
        anim.SetLayerWeight(1, 0f);

    }

    void Start () {

        LoadPlayerData();

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        sneak = Input.GetButton("Sneak");

        Move(h, v, sneak);

    }

    private void Update()
    {
        if (localPlayerData.health == 0)
        {
            if (!playerDead)
            {
                Dying();
            }
            else
            {
                Dead();
                GameController.instance.ResetLevel();
            }
        }
        anim.SetBool(hash.hasLanternBool, localPlayerData.hasLantern);
        lanternHoldPoint.transform.GetChild(0).gameObject.SetActive(localPlayerData.hasLantern);

        SaveLoadDataTest();
    }

    public void Interaction()
    {

    }
    #region LanternPickUpDropCode Not Implimented

    public void PickUpLantern(GameObject lantern)
    {
        lantern.transform.SetParent(lanternHoldPoint.transform);
        lantern.transform.position = lanternHoldPoint.transform.position;
        lantern.transform.rotation = lanternHoldPoint.transform.rotation;
    }

    public void DropLantern(GameObject placementLocation)
    {
        GameObject.Find("Lantern").transform.parent = placementLocation.transform;
        GameObject.Find("Lantern").transform.position = placementLocation.transform.position;
        GameObject.Find("Lantern").transform.rotation = placementLocation.transform.rotation;
    } 
    #endregion
    #region MovementStates

    private void Move(float _h, float _v, bool sneaking)
    {
        if (!playerDead || gController.inputEnabled == false)
        {

            anim.SetBool(hash.sneakingBool, sneaking);
            if (sneaking)
            {
                lanternLight.intensity = Mathf.Lerp(lanternLight.intensity, lanternLightLowInt, Time.deltaTime);
            }
            else
            {
                lanternLight.intensity = Mathf.Lerp(lanternLight.intensity, lanternLightHighInt, Time.deltaTime);
            }

            if (_h != 0f || _v != 0f)
            {
                Rotate(_h, _v);
                anim.SetFloat(hash.speedFloat, 1.2f, speedDampTime, Time.deltaTime);
            }
            else
            {
                anim.SetFloat(hash.speedFloat, 0f, speedDampTime, Time.deltaTime);
            }
        }
    }

    void Rotate(float _h, float _v)
    {
        Vector3 targetDirection = new Vector3(_h, 0, _v);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        Quaternion newRotation = Quaternion.Lerp(rBody.rotation, targetRotation, turnSmoothing * Time.deltaTime);
        rBody.MoveRotation(newRotation);

    }

    void Dying()
    {
        playerDead = true;
        anim.SetBool(hash.deadBool, true);
    }

    void Dead()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).fullPathHash == hash.dyingState)
        {
            anim.SetBool(hash.deadBool, false);
        }

        anim.SetFloat(hash.speedFloat, 0);
        lController.position = lController.resetPosition;

    }

    #endregion


    public void TakeDamage(float damage)
    {
        localPlayerData.health -= damage;
        if (localPlayerData.health >= 0)
        {
            localPlayerData.health = 0;
        }
    }

    public void SavePlayerData()
    {
        GameController.instance.savedPlayerData = localPlayerData;
    }

    void LoadPlayerData()
    {
        if (GameController.instance.isSceneBeingLoaded)
        {

            localPlayerData = GameController.instance.localCopyOfData;
            transform.position = new Vector3(GameController.instance.localCopyOfData.posX, GameController.instance.localCopyOfData.posY, GameController.instance.localCopyOfData.posZ + 0.1f);
            GameController.instance.isSceneBeingLoaded = false;
        }
    }

    void SaveLoadDataTest()
    {
        if (Input.GetKey(KeyCode.F5))
        {
            localPlayerData.SceneID = SceneManager.GetActiveScene().buildIndex;
            localPlayerData.posX = transform.position.x;
            localPlayerData.posY = transform.position.y;
            localPlayerData.posZ = transform.position.z;
            localPlayerData.numberOfSouls = localNumOfSouls;

            GameController.instance.SaveData();
        }

        if (Input.GetKey(KeyCode.F9))
        {
            GameController.instance.LoadData();
            GameController.instance.isSceneBeingLoaded = true;

            int whichScene = GameController.instance.localCopyOfData.SceneID;

            SceneManager.LoadScene(whichScene);
        }
    }
}