using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField] bool[] openSides = new bool[4] { true, false, false, false };
    public int openingDirection;
    //1 --> need bottom door
    //2 --> need top door
    //3 --> need left door
    //4 --> need right dor

    private RoomTemplates templates;
    private int random;
    public bool spawned = false;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    private void Update()
    {
        /*if (templates.waitTime <= 0)
        {
            Destroy(gameObject);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (!other.GetComponent<RoomSpawner>().spawned && !spawned)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }

    private void Spawn()
    {


        /*if (!spawned)
        {
            if (openingDirection == 1)
            {
                //Need tp Spawn a room with a BOTTOM door
                random = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[random], transform.position, templates.bottomRooms[random].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                //Need to Spawn a room with a TOP door
                random = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.topRooms[random], transform.position, templates.topRooms[random].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                //Need to Spawn a room with a LEFT door
                random = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.leftRooms[random], transform.position, templates.leftRooms[random].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                //Need to Spawn a room with a RIGHT door
                random = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.rightRooms[random], transform.position, templates.rightRooms[random].transform.rotation);
            }
            spawned = true;
        }*/
    }
}
