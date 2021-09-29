using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This is a comment letting me know what this script does(it lets us drive the ship"
public class Ship : MonoBehaviour
{
    //These are some variables that are needed to be available/accessable throughout the whole class. Global.
    public Rigidbody2D rigid;
    public CircleCollider2D circle;
    [SerializeField]
    GameObject prefabBullet;
    [SerializeField]
    GameObject prefabHUD;

    //controls how fast/how much force is applied every spacebar press
    const float ThrustForce = 10f;
    
    //This controls how fast we can rotate the ship
    const float RotateDegreesPerSecond = 115;
    Vector2 thrustDirection = new Vector2(1, 0);
    
    /// <summary>
    /// Rigidbody control. Start is called before the first frame update
    /// </summary>
 
    void Start()
    {
        //This sets 'rigid' to be able to be called throughout the program
        rigid = GetComponent<Rigidbody2D>();

    }
    /// <summary>
    /// This is movement control. Allows ship to rotate and shoot bullets in a single direction.
    /// </summary>
    void Update()
    {
        float rotationInput = Input.GetAxis("Rotate");
        if (rotationInput != 0)
        {

            // calculate rotation amount and apply rotation
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0)
            {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);

            // change thrust direction to match ship rotation
            float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(zRotation);
            thrustDirection.y = Mathf.Sin(zRotation);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameObject bullet = Instantiate(prefabBullet) as GameObject;
            bullet.transform.position = transform.position;
           
            bullet.GetComponent<Bullet>().ApplyForce(thrustDirection);
            AudioManager.Play(AudioClipName.PlayerShot);
        }
    }/// <summary>
    /// This is the FixedUpdate method, it basically handles fast movement better(more calls per frame to get more precise movement)
    /// </summary>
  
    void FixedUpdate()
    {
        // thrust as appropriate
        if (Input.GetAxis("Thrust") != 0)
        {
            rigid.AddForce(ThrustForce * thrustDirection,
                ForceMode2D.Force);
        }
    }
 
    /// <summary>
    /// This method is what makes the ship disappear when hitting an astroid
    /// </summary>
    /// <param name="coll"></param>
    void OnCollisionEnter2D(Collision2D coll)
    {
       
        //blow up when hitting asteroid
        if ( coll.gameObject.tag == "Asteroid")
        {
            
           prefabHUD.GetComponent<HUDScript>().StopGameTimer();

            // Call audio for player death
            AudioManager.Play(AudioClipName.PlayerDeath);
            Destroy(gameObject);
        }
    }

}
