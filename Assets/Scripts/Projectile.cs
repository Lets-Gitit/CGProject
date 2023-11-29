using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static float projectileSpeed;

    public Projectile()
    {
        projectileSpeed = 20f;
    }

    // Update is called once per frame
    private void Update()
    {
        Destroy(gameObject, 2f);
    }
}
