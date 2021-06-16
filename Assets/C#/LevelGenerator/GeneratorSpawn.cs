using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorSpawn : MonoBehaviour
{
    private GeneratorMove genMove;
    private RoomTemplates templates;
    public LayerMask roomLayers;

    public GameObject genTop, genRight, genBottom, genLeft;
    private bool needTop, needRight, needBottom, needLeft;
    private bool noTop, noRight, noBottom, noLeft;//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public bool shouldSpawn = true;

    private GameObject spawnRoom;
    private int random;
    
    private void Start()
    {
        genMove = this.GetComponent<GeneratorMove>();
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    }

    public void SpawnRoomStart()
    {
        needTop = false; needRight = false; needBottom = false; needLeft = false;
        //Check sides
        CheckSides();
        //Choose Prefab
        Invoke("ChooseRoom", 0.01f);
        //Instantiate Prefab
        Invoke("SpawnRoom", 0.02f);
    }
    
    void CheckSides()
    {
        Collider2D[] colTop = Physics2D.OverlapCircleAll(genTop.transform.position, 2, roomLayers);
        Collider2D[] colRight = Physics2D.OverlapCircleAll(genRight.transform.position, 2, roomLayers);
        Collider2D[] colBottom = Physics2D.OverlapCircleAll(genBottom.transform.position, 2, roomLayers);
        Collider2D[] colLeft = Physics2D.OverlapCircleAll(genLeft.transform.position, 2, roomLayers);

        if(colTop.Length > 0)
        {
            if (colTop[0].GetComponent<RoomInfo>().doorBottom)
            {
                needTop = true;
            }
            if (!colTop[0].GetComponent<RoomInfo>().doorBottom)
            {
                noTop = true;
            } //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
        if(colRight.Length > 0)
        {
            if (colRight[0].GetComponent<RoomInfo>().doorLeft)
            {
                needRight = true;
            }
        }
        if(colBottom.Length > 0)
        {
            if (colBottom[0].GetComponent<RoomInfo>().doorTop)
            {
                needBottom = true;
            }
        } 
        if(colLeft.Length > 0)
        {
            if (colLeft[0].GetComponent<RoomInfo>().doorRight)
            {
                needLeft = true;
            }

        }
    }

    void ChooseRoom()
    {
        int needTopI = Convert.ToInt32(needTop);
        int needRightI = Convert.ToInt32(needRight);
        int needBottomI = Convert.ToInt32(needBottom);
        int needLeftI = Convert.ToInt32(needLeft);
        string roomDoorInfo = needTopI.ToString() + needRightI.ToString() + needBottomI.ToString() + needLeftI.ToString();

        switch (roomDoorInfo)// TopRightBottomLeft
        {
            case "0000":
                shouldSpawn = false;
                break;
            case "1000":
                random = UnityEngine.Random.Range(0, templates.topRooms.Length);
                spawnRoom = templates.topRooms[random];
                shouldSpawn = true;
                break;
            case "0100":
                random = UnityEngine.Random.Range(0, templates.rightRooms.Length);
                spawnRoom = templates.rightRooms[random];
                shouldSpawn = true;
                break;
            case "0010":
                random = UnityEngine.Random.Range(0, templates.bottomRooms.Length);
                spawnRoom = templates.bottomRooms[random];
                shouldSpawn = true;
                break;
            case "0001":
                random = UnityEngine.Random.Range(0, templates.leftRooms.Length);
                spawnRoom = templates.leftRooms[random];
                shouldSpawn = true;
                break;
            case "1100":
                random = UnityEngine.Random.Range(0, templates.topRightRooms.Length);
                spawnRoom = templates.topRightRooms[random];
                shouldSpawn = true;
                break;
            case "0110":
                random = UnityEngine.Random.Range(0, templates.rightBottomRooms.Length);
                spawnRoom = templates.rightBottomRooms[random];
                shouldSpawn = true;
                break;
            case "0011":
                random = UnityEngine.Random.Range(0, templates.bottomLeftRooms.Length);
                spawnRoom = templates.bottomLeftRooms[random];
                shouldSpawn = true;
                break;
            case "1001":
                random = UnityEngine.Random.Range(0, templates.leftTopRooms.Length);
                spawnRoom = templates.leftTopRooms[random];
                shouldSpawn = true;
                break;
        }
        print(roomDoorInfo);
    }

    void SpawnRoom()
    {
        print("SpawnRoom");
        if (shouldSpawn)
        {
            Instantiate(spawnRoom, transform.position, spawnRoom.transform.rotation);
        }
        genMove.MoveGen();
    }
}
