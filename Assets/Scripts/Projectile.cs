using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static float projectileSpeed { get; private set; }

    public Projectile()
    {
        projectileSpeed = 10f;
    }


    // Update is called once per frame
    private void Update()
    {
        Destroy(gameObject, 2f);
    }
}
