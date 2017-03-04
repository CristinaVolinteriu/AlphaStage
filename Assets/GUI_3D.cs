using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_3D : MonoBehaviour {

    // Creating a 3D Health bar
    public float currentHealth = 100;
    public float maximumHealth = 100;
    float currentBarLength;
    public Transform HealthBar; // Used to interact with our 3D object that's being used as a health bar;
    Vector3 OrigScale; // Used for scaling

    // Creating 3D damage reports
    public TextMesh DamageReport; // A Text Mesh generates 3D geometry that display text string. Ref: https://docs.unity3d.com/Manual/class-TextMesh.html
    public float Damage = 5; // This variable will be shown in the TextMesh
    Color txtColor; // Used to modify the alpha value of the TextMesh 
                    // This will allow us to turn on/off the TextMesh object withough having to instanstiate it
            // Next 3 are used for creating a timer to pick when we want to show or hide the damage report
    public float SpawnTime = 2; // Used to spawn the damage report
    public float KillTime = 3; // Used to hide the damage report
    public float PreviousTime = 0; // Used to mark the previous time we showed the damage report
    bool HasChanged = false; // Checks if we received damage or not

	// Use this for initialization
	void Start () {
        OrigScale = HealthBar.transform.localScale;

        txtColor = DamageReport.color; // Is used to show or hide the damage report
        txtColor.a = 0; // Is being set to 0 so the player can only see it when damage is done
	}
	
	// Update is called once per frame
	void Update () {
        currentBarLength = currentHealth / maximumHealth;
        HealthBar.transform.LookAt(Camera.main.transform); // Our Health Bar quad will look at our camera, thus we will always see it in 3D

        // This is used for testing
        // Everytime you press left mouse button the HP bar will drop
        /*
        if(Input.GetKey("Fire1"))
        {
            currentHealth -= 1.00f;
            ChangeBar();
        }
        */

        DamageReport.color = txtColor;
        if(Time.time > (SpawnTime + PreviousTime))
        {
            DamageReport.text = Damage.ToString();
            txtColor.a = 1;
            if(!HasChanged)
            {
                currentHealth -= Damage;
                ChangeBar();
            }
        }
        if(Time.time > (KillTime + PreviousTime))
        {
            DamageReport.text = " ";

            txtColor.a = 0;
            PreviousTime = Time.time;
            HasChanged = true;
        }
	}

    // Vector3.Lerp reference
    // https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html
    void ChangeBar()
    {
        HealthBar.transform.localScale = Vector3.Lerp(OrigScale, new Vector3(currentBarLength, OrigScale.y, OrigScale.z), Time.time);
    }
}
