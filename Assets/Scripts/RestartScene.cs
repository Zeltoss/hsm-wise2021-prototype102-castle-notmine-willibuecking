using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
 
public class RestartScene : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown("r")) {            // Reloads the Scene after pressing "R"
            Restart();
        }
    }
 
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}