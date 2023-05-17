using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public Transform player;
    
    void Update()
    {
        if(player.position.y <= .5)
        {
            player.position = new Vector3( 0f, 1.85f,0f);


        }
    }
}
