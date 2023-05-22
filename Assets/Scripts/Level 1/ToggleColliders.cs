using UnityEngine;

public class ToggleColliders : MonoBehaviour
{
    public bool collidersStatus;

    void FixedUpdate()
    {
        ToggleChildrenColliders(collidersStatus);
    }

    void ToggleChildrenColliders(bool enabled)
    {
        foreach (Transform child in transform)
        {
            MeshCollider collider = child.GetComponent<MeshCollider>();
            if (collider != null && !enabled)
            {
                Destroy(collider);
            }
            else if (collider == null && enabled)
            {
                child.gameObject.AddComponent<MeshCollider>();
            }
        }
    }
}
