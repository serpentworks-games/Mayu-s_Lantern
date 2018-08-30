using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public float damageToDeal;
    PlayerController player;
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void ApplyDamage()
    {
        player.TakeDamage(damageToDeal);
        Debug.Log("Damaging player!");
    }
}
