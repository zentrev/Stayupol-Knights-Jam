using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public bool isAlive = true;

    [SerializeField] CapsuleCollider navigationCollider = null;
    [SerializeField] Collider[] ragdollColliders = null;

    void Start()
    {
        navigationCollider.enabled = true;
        isAlive = true;

        SetKinematic(true);
    }

    void Update()
    {
        if(!isAlive)
        {
            ToggleRagdoll();
        }
    }

    public void ToggleRagdoll()
    {
        // Need to toggle navigationCollider
        navigationCollider.enabled = !navigationCollider.enabled;

        SetKinematic(false);
    }

    public void SetKinematic(bool val)
    {
        foreach (Collider col in ragdollColliders)
        {
            Rigidbody rb;
            col.gameObject.TryGetComponent(out rb);

            if (rb)
            {
                rb.isKinematic = val;
            }
        }
    }
}
