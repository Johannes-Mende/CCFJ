using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanLevel : MonoBehaviour
{
    private RoomTemplates templates;

    public int unit = 10;
    public LayerMask roomLayers;
    private GameObject checkRoom;

    private bool needTop, needRight, needBottom, needLeft;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    }

    void CleanRooms()
    {
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
            Collider2D[] colTop = Physics2D.OverlapCircleAll(checkRoom.transform.position + unitY, 2, roomLayers);
            if (colTop.Length > 0)
            {
                if (!colTop[0].GetComponent<RoomInfo>().doorBottom)
                {
                    needTop = false;
                }
            }
            else
            {
                //Spawn Deadend
            }
        }
        if (checkRoom.GetComponent<RoomInfo>().doorRight)
        {
            Collider2D[] colRight = Physics2D.OverlapCircleAll(checkRoom.transform.position + unitX, 2, roomLayers);
            if (colRight.Length > 0)
            {
                if (colRight[0].GetComponent<RoomInfo>().doorLeft)
                {

                }
            }
            else
            {
                //Spawn Deadend
            }
        }
        if (checkRoom.GetComponent<RoomInfo>().doorBottom)
        {
            Collider2D[] colBottom = Physics2D.OverlapCircleAll(checkRoom.transform.position + unitY * -1, 2, roomLayers);
            if (colBottom.Length > 0)
            {
                if (colBottom[0].GetComponent<RoomInfo>().doorTop)
                {

                }
            }
            else
            {
                //Spawn Deadend
            }
        }
        if (checkRoom.GetComponent<RoomInfo>().doorLeft)
        {
            Collider2D[] colLeft = Physics2D.OverlapCircleAll(checkRoom.transform.position + unitX * -1, 2, roomLayers);
            if (colLeft.Length > 0)
            {
                if (colLeft[0].GetComponent<RoomInfo>().doorRight)
                {

                }

            }
            else
            {
                //Spawn Deadend
            }
        }
    }
}
