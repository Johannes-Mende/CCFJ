using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    //0 = Top; 1 = Right; 2 = Bottom; 3 =Left
    [SerializeField] bool[] openSides = new bool[4];

    private GameObject spawnTop, spawnRight, spawnBottom, spawnLeft;
    private bool freeTop, freeRight, freeBottom, freeLeft;

    public LayerMask roomLayers;

    private bool hasDoor;

    private RoomTemplates templates;
    private int random;
    public bool spawned = false;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

        Invoke("SpawnRooms", 0.2f);

        if (openSides[0])
        {
            spawnTop = this.transform.Find("SpawnTop").gameObject;
            Collider2D[] colRoomT = Physics2D.OverlapCircleAll(spawnTop.transform.position, 3, roomLayers);

            if (colRoomT != null)
            {
                Debug.Log("nichts da");
                freeTop = true;
            }
        }        
        if (openSides[1])
        {
            spawnRight = this.transform.Find("SpawnRight").gameObject;
            Collider2D[] colRoomR = Physics2D.OverlapCircleAll(spawnTop.transform.position, 3, roomLayers);

            if (colRoomR != null)
            {
                Debug.Log("nichts da");
                freeRight = true;
            }
        }
        if (openSides[2])
        {
            spawnBottom = this.transform.Find("SpawnBottom").gameObject;
            Collider2D[] colRoomB = Physics2D.OverlapCircleAll(spawnTop.transform.position, 3, roomLayers);

            if (colRoomB != null)
            {
                Debug.Log("nichts da");
                freeBottom = true;
            }
        }        
        if (openSides[3])
        {
            spawnLeft = this.transform.Find("SpawnLeft").gameObject;
            Collider2D[] colRoomL = Physics2D.OverlapCircleAll(spawnTop.transform.position, 3, roomLayers);

            if (colRoomL != null)
            {
                Debug.Log("nichts da");
                freeLeft = true;
            }
        }
    }

    void AskfreeTop()
    {
        Collider2D[] colRoom = Physics2D.OverlapCircleAll(spawnTop.transform.position, 3, roomLayers);

        if(colRoom != null)
        {
            Debug.Log("nichts da");
            freeTop = true;
        }
    }

    void SpawnRooms()
    {
        if(openSides[0] && freeTop)
        {
            Debug.Log("SpawnRooms");
            random = Random.Range(0, templates.bottomRooms.Length);
            Instantiate(templates.bottomRooms[random], spawnTop.transform.position, templates.bottomRooms[random].transform.rotation);
        }
        if(openSides[1] && freeRight)
        {
            Debug.Log("SpawnRooms");
            random = Random.Range(0, templates.leftRooms.Length);
            Instantiate(templates.leftRooms[random], spawnRight.transform.position, templates.leftRooms[random].transform.rotation);
        }
        if(openSides[2] && freeBottom)
        {
            Debug.Log("SpawnRooms");
            random = Random.Range(0, templates.topRooms.Length);
            Instantiate(templates.topRooms[random], spawnBottom.transform.position, templates.topRooms[random].transform.rotation);
        }
        if (openSides[3] && freeLeft)
        {
            Debug.Log("SpawnRooms");
            random = Random.Range(0, templates.rightRooms.Length);
            Instantiate(templates.rightRooms[random], spawnLeft.transform.position, templates.rightRooms[random].transform.rotation);
        }
    }
}
