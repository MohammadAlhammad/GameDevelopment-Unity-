using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public float damageAmount = 10f;
    public LayerMask plantLayer;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.layer == plantLayer)
        {
           
            currentHealth -= damageAmount;

           
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        
        gameObject.SetActive(false);
    }
}

                         // Thank you for using MohammadAlhammads‘ program :) //