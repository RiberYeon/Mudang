using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGenerator : MonoBehaviour
{
    public GameObject NPCPrefab;
    float span = 30.0f;
    float delta = 25.0f;

    void Start()
    {
        
    }

    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta>this.span)
        {
            this.delta = 0;
            GameObject npc = Instantiate(NPCPrefab);
            npc.transform.position = new Vector3(-4, -3.3f, 0);
        }
    }
}
