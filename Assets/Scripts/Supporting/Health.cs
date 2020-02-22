using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] Slider healthbar = null;
    public float healthMax = 1.0f;
    public float healthCount = 0.0f;

    public int objectIndex = 0;

    Animator an = null;

    public void Start()
    {
        an = GetComponent<Animator>();
        healthCount = healthMax;
        if (healthbar)
        {
            healthbar.maxValue = healthMax;
        }
    }

    public void ResetHealth()
    {
        healthCount = healthMax;
    }

    public void DealDamage(float dmg)
    {
        healthCount -= dmg;
        if (an) an.SetTrigger("Damage");
    }

    public void FixedUpdate()
    {

        if (healthbar)
        {
            healthbar.maxValue = healthMax;
            healthbar.value = healthCount;
            healthbar.transform.rotation = Quaternion.identity;
        }

        if (healthCount > healthMax)
        {
            healthCount = healthMax;
        }
    }
}
