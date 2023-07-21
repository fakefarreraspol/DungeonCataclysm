using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInfo
{
    public string name;
    public int X;
    public int Y;
}
public class RoomController : MonoBehaviour
{
    public static RoomController instance;

    string currentWorldName = "Floor";
    RoomInfo currentLoadRoomData;
    Queue<RoomInfo> loadRoomQueue = new Queue<RoomInfo>();
    public List<Room> loadedRooms = new List<Room>();
    bool isLoadingRoom = false;

    void Awake()
    {
        instance = this;
    }

    public bool DoesRoomExist(int x, int y)
    {
        return loadedRooms.Find( item => item.X == x && item.Y == y) != null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
