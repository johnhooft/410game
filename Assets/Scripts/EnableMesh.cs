using UnityEngine;

public class EnableMesh : MonoBehaviour
{
    public bool mesh_status;
    void Start()
    {
        // Iterate through all child objects
        foreach (Transform child in transform)
        {
            // Get the Mesh Filter component
            MeshFilter meshFilter = child.GetComponent<MeshFilter>();
            if (meshFilter != null)
            {
                // Get the Mesh Collider component and enable it
                MeshCollider meshCollider = child.GetComponent<MeshCollider>();
                if (meshCollider == null)
                {
                    meshCollider = child.gameObject.AddComponent<MeshCollider>();
                }
                // Set the Mesh Collider to be convex
                meshCollider.convex = true;
                // Assign the mesh to the Mesh Collider
                meshCollider.sharedMesh = meshFilter.sharedMesh;
            }
        }
    }
}
