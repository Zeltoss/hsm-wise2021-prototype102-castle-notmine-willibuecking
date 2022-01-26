using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockLauncher : MonoBehaviour
{
    public GameObject Rock;
    
    private bool rockLaunched = false;      //flag to check of a rock is already being launched
    private bool rockLaunchedPlayer = false;

    private float levelNumber;

    private float playerX;      //variables for players position on x and z axis
    private float playerZ;

    // private Vector3 playerRockPosition;     //variable for rocklaunch-position over players head


    void Update()
    {
        playerX  = GameObject.Find("Player").transform.position.x + 4;              //find player position to launch rocks slightly in front of them
        playerZ  = GameObject.Find("Player").transform.position.z;

        levelNumber = GameObject.Find("Player").GetComponent<PlayerController>().level;
        
        if(!rockLaunched)
        {
            StartCoroutine("RockTimer");        //start the rocklauncher
            rockLaunched = true;
        }

        if(!rockLaunchedPlayer)
        {
            rockLaunchedPlayer = true;
        }
    }

    public IEnumerator RockTimer()
    {
        float timeToLaunch = Random.Range((1f/levelNumber)*3, (1f/levelNumber)*6);      //wait for a random amount of seconds between values derived from the current level
        yield return new WaitForSeconds(timeToLaunch);
        Instantiate(Rock, transform.position, transform.rotation);      //launch a rock
        rockLaunched = false;                                           //reset rocklaunch-flag
    }

}
