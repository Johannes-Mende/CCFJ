using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorMove : MonoBehaviour
{
    private GeneratorSpawn genSpawn;
    
    private Transform bodyGen;

    private int unit = 10;
    private Vector3 maxTop, maxLeft, maxDown, maxRight;

    private bool moveUp, moveLeft, moveDown, moveRight;
    private bool move = false;

    private void Start()
    {
        genSpawn = this.GetComponent<GeneratorSpawn>();
        bodyGen = this.transform;
        SetMax();
        moveRight = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            move = true;
            MoveGen();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            SetMax();
        }
    }

    Vector3 Setdirection()
    {
        Vector3 newPos = new Vector3();
        Vector3 moveUpV = new Vector3(0,unit, 0);
        Vector3 moveLeftV = new Vector3(-unit, 0, 0);
        Vector3 moveDownV = new Vector3(0,-unit, 0);
        Vector3 moveRightV = new Vector3(unit, 0, 0);

        if (moveUp)
        {
            newPos = moveUpV;
        }
        if (moveLeft)
        {
            newPos = moveLeftV;
        }
        if (moveDown)
        {
            newPos = moveDownV;
        }
        if (moveRight)
        {
            newPos = moveRightV;
        }
        return newPos;
    }

    public void MoveGen()
    {
        if (move)
        {
            bodyGen.position = bodyGen.position + Setdirection();
            Invoke("CheckMax", 0.1f);
            genSpawn.SpawnRoomStart();
        }
    }

    void SetMax()
    {
        maxTop.y = maxTop.y + unit +5;
        maxLeft.x = maxLeft.x - unit +5;
        maxDown.y = maxDown.y - unit +5;
        maxRight.x = maxRight.x + unit +5;
    }
    void CheckMax()
    {
        if(bodyGen.position.y >= maxTop.y && moveUp)
        {
            Debug.Log("MaxTop");
            moveUp = false;
            moveLeft = true;
            maxTop.y = maxTop.y + unit;
        }
        if(bodyGen.position.x <= maxLeft.x && moveLeft)
        {
            Debug.Log("MaxLeft");
            moveLeft = false;
            moveDown = true;
            maxLeft.x = maxLeft.x - unit;
        }
        if(bodyGen.position.y <= maxDown.y && moveDown)
        {
            Debug.Log("MaxDown");
            moveDown = false;
            moveRight = true;
            maxDown.y = maxDown.y - unit;
        }
        if(bodyGen.position.x >= maxRight.x && moveRight)
        {
            Debug.Log("MaxRight");
            moveRight = false;
            moveUp = true;
            maxRight.x = maxRight.x + unit;
        }
    }
}
