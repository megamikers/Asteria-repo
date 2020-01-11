using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

// Implementing Namespace Knighten
namespace Knighten
{
    // This class Changes the Scenes once all essence(Collectables) are collected.
    public class Change_Scenes : MonoBehaviour
    {
        // Member Variables
        [SerializeField] private string nextScene;
        public int essence = 3;

        // Upon collision with a collectable, that collectable
        // is deducted from the (essence) variable.
        void OnTriggerEnter(Collider other)
        {
            // If the other objects's tag is Collectables
            // execute the following code.
            if (other.gameObject.CompareTag("Collectables"))
            {
                // Deduct 1 essence from the starting amount.
                essence -= 1;

                // Show the remaining number of essence in the console.
                Debug.Log(essence);

                // If all 3 collectables are found
                // change the scene to the giving scene name.
                if (essence == 0)
                {
                    SceneManager.LoadScene(nextScene);
                }
            }
        }

        /*
         * Main Menu Ideas    
         *    
         * var sceneName : string = "MainMenu";
     var sceneIndex : int = 0;
     Application.LoadLevel(sceneName); // Load level by name
     Application.LoadLevel(sceneIndex); // Load level by index number   
         */


    }
} 