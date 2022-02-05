using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public ParticleSystem dust;
    public int levelPercentage;
    public float level = 4;

    private int remainingJumps = 2;

    private float jumpForce = 250;     //define how strong the jump should be, e.g. how high the player flies

    private AudioManager _audioManager;

    void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();

        levelPercentage = 0;
    }


    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Mouse0) && remainingJumps > 0)       //make rigidbody jump when space-button is pressed but only 2 consecutive times
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(15, jumpForce, 0), ForceMode.Impulse);
            remainingJumps -= 1;
            levelPercentage += 1;            //count number of jumps so far
            Debug.Log(levelPercentage);
            dust.Play();
        }


        if(levelPercentage >= level*10)      //increase speed of everything if certain number of jumps is reached
        {
            level += 1;         
            levelPercentage = 0;
        }

        if (transform.position.y <= -5)        //restart scene if player falls down
        {
            //_audioManager.GameOverSound();
            SceneManager.LoadScene("GameOver");
        }
    }    

    private void OnCollisionEnter(Collision collision)     //reset number of jumps possible if player hits floor again
    {
        remainingJumps = 2;
    }

    public void OnCollisionEnter(Collider other)     //destroy rock if it hits a set of stairs
    {
        if (other.tag == "Rock")       //destroy rock if it hits a stair or falls out of bounds + trigger GameOver when the player is out of bounds
        {
            Destroy(gameObject);
            _audioManager.GameOverSound();
            SceneManager.LoadScene("GameOver");
        }
    }
    void CreateDust()
    {
        dust.Play();
    }

}
