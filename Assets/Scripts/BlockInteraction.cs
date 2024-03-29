﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockInteraction : MonoBehaviour
{

    Vector3 startPos;

    //List to store selected commands in. Static modifier means that only one instance of the list exists.
    public static List<string> commands = new List<string>();
    GameObject character;
    GameObject BlankBlocks;

    public static bool isRunning;
    
    // Start is called before the first frame update
    void Start()
    {
        //Find the controllable character
        character = GameObject.Find("StickFigure");
        BlankBlocks = GameObject.Find("BlankBlocks");
    }


    public void OnMouseDown()
    {
        //Detect which objects have been interacted with by chacking name and then store a command name in the commands list
        switch (gameObject.name)
        {

            // MOVEMENT BLOCKS
            case "MovePlusX":
                Debug.Log(name + " added");
                commands.Add("PosX");
                break;
            case "MovePlusZ":
                Debug.Log(name + " added");
                commands.Add("PosZ");
                break;
            case "MoveMinusX":
                Debug.Log(name + " added");
                commands.Add("NegX");
                break;
            case "MoveMinusZ":
                Debug.Log(name + " added");
                commands.Add("NegZ");
                break;
            case "JumpBlock":
                Debug.Log(name + " added");
                commands.Add("Jump");
                break;
            case "Spin":
                Debug.Log(name + " added");
                commands.Add("Spin");
                break;
            case "Rotate90":
                Debug.Log(name + " added");
                commands.Add("Rotate90");
                break;
            case "Rotate180":
                Debug.Log(name + " added");
                commands.Add("Rotate180");
                break;
            case "Rotate270":
                Debug.Log(name + " added");
                commands.Add("Rotate270");
                break;
            case "MoveToStoredPos":
                Debug.Log(name + " added");
                commands.Add("movetostored");
                break;

            // CONTROL BLOCKS
            case "WaitBlock":
                Debug.Log(name + " added");
                commands.Add("wait");
                break;
            case "RepeatLast":
                Debug.Log(name + " added");
                commands.Add("repeat");
                break;
            case "RepeatLastX2":
                Debug.Log(name + " added");
                commands.Add("repeatX2");
                break;
            case "StorePosition":
                Debug.Log(name + " added");
                commands.Add("storepos");
                break;

            // SOUND BLOCK 
            case "PlaySound":
                Debug.Log(name + " added");
                commands.Add("playsound");
                break;
            case "PlaySound2":
                Debug.Log(name + " added");
                commands.Add("playsound2");
                break;

            // TEXT BLOCK
            case "DisplayText":
                Debug.Log(name + " added");
                commands.Add("shtext");
                break;

            // START/STOP/CLEAR
            //Use the SendMessage scripting function to send commands to the class attached to the character to be executed
            case "StartModel":
                isRunning = true;
                Debug.Log("Starting script with " + commands.Count + " commands");
                BlankBlocks.SendMessage("SpawnCommands", commands);
                character.SendMessage("StartScript", commands);

                break;

            case "StopModel":
                isRunning = false;
                BlankBlocks.SendMessage("DestroyCommands", commands);
                character.SendMessage("StopScript", commands);
                Debug.Log("Script stopped and commands cleared");
                break;

            case "ClearLast":
                if (isRunning)
                {
                    Debug.Log("Script Is Being Executed. It is not possible to clear a command at this time");
                }
                else
                {
                    if (commands.Count != 0)
                    {
                        commands.RemoveAt(commands.Count - 1);
                        Debug.Log("Command cleared");
                    }
                }
               
                break;
            default:
                Debug.Log("Invalid");
                break;
        }
    }
}