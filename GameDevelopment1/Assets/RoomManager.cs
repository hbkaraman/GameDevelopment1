using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    //public RoomScript room1;
    //public RoomScript room2;
    //public RoomScript room3;
    //public RoomScript room4;
    //public RoomScript room5;
    //public RoomScript room6;
    //public RoomScript room7;
    //public RoomScript room8;
    //public RoomScript room9;
    //public RoomScript room10;

    //private bool room1Fin;
    //private bool room2Fin;
    //private bool room3Fin;
    //private bool room4Fin;
    //private bool room5Fin;
    //private bool room6Fin;
    //private bool room7Fin;
    //private bool room8Fin;
    //private bool room9Fin;
    //private bool room10Fin;

    public RoomScript[] rooms;
    public bool[] roomFin;
    public bool bossDoor;


    void Start()
    {

    }

    void Update()
    {

        for (int i = 0; i < rooms.Length; i++)
        {
            if (rooms[i].roomFinished == true)
            {
                roomFin[i] = true;
            }
            if (roomFin[0] == true && roomFin[1] == true && roomFin[2] == true && roomFin[3] == true && roomFin[4] == true && roomFin[5] == true && roomFin[6] == true && roomFin[7] == true && roomFin[8] == true && roomFin[9])
            {
                bossDoor = true;
            }
        }

    }
}
