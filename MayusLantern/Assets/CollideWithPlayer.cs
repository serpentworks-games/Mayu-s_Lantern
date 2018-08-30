using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithPlayer : MonoBehaviour {

    public float lifeTime;
    public float damageToDeal;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.tag == "Player")
        {
            Debug.Log("Damaging player!");
            other.gameObject.GetComponent<PlayerController>().TakeDamage(damageToDeal);
            Destroy(this.gameObject);
        } else if (other.collider.gameObject.layer == 11 || other.collider.gameObject.layer == 12)
        {
            Destroy(this.gameObject);
        } else
        {
            Destroy(this.gameObject, lifeTime);
        }
    }
}
