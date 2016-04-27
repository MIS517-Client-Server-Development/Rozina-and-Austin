using System.Collections.Generic;
using UniversityManagementApp.DBGateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class RoomManager
    {
        RoomGateway aRoomGateway = new RoomGateway();
        public List<Room> GetAllRooms()
        {
            return aRoomGateway.GetAllRooms();
        }
    }
}