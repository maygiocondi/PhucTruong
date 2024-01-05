
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    private void Awake()
    {
 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public virtual void TakeDamage(int damage)
    {
        
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + " died.");
    }
}