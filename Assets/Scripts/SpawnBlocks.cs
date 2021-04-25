using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBlocks : MonoBehaviour
{

    MeshRenderer meshrenderer;
    public Material Control;
    public Material Movement;
    public Material Sound;
    public Material Text;

    public List<GameObject> Blocks;
    public List<Text> BlockText;

    


    // Start is called before the first frame update
    void Start()
    {
        
        for (int i=0; i < Blocks.Count; i++)
        {
            Blocks[i].SetActive(false);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SpawnCommands(List<string> commands)
    {
        for(int i = 0; i < commands.Count; i++)
        {
            Blocks[i].SetActive(true);

            switch (commands[i])
            {
                case "PosX":
                    BlockText[i].text = "Move +X";
                    break;

                case "NegX":
                    BlockText[i].text = "Move -X";
                    break;

                case "PosZ":
                    BlockText[i].text = "Move +Z";
                    break;

                case "NegZ":
                    BlockText[i].text = "Move -Z";
                    break;

                case "Jump":
                    BlockText[i].text = "Jump";
                    break;

                case "Spin":
                    BlockText[i].text = "Spin";
                    break;

                case "Rotate90":
                    BlockText[i].text = "Rotate 90";
                    break;

                case "Rotate180":
                    BlockText[i].text = "Rotate 180";
                    break;

                case "Rotate270":
                    BlockText[i].text = "Rotate 270";
                    break;

                case "movetostored":
                    BlockText[i].text = "Move to stored position";
                    break;

                // SOUND
                case "playsound":
                    BlockText[i].text = "Play Sound";
                    break;

                case "playsound2":
                    BlockText[i].text = "Play Sound 2";
                    break;


                // CONTROL
                case "wait":
                    BlockText[i].text = "Wait";
                    break;

                case "repeat":
                    BlockText[i].text = "Repeat Last Block";
                    break;

                case "repeatX2":
                    BlockText[i].text = "Repeat Last Block Twice";
                    break;

                case "storepos":
                    BlockText[i].text = "Store Current Position";
                    break;

                // TEXT
                case "shtext":
                    BlockText[i].text = "Display \n" + "\"Hello World \n";
                    break;

            }
            
            BlockText[i].gameObject.SetActive(true);  
        }
       
       // blanktext.SetActive(true);
    }

    void DestroyCommands(List<string> commands)
    {
        for (int i = 0; i < commands.Count; i++)
        {
            Blocks[i].SetActive(false);
            BlockText[i].text = "Default";
            BlockText[i].gameObject.SetActive(false);
        }
    }

}
