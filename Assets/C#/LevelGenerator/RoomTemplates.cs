using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates  : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject[] topRightRooms;
    public GameObject[] rightBottomRooms;
    public GameObject[] bottomLeftRooms;
    public GameObject[] leftTopRooms;
    public GameObject[] leftNoTopRooms;
    public GameObject[] topNoRightRooms;
    public GameObject[] rightNoBottomRooms;
    public GameObject[] bottomNoLeftRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;

    private void Update()
    {
        if(waitTime <= 0 && !spawnedBoss)
        {
            for(int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count - 1)
                {
                    Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                    spawnedBoss = true;
                }
            }
        }
        else
        {
            if (waitTime >= 0)  
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
