using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// For the HUD/Game timer that is going to be made
/// </summary>
public class HUDScript : MonoBehaviour
{
    [SerializeField]
    Text text;
    
    int textNum = 0;
    float elapsedSeconds = 0;
    bool running = false;
    /// <summary>
    /// Sets timer to zero at the start
    /// </summary>
    void Start()
    {
        text.text = textNum.ToString();
    }

    /// <summary>
    /// Counts the Timer if it is running ( by a second )
    /// </summary>
    void Update()
    {
       
        if (!running)
        {
            elapsedSeconds += Time.deltaTime;
            text.text = ((int)elapsedSeconds).ToString();
        }
       
        }
    /// <summary>
    /// This gets called when the player dies
    /// </summary>
   public void StopGameTimer()
    {
        running = true;
        if (running)
        {
            text.text = textNum.ToString();
        }
    }
    
}
