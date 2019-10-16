using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Drag in the MainMagic and MagicFire Base from the Component Inspector.
    public GameObject MainMagicBase;
    public GameObject MagicFireBase;

    //Drag in the MainMagic and MagicFire from the Component Inspector.
    public GameObject MainMagic;
    public GameObject MagicFire;

    //Enter the Speed of MainMagic and MagicFire from the Component Inspector.
    public float MainMagic_Forward_Force;
    public float Magic_Forward_Force;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            //The MainMagic instantiation happens here.
            GameObject Temporary_MainMagic_Handler;
            Temporary_MainMagic_Handler = Instantiate(MainMagic, MainMagicBase.transform.position, MainMagicBase.transform.rotation) as GameObject;

            //MainMagic Prefab Rotation
            Temporary_MainMagic_Handler.transform.Rotate(Vector3.left * 25);

            //Retrieve the Rigidbody component from the instantiated MainMagic and control it.
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_MainMagic_Handler.GetComponent<Rigidbody>();

            //Tell the MainMagic to be "pushed" forward by an amount set by MainMagic_Forward_Force.
            Temporary_RigidBody.AddForce(transform.forward * MainMagic_Forward_Force);

            //Basic Clean Up, set the MainMagic to self destruct after 3 seconds
            Destroy(Temporary_MainMagic_Handler, 3.0f);
        }
        if (Input.GetKeyDown("2"))
        {
            //The MagicFire instantiation happens here.
            GameObject Temporary_Magic_Handler;
            Temporary_Magic_Handler = Instantiate(MagicFire, MagicFireBase.transform.position, MagicFireBase.transform.rotation) as GameObject;

            //Sometimes the MagicFire may appear rotated incorrectly 
            //This is EASILY corrected here, might have to rotate it from a different axis and or angle based on your particular mesh.
            Temporary_Magic_Handler.transform.Rotate(Vector3.left * 75);

            //Retrieve the Rigidbody component from the instantiated MagicFire and control it.
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Magic_Handler.GetComponent<Rigidbody>();

            //Tell the MagicFire to be "pushed" forward by an amount set by Magic_Forward_Force.
            Temporary_RigidBody.AddForce(transform.forward * Magic_Forward_Force);

            //Basic Clean Up, set the MagicFire to self destruct after 3 seconds
            Destroy(Temporary_Magic_Handler, 3.0f);
        }

    }
}