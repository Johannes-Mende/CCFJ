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
    public bool shouldSpawn = true;

    private GameObject spawnRoom;
    private int random;
    //Setze die richtungs bools wieder auf fals momentan können sie nur true werden
    private void Start()
    {
        genMove = this.GetComponent<GeneratorMove>();
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    }

    public void SpawnRoomStart()
    {
        //Check sides
        CheckSides();
        //Choose Prefab
        Invoke("ChooseRoom", 0.1f);
        //Instantiate Prefab
        Invoke("SpawnRoom", 0.2f);
    }
    
    void CheckSides()
    {
        Collider2D[] colTop = Physics2D.OverlapCircleAll(genTop.transform.position, 2, roomLayers);
        Collider2D[] colRight = Physics2D.OverlapCircleAll(genRight.transform.position, 2, roomLayers);
        Collider2D[] colBottom = Physics2D.OverlapCircleAll(genBottom.transform.position, 2, roomLayers);
        Collider2D[] colLeft = Physics2D.OverlapCircleAll(genLeft.transform.position, 2, roomLayers);

        if(colTop.Length > 0)
        {
            print("TOOOOP");
            if (colTop[0].GetComponent<RoomInfo>().doorBottom)
            {
                needTop = true;
            }
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
        string roomDoorInfo = "T"+needTop.ToString() + "R"+needRight.ToString() + "B"+needBottom.ToString() + "L"+needLeft.ToString();

        switch (roomDoorInfo)
        {
            case "TFalseRFalseBFalseLFalse":
                shouldSpawn = false;
                break;
            case "TTrueRFalseBFalseLFalse":
                random = Random.Range(0, templates.topRooms.Length);
                spawnRoom = templates.topRooms[random];
                shouldSpawn = true;
                break;
            case "TFalseRTrueBFalseLFalse":
                random = Random.Range(0, templates.rightRooms.Length);
                spawnRoom = templates.rightRooms[random];
                shouldSpawn = true;
                break;
            case "TFalseRFalseBTrueLFalse":
                random = Random.Range(0, templates.bottomRooms.Length);
                spawnRoom = templates.bottomRooms[random];
                shouldSpawn = true;
                break;
            case "TFalseRFalseBFalseLTrue":
                random = Random.Range(0, templates.leftRooms.Length);
                spawnRoom = templates.leftRooms[random];
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
