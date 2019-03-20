using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticle : MonoBehaviour {
    private bool destroyed = false;
    Renderer rend;
    public Shader burnAway;
    private float burnTime = 0;
    private void Start()
    {
        rend = GetComponent<Renderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (destroyed)
        {
            rend.material.SetFloat("_SliceAmount",burnTime);
            burnTime += Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject.GetComponent<MeshCollider>());
            rend.material.shader = burnAway;
            Destroy(other.gameObject);
            //Destroy(gameObject, .5f);
            destroyed = true;

        }
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }


}
