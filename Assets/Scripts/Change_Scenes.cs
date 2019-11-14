using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Change_Scenes : MonoBehaviour
{  
    [SerializeField]
    public int essence = 3;
     

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectables"))
        {
            Debug.Log(" llll");
            
            essence -= 1;
            Debug.Log(essence);

            if (essence == 0)
            {
                Debug.Log(" Simple");
                SceneManager.LoadScene("Asteria Boss Scene");
            }
        }
    }




}
