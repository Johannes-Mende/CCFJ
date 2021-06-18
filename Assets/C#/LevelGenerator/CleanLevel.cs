using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanLevel : MonoBehaviour
{
    private RoomTemplates templates;

    public int unit = 10;
    public LayerMask roomLayers;
    private GameObject checkRoom;

    public GameObject deadEndTop;
    public GameObject deadEndRight;
    public GameObject deadEndBottom;
    public GameObject deadEndLeft;

    private bool needTop, needRight, needBottom, needLeft;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            CleanRooms();
        }
    }

    void CleanRooms()
    {
        print("Cleaning");
        for (int i = 0; i < templates.rooms.Count; i++)
        {
            checkRoom = templates.rooms[i];
            CheckSides();
        }
    }

    void CheckSides()
    {
        Vector3 unitY = new Vector2(0, unit);
        Vector3 unitX = new Vector2(unit, 0);

        if (checkRoom.GetComponent<RoomInfo>().doorTop)
        {
            Collider2D[] colTop = Physics2D.OverlapCircleAll(checkRoom.transform.position + unitY, 0.5f, roomLayers);
            if (colTop.Length == 0)
            {
                Instantiate(deadEndBottom, checkRoom.transform.position + unitY, deadEndBottom.transform.rotation);
            }
        }
        if (checkRoom.GetComponent<RoomInfo>().doorRight)
        {
            Collider2D[] colRight = Physics2D.OverlapCircleAll(checkRoom.transform.position + unitX, 0.5f, roomLayers);
            if (colRight.Length == 0)
            {
                Instantiate(deadEndLeft, checkRoom.transform.position + unitX, deadEndLeft.transform.rotation);
            }
        }
        if (checkRoom.GetComponent<RoomInfo>().doorBottom)
        {
            Collider2D[] colBottom = Physics2D.OverlapCircleAll(checkRoom.transform.position + unitY * -1, 0.5f, roomLayers);
            if (colBottom.Length == 0)
            {
                Instantiate(deadEndTop, checkRoom.transform.position + unitY * -1, deadEndTop.transform.rotation);
            }
        }
        if (checkRoom.GetComponent<RoomInfo>().doorLeft)
        {
            Collider2D[] colLeft = Physics2D.OverlapCircleAll(checkRoom.transform.position + unitX * -1, 0.5f, roomLayers);
            if (colLeft.Length == 0)
            {
                Instantiate(deadEndRight, checkRoom.transform.position + unitX * -1, deadEndRight.transform.rotation);
            }
        }
    }
}
