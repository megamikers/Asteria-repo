using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Boss_Cleared : MonoBehaviour
{  
	[SerializeField]
	public int essence = 10;


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Light"))
		{
			Debug.Log(" llll");

			essence -= 1;
			Debug.Log(essence);

			if (essence == 0)
			{
				Debug.Log(" Simple");
				SceneManager.LoadScene("Asteria MainMenu");
			}
		}
	}




}