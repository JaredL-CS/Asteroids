using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class is to spawn the astroids on either the top,bottom, right, or left side of the screen.
/// </summary>
public class AstroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabAstroid;

  /// <summary>
  /// This is spawner control for the astroids.
  /// </summary>
    void Start()
    {
        //Sets the sides of the screens to positions 1-4 so the astroid will spawn there.
        Vector3 position1 = new Vector3(0.0f, ScreenUtils.ScreenBottom, 0.0f);
        Vector3 position2 = new Vector3(0.0f, ScreenUtils.ScreenTop, 0.0f);
        Vector3 position3 = new Vector3(ScreenUtils.ScreenRight, 0.0f, 0.0f);
        Vector3 position4 = new Vector3(ScreenUtils.ScreenLeft, 0.0f, 0.0f);

        //instantiates an astroid at that location and direction using the method call.
        GameObject astroid1 = Instantiate (prefabAstroid) as GameObject;
        astroid1.GetComponent<Asteroid>().Initialize(Direction.Up, position1);
        GameObject astroid2 = Instantiate(prefabAstroid) as GameObject;
        astroid2.GetComponent<Asteroid>().Initialize(Direction.Down, position2);
        GameObject astroid3 = Instantiate(prefabAstroid) as GameObject;
        astroid3.GetComponent<Asteroid>().Initialize(Direction.Left, position3);
        GameObject astroid4 = Instantiate(prefabAstroid) as GameObject;
        astroid4.GetComponent<Asteroid>().Initialize(Direction.Right, position4);

    }

}
