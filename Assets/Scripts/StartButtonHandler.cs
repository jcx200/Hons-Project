using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonHandler : MonoBehaviour
{ 
    /*
    public Button StartButton, StopButton;
    public PositiveXAxis AxisXPos;
    public PositiveZAxis AxisZPos;
    public NegativeXAxis AxisXNeg;
    public NegativeZAxis AxisZNeg;


    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(StartScript);
        StopButton.onClick.AddListener(StopScript);
        AxisXPos = StickFigure.GetComponent<PositiveXAxis>().MovePosX();
        AxisZPos = StickFigure.GetComponent<PositiveZAxis>().MovePosZ();
        AxisXNeg = StickFigure.GetComponent<NegativeXAxis>().MoveNegX();
        AxisZNeg = StickFigure.GetComponent<NegativeZAxis>().MoveNegZ();
    }

 
    public IEnumerator StartScript()
    {
       for(int i =0; i < 10; i++)
       {
            AxisXPos.MovePosX();
            Debug.Log("Character moved in a positive X Direction");
            yield return new WaitForSeconds(1f);

            AxisZPos.MovePosZ();
            Debug.Log("Character moved in a positive Z Direction");
            yield return new WaitForSeconds(1f);

            AxisXNeg.MoveNegX();
            Debug.Log("Character moved in a negative X Direction");
            yield return new WaitForSeconds(1f);


            AxisZNeg.MoveNegZ();
            Debug.Log("Character moved in a negative Z Direction");
            yield return new WaitForSeconds(1f);

        }
    }

    void StopScript()
    {
        Debug.Log("Not Yet Implemented");
    }


    */

}
