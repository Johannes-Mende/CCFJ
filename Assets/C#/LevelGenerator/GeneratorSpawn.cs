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
    private bool noTop, noRight, noBottom, noLeft;
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
        needTop = false; needRight = false; needBottom = false; needLeft = false; noTop = false; noRight = false; noBottom = false; noLeft = false;
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
            else if (!colTop[0].GetComponent<RoomInfo>().doorBottom)
            {
                noTop = true;
            }
        }
        if(colRight.Length > 0)
        {
            if (colRight[0].GetComponent<RoomInfo>().doorLeft)
            {
                needRight = true;
            }
            else if (!colRight[0].GetComponent<RoomInfo>().doorLeft)
            {
                noRight = true;
            }
        }
        if(colBottom.Length > 0)
        {
            if (colBottom[0].GetComponent<RoomInfo>().doorTop)
            {
                needBottom = true;
            }
            else if (!colBottom[0].GetComponent<RoomInfo>().doorTop)
            {
                noBottom = true;
            }
        } 
        if(colLeft.Length > 0)
        {
            if (colLeft[0].GetComponent<RoomInfo>().doorRight)
            {
                needLeft = true;
            }
            else if (!colLeft[0].GetComponent<RoomInfo>().doorRight)
            {
                noLeft = true;
            }
        }
    }

    void ChooseRoom()
    {
        int needTopI = Convert.ToInt32(needTop); int needRightI = Convert.ToInt32(needRight); int needBottomI = Convert.ToInt32(needBottom); int needLeftI = Convert.ToInt32(needLeft);
        int noTopI = Convert.ToInt32(noTop); int noRightI = Convert.ToInt32(noRight); int noBottomI = Convert.ToInt32(noBottom); int noLeftI = Convert.ToInt32(noLeft);
        string roomDoorInfo = needTopI.ToString() + needRightI.ToString() + needBottomI.ToString() + needLeftI.ToString() + ":" + noTopI.ToString() + noRightI.ToString() + noBottomI.ToString() + noLeftI.ToString();

        switch (roomDoorInfo)// TopRightBottomLeft
        {
            default:
                shouldSpawn = false;
                break;
            case "1000:0000":
                Rss(templates.topRooms);
                break;
            case "0100:0000":
                Rss(templates.rightRooms);
                break;
            case "0010:0000":
                Rss(templates.bottomRooms);
                break;
            case "0001:0000":
                Rss(templates.leftRooms);
                break;
            case "1100:0000":
                Rss(templates.topRightRooms);
                break;
            case "0110:0000":
                Rss(templates.rightBottomRooms);
                break;
            case "0011:0000":
                Rss(templates.bottomLeftRooms);
                break;
            case "1001:0000":
                Rss(templates.leftTopRooms);
                break;
            case "1000:0001":
                Rss(templates.topRooms);
                break;
            case "0100:1000":
                Rss(templates.rightRooms);
                break;
            case "0010:0100":
                Rss(templates.bottomRooms);
                break;
            case "0001:0010":
                Rss(templates.leftRooms);
                break;
            case "0001:1000":
                Rss(templates.leftNoTopRooms);
                break;
            case "1000:0100":
                Rss(templates.topNoRightRooms);
                break;
            case "0100:0010":
                Rss(templates.rightNoBottomRooms);
                break;
            case "0010:0001":
                Rss(templates.bottomNoLeftRooms);
                break;
        }
    }
    void Rss(GameObject[] TempList)
    {
        random = UnityEngine.Random.Range(0, TempList.Length);
        spawnRoom = TempList[random];
        shouldSpawn = true;
    }

    void SpawnRoom()
    {
        if (shouldSpawn)
        {
            Instantiate(spawnRoom, transform.position, spawnRoom.transform.rotation);
        }
        genMove.MoveGen();
    }
}
