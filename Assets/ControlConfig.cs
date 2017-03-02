using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControlProfile
{
    PC,
    Controller
};

public class ControlConfig : MonoBehaviour {

	bool isControllerConnected = false; // Checks whether a controller is or not connected
	public string Controller = ""; // Saves the name of the Controller

    public ControlProfile cProfile;

    public string PC_Move, PC_Rotate, PC_Item1, PC_Item2, PC_Item3, PC_Item4, PC_Inv, PC_Pause, PC_AttackUse, PC_Aim;
    public string Xbox_Move, Xbox_Rotate, Xbox_Item1, Xbox_Item2, Xbox_Item3, Xbox_Item4, Xbox_Inv, Xbox_Pause, Xbox_AttackUse, Xbox_Aim;

    // One way to customize our controls is by using Control Schemes
    // Where "CS" appears it means it's based on this method
    // KeyCode is an enum, it maps directly to a physical key on the keyboard
    string ControlScheme; //CS
    public KeyCode pcItem1, pcItem2, pcItem3, pcItem4, pcInv, pcPause, pcAttackUse, pcAim, xInv, xPause; //CS

    // Another way is to let the player click on one of the GUI buttons and pick another control to switch it
    // Most likely this will be the one we will use
    // I shall note it with "CC" from Cycling Control
    private KeyCode orig_pcItem1, orig_pcItem2, orig_pcItem3, orig_pcItem4, orig_pcInv, orig_pcPause, orig_xInv, orig_xPause;
    bool ShowPopup = false;
    KeyCode PreviousKey;


    void SetDefaultValues()
    {
        /*
         * They are set in a function because we might use this function later 
         * if we want to press a "Return to default" button for controlls;
         */
        ControlScheme = "Scheme A"; //CS
        if(!isControllerConnected)
        {
            PC_Move = "WASD";
            PC_Rotate = "Mouse";
            PC_Item1 = "1";
            PC_Item2 = "2";
            PC_Item3 = "3";
            PC_Item4 = "4";
            PC_Inv = "I";
            PC_Pause = "Escape";
            PC_AttackUse = "Left Mouse Button";
            PC_Aim = "Right Mouse Button";

            //CS:
            pcItem1 = KeyCode.Alpha1;
            pcItem2 = KeyCode.Alpha2;
            pcItem3 = KeyCode.Alpha3;
            pcItem4 = KeyCode.Alpha4;
            pcInv = KeyCode.I;
            pcPause = KeyCode.Escape;
            pcAttackUse = KeyCode.Mouse0;
            pcAim = KeyCode.Mouse1;

            //CC:
            orig_pcItem1 = pcItem1;
            orig_pcItem2 = pcItem2;
            orig_pcItem3 = pcItem3;
            orig_pcItem4 = pcItem4;
            orig_pcInv = pcInv;
            orig_pcPause = pcPause;
        }
        else
        {
            PC_Move = "WASD";
            PC_Rotate = "Mouse";
            PC_Item1 = "1";
            PC_Item2 = "2";
            PC_Item3 = "3";
            PC_Item4 = "4";
            PC_Inv = "I";
            PC_Pause = "Escape";
            PC_AttackUse = "Left Mouse Button";
            PC_Aim = "Right Mouse Button";

            Xbox_Move = "Left Thumbstick";
            Xbox_Rotate = "Right Thumbstick";
            Xbox_Item1 = "D-Pad Up";
            Xbox_Item2 = "D-Pad Down";
            Xbox_Item3 = "D-Pad Left";
            Xbox_Item4 = "D-Pad Right";
            Xbox_Inv = "A Button";
            Xbox_Pause = "Start Button";
            Xbox_AttackUse = "Right Trigger";
            Xbox_Aim = "Left Triger";

            //CS:
            pcItem1 = KeyCode.Alpha1;
            pcItem2 = KeyCode.Alpha2;
            pcItem3 = KeyCode.Alpha3;
            pcItem4 = KeyCode.Alpha4;
            pcInv = KeyCode.I;
            pcPause = KeyCode.Escape;
            pcAttackUse = KeyCode.Mouse0;
            pcAim = KeyCode.Mouse1;

            //CC:
            orig_pcItem1 = pcItem1; // KeyCode.Alpha1;
            orig_pcItem2 = pcItem2;
            orig_pcItem3 = pcItem3;
            orig_pcItem4 = pcItem4;
            orig_pcInv = pcInv;
            orig_pcPause = pcPause;
            orig_xInv = xInv;
            orig_xPause = xPause;
        }
    }

    /// <summary>
    /// A function that we will call to switch our keys
    /// CC
    /// </summary>
    void SetNewKey(KeyCode KeyToSet, KeyCode SetTo)
    {
        switch(KeyToSet)
        {
            case KeyCode.Alpha1:
                pcItem1 = SetTo;
                PC_Item1 = SetString(pcItem1.ToString());
                break;
            case KeyCode.Alpha2:
                pcItem2 = SetTo;
                PC_Item2 = SetString(pcItem2.ToString());
                break;
            case KeyCode.Alpha3:
                pcItem3 = SetTo;
                PC_Item3 = SetString(pcItem3.ToString());
                break;
            case KeyCode.Alpha4:
                pcItem4 = SetTo;
                PC_Item4 = SetString(pcItem4.ToString());
                break;
            case KeyCode.I:
                pcInv = SetTo;
                PC_Inv = SetString(pcInv.ToString());
                break;
            case KeyCode.Escape:
                pcPause = SetTo;
                PC_Pause = SetString(pcPause.ToString());
                break;
            case KeyCode.Joystick1Button1:
                xInv = SetTo;
                Xbox_Inv = SetString(xInv.ToString());
                break;
            case KeyCode.Joystick1Button6:
                xPause = SetTo;
                Xbox_Pause = SetString(xPause.ToString());
                break;
        }
    }

    // Used to set our control names in the GUI
    // CC
    string SetString(string SetTo)
    {
        switch(SetTo)
        {
            case "Alpha1":
                SetTo = "1";
                break;
            case "Alpha2":
                SetTo = "2";
                break;
            case "Alpha3":
                SetTo = "3";
                break;
            case "Alpha4":
                SetTo = "4";
                break;
            case "Return":
                SetTo = "Enter";
                break;
            case "Escape":
                SetTo = "Escape";
                break;
            case "I":
                SetTo = "I";
                break;
            case "JoystickButton6":
                SetTo = "Start Button";
                break;
            case "JoystickButton1":
                SetTo = "A Button";
                break;
        }
        return SetTo;
    }

    // CS
    void SwitchControlScheme(string Scheme)
    {
        switch(Scheme)
        {
            case "A":
                SetDefaultValues();
                break;

            case "B":
                if (!isControllerConnected)
                {
                    PC_Move = "WASD";
                    PC_Rotate = "Mouse";
                    PC_Item1 = "Numpad 1";
                    PC_Item2 = "Numpad 2";
                    PC_Item3 = "Numpad 3";
                    PC_Item4 = "Numpad 4";
                    PC_Inv = "Numpad +";
                    PC_Pause = "Enter";
                    PC_AttackUse = "Left Mouse Button";
                    PC_Aim = "Right Mouse Button";

                    pcItem1 = KeyCode.Keypad1;
                    pcItem2 = KeyCode.Keypad2;
                    pcItem3 = KeyCode.Keypad3;
                    pcItem4 = KeyCode.Keypad4;
                    pcInv = KeyCode.KeypadPlus;
                    pcPause = KeyCode.Return;
                    pcAttackUse = KeyCode.Mouse1;
                    pcAim = KeyCode.Mouse0;
                }
                else
                {
                    PC_Move = "WASD";
                    PC_Rotate = "Mouse";
                    PC_Item1 = "Numpad 1";
                    PC_Item2 = "Numpad 2";
                    PC_Item3 = "Numpad 3";
                    PC_Item4 = "Numpad 4";
                    PC_Inv = "Numpad +";
                    PC_Pause = "Enter";
                    PC_AttackUse = "Left Mouse Button";
                    PC_Aim = "Right Mouse Button";

                    Xbox_Move = "Left Thumbstick";
                    Xbox_Rotate = "Right Thumbstick";
                    Xbox_Item1 = "D-Pad Up";
                    Xbox_Item2 = "D-Pad Down";
                    Xbox_Item3 = "D-Pad Left";
                    Xbox_Item4 = "D-Pad Right";
                    Xbox_Inv = "B Button";
                    Xbox_Pause = "Back Button";
                    Xbox_AttackUse = "Right Trigger";
                    Xbox_Aim = "Left Triger";

                    pcItem1 = KeyCode.Keypad1;
                    pcItem2 = KeyCode.Keypad2;
                    pcItem3 = KeyCode.Keypad3;
                    pcItem4 = KeyCode.Keypad4;
                    pcInv = KeyCode.KeypadPlus;
                    pcPause = KeyCode.Return;
                    pcAttackUse = KeyCode.Mouse1;
                    pcAim = KeyCode.Mouse0;
                    xInv = KeyCode.Joystick1Button1;
                    xPause = KeyCode.Joystick1Button6;
                }
                break;
        }
    }

    void DetectController()
	{
        /*
         * GetJoystickNames returns an array of strings, which consists of the names of the connected gamepads
         * It needs a try-catch clause because if there is no gamepad connected it will give an IndexOutOfRangeException
         */
        
		try
		{
			if(Input.GetJoystickNames()[0] != null)
			{
				isControllerConnected = true;
                cProfile = ControlProfile.Controller;
				IdentifyController();
			}
            else
            {
                cProfile = ControlProfile.PC;
            }
		}
		catch 
		{
			isControllerConnected = false;
		}
	}

    void IdentifyController()
    {
        Controller = Input.GetJoystickNames()[0];    
    }

    void SwitchProfile(ControlProfile Switcher)
    {
        cProfile = Switcher;
    }

    // The user can reset the controls to their default values
    void Reset()
    {
        SetDefaultValues();
        ShowPopup = false;
        PreviousKey = KeyCode.None;
    }

    /// <summary>
    /// We use labels to show what actions the player can do
    /// and buttons to show what inputs the actions are mapped to.
    /// </summary>
    private void OnGUI()
    {
        /*
         * Shows each action and their controls for a PC and Xbox 360 controller
         * BeginGroup creates well... a Group, and Rect is a Rectangular(x, y, width, height)
         * You can check each of them in Visual Studio for future references and explanations
         */

        GUI.BeginGroup(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 300, 600, 400));
        GUI.Box(new Rect(0, 0, 600, 400), "Controls");
        GUI.Label(new Rect(205, 40, 20, 20), "PC");
        GUI.Label(new Rect(340, 40, 125, 20), "Xbox 360 Controller");

        GUI.Label(new Rect(25, 75, 125, 20), "Movement: ");
        GUI.Button(new Rect(150, 75, 135, 20), PC_Move);
        GUI.Button(new Rect(325, 75, 135, 20), Xbox_Move);

        GUI.Label(new Rect(25, 100, 125, 20), "Rotation: ");
        GUI.Button(new Rect(150, 100, 135, 20), PC_Rotate);
        GUI.Button(new Rect(325, 100, 135, 20), Xbox_Rotate);

        GUI.Label(new Rect(25, 125, 125, 20), "Item 1: ");
        GUI.Button(new Rect(150, 125, 135, 20), PC_Item1);
        GUI.Button(new Rect(325, 125, 135, 20), Xbox_Item1);

        GUI.Label(new Rect(25, 150, 125, 20), "Item 2: ");
        GUI.Button(new Rect(150, 150, 135, 20), PC_Item2);
        GUI.Button(new Rect(325, 150, 135, 20), Xbox_Item2);

        GUI.Label(new Rect(25, 175, 125, 20), "Item 3: ");
        GUI.Button(new Rect(150, 175, 135, 20), PC_Item3);
        GUI.Button(new Rect(325, 175, 135, 20), Xbox_Item3);

        GUI.Label(new Rect(25, 200, 125, 20), "Item 4: ");
        GUI.Button(new Rect(150, 200, 135, 20), PC_Item4);
        GUI.Button(new Rect(325, 200, 135, 20), Xbox_Item4);

        GUI.Label(new Rect(25, 225, 125, 20), "Inventory: ");
        GUI.Button(new Rect(150, 225, 135, 20), PC_Inv);
        GUI.Button(new Rect(325, 225, 135, 20), Xbox_Inv);

        GUI.Label(new Rect(25, 250, 125, 20), "Pause Game: ");
        GUI.Button(new Rect(150, 250, 135, 20), PC_Pause);
        GUI.Button(new Rect(325, 250, 135, 20), Xbox_Pause);

        GUI.Label(new Rect(25, 275, 125, 20), "Attack/Use: ");
        GUI.Button(new Rect(150, 275, 135, 20), PC_AttackUse);
        GUI.Button(new Rect(325, 275, 135, 20), Xbox_AttackUse);

        GUI.Label(new Rect(25, 300, 125, 20), "Aim: ");
        GUI.Button(new Rect(150, 300, 135, 20), PC_Aim);
        GUI.Button(new Rect(325, 300, 135, 20), Xbox_Aim);

        // We let the player pick between the keyboard/mouse and Xbox 360 Controller
        GUI.Label(new Rect(450, 345, 125, 20), "Current Controls");
        if(GUI.Button(new Rect(425, 370, 135, 20), cProfile.ToString()))
        {
            if (cProfile == ControlProfile.Controller)
                SwitchProfile(ControlProfile.PC);
            else
                SwitchProfile(ControlProfile.Controller);
        }

        // CS
        // We need to allow the player to switch Control Schemes;
        GUI.Label(new Rect(15, 345, 125, 20), "Current Control Scheme");
        if (GUI.Button(new Rect(25, 370, 135, 20), ControlScheme))
        {
            if(ControlScheme == "Scheme A")
            {
                SwitchControlScheme("B");
                ControlScheme = "Scheme B";
            }
            else
            {
                SwitchControlScheme("A");
                ControlScheme = "Scheme A";
            }
        }

        // CC
        if(!ShowPopup)
        {
            if(GUI.Button(new Rect(150, 125, 135, 20), PC_Item1))
            {
                ShowPopup = true;
                PreviousKey = pcItem1;
            }
            if (GUI.Button(new Rect(150, 150, 135, 20), PC_Item2))
            {
                ShowPopup = true;
                PreviousKey = pcItem2;
            }
            if (GUI.Button(new Rect(150, 175, 135, 20), PC_Item3))
            {
                ShowPopup = true;
                PreviousKey = pcItem3;
            }
            if (GUI.Button(new Rect(150, 200, 135, 20), PC_Item4))
            {
                ShowPopup = true;
                PreviousKey = pcItem4;
            }
            if (GUI.Button(new Rect(150, 250, 135, 20), PC_Pause))
            {
                ShowPopup = true;
                PreviousKey = pcPause;
            }
            if (GUI.Button(new Rect(150, 225, 135, 20), PC_Inv))
            {
                ShowPopup = true;
                PreviousKey = pcInv;
            }
            if (GUI.Button(new Rect(325, 225, 135, 20), Xbox_Inv))
            {
                ShowPopup = true;
                PreviousKey = xInv;
            }
            if (GUI.Button(new Rect(325, 250, 135, 20), Xbox_Pause))
            {
                ShowPopup = true;
                PreviousKey = xPause;
            }
        }
        else
        {
            GUI.BeginGroup(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 300, 600, 400));
            GUI.Box(new Rect(0, 0, 600, 400), "Pick A Control to Switch");
            if(GUI.Button(new Rect(150, 125, 135, 20), "1"))
            {
                SetNewKey(PreviousKey, orig_pcItem1);
                ShowPopup = false;
            }
            if (GUI.Button(new Rect(150, 150, 135, 20), "2"))
            {
                SetNewKey(PreviousKey, orig_pcItem2);
                ShowPopup = false;
            }
            if (GUI.Button(new Rect(150, 175, 135, 20), "3"))
            {
                SetNewKey(PreviousKey, orig_pcItem3);
                ShowPopup = false;
            }
            if (GUI.Button(new Rect(150, 200, 135, 20), "4"))
            {
                SetNewKey(PreviousKey, orig_pcItem4);
                ShowPopup = false;
            }
            if (GUI.Button(new Rect(150, 225, 135, 20), "I"))
            {
                SetNewKey(PreviousKey, orig_pcInv);
                ShowPopup = false;
            }
            if (GUI.Button(new Rect(150, 250, 135, 20), "Escape"))
            {
                SetNewKey(PreviousKey, orig_pcPause);
                ShowPopup = false;
            }
            if (GUI.Button(new Rect(325, 225, 135, 20), "A Button"))
            {
                SetNewKey(PreviousKey, orig_xInv);
                ShowPopup = false;
            }
            if (GUI.Button(new Rect(325, 250, 135, 20), ""))
            {
                SetNewKey(PreviousKey, orig_xPause);
                ShowPopup = false;
            }
            GUI.EndGroup();
        }

        // For reset
        if(GUI.Button(new Rect(230, 370, 135, 20), "Reset Controls"))
        {
            Reset();
        }

        GUI.EndGroup();
    }
}
