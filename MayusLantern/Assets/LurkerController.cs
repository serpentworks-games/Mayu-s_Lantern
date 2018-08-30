using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LurkerController : MonoBehaviour {


    DamagePlayer damagePlayer;
    Animator anim;


	// Use this for initialization
	void Start () {
        damagePlayer = GetComponent<DamagePlayer>();
        anim = GetComponentInChildren<Animator>();
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetTrigger("lunge");
            other.GetComponent<PlayerController>().TakeDamage(damagePlayer.damageToDeal);
        }
    }
}
