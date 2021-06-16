using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeys : MonoBehaviour
{
    public float movementX, movementY;
    private int mouseInt;
    void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");

        if (Input.anyKeyDown)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.access.GL.P.PCom.Attack();
            }
            if (Input.GetMouseButtonDown(1))
            {

            }
            if (Input.GetMouseButtonDown(2))
            {

            }

            switch(Input.inputString.ToUpper())
            {
                case "E":
                    // anderes ausführen
                    break;
                case "S":
                    // speicher
                    break;
                case " "://Space
                    GameManager.access.GL.P.PCon.dashButtonDown = true;
                    break;
                case "P":
                    GameManager.access.GL.SmithCraft();
                    break;
                case "I":
                    GameManager.access.GL.INV.ToggleInv();
                    break;
            }
        }
    }
}
