using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script allows the bullet to be shot in the single direction.
/// </summary>
public class Bullet : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    const float magnitude = 2.5f;
    Timer deathTimer;
    /// <summary>
    /// Support for deathtimer
    /// </summary>
   void Start()
    {
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = 2;
        deathTimer.Run();
    }
    /// <summary>
    /// Checks timer to be finished, then destroys bullet.
    /// </summary>
    void Update()
    {
        if (deathTimer.Finished)
        {
            Destroy(gameObject);
            deathTimer.Duration = 2;
            deathTimer.Run();
        }
    }

    /// <summary>
    /// This is the method that applys a certain force to the bullet.
    /// </summary>
    /// <param name="vector"></param>
    public void ApplyForce(Vector2 vector)
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(vector * magnitude, ForceMode2D.Impulse);
       
    }

}
