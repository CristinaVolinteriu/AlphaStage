using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_2D : MonoBehaviour {

    List<Rect> SkillButtons = new List<Rect>();
    List<Rect> ItemButtons = new List<Rect>();

    // Variables used to calculate the health and the length of the bar
    public float currentHP = 100;
    public float maxHP = 100;
    public float currentBarLength;
    public float maxBarLength = 100;

    // Level counter
    public int currentLevel = 1;
    public GUIStyle myStyle; // Used to access the properties of a GUI label

    // Creating an experience counter
    public float maxExperience = 100;
    public float currentExperience = 0;
    public float curretExpBarLength;
    public float maxExpBarLength = 100;

	// Use this for initialization
	void Start () {
        SkillButtons.Add(new Rect(Screen.width / 2 + 50, Screen.height / 2 + 333, 55, 55));
        SkillButtons.Add(new Rect(Screen.width / 2 + 105, Screen.height / 2 + 333, 55, 55));
        SkillButtons.Add(new Rect(Screen.width / 2 + 160, Screen.height / 2 + 333, 55, 55));

        ItemButtons.Add(new Rect(Screen.width / 2 - 160, Screen.height / 2 + 333, 55, 55));
        ItemButtons.Add(new Rect(Screen.width / 2 - 105, Screen.height / 2 + 333, 55, 55));
        ItemButtons.Add(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 333, 55, 55));

        myStyle.fontSize = 36;
    }

    private void OnGUI()
    {
        // They draw our button at the location of our rectangles
        GUI.Button(SkillButtons[0], "Skill A");
        GUI.Button(SkillButtons[1], "Skill B");
        GUI.Button(SkillButtons[2], "Skill C");
        GUI.Button(ItemButtons[0], "Item A");
        GUI.Button(ItemButtons[1], "Item B");
        GUI.Button(ItemButtons[2], "Item C");

        // Drawing the health bar
        currentBarLength = currentHP * maxBarLength / maxHP;
        GUI.Box(new Rect(Screen.width / 2 - 20, Screen.height / 2 + 300, currentBarLength, 25f), "");

        // Drawing the level counter
        GUI.Label(new Rect(Screen.width / 2 + 15, Screen.height / 2 + 335, 30, 30), currentLevel.ToString(), myStyle);

        // Drawing an experience counter
        curretExpBarLength = currentExperience * maxExpBarLength / maxExperience;
        if(curretExpBarLength > 5)
        {
            GUI.Button(new Rect(Screen.width / 2 - 20, Screen.height / 2 - 300, curretExpBarLength, 25), "");
        }
        else
        {
            GUI.Button(new Rect(Screen.width / 2 - 20, Screen.height / 2 - 300, maxExperience, 25), "");
        }
        if(curretExpBarLength >= maxExpBarLength)
        {
            curretExpBarLength = 0;
            currentExperience = 0;
            currentLevel++;
        }
    }
}
