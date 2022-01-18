using System;
using System.Collections.Generic;
using Roommates.Models;
using Roommates.Repositories;

namespace Roommates
{
    class Program
    {
        /// <summary>
        ///  This is the address of the database.
        ///  We define it here as a constant since it will never change.
        /// </summary>
        private const string CONNECTION_STRING = @"server=localhost\SQLExpress;database=Roommates;integrated security=true";

        static void Main(string[] args)
        {
            RoomRepository roomRepo = new RoomRepository(CONNECTION_STRING);

            Console.WriteLine("Getting All Rooms:");
            Console.WriteLine();

            List<Room> allRooms = roomRepo.GetAll();

            foreach (Room room in allRooms)
            {
                Console.WriteLine($"{room.Name} has an Id of {room.Id} and a max occupancy of {room.MaxOccupancy}");
            }

            Console.WriteLine("----------------------------");
            Console.WriteLine("Getting Room with Id 1");

            Room singleRoom = roomRepo.GetById(1);

            Console.WriteLine($"{singleRoom.Id} {singleRoom.Name} {singleRoom.MaxOccupancy}");

            Room bathroom = new Room
            {
                Name = "Bathroom",
                MaxOccupancy = 1
            };

            roomRepo.Insert(bathroom);

            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Added the new Room with id {bathroom.Id}");

            RoommateRepository roommateRepo = new RoommateRepository(CONNECTION_STRING);
            Console.WriteLine("Getting All Rooms:");
            Console.WriteLine();

            List<Roommate> allRoommates = roommateRepo.GetAll();

            foreach (Roommate roommate in allRoommates)
            {
                Console.WriteLine($"{roommate.FirstName} {roommate.LastName} has an Id of {roommate.Id}. {roommate.FirstName}'s rent portion is {roommate.RentPortion} with a move-in date of {roommate.MovedInDate}.");
            }


            Console.WriteLine("----------------------------");
            Console.WriteLine("Getting Room with Id 1");

            Roommate singleRoommate = roommateRepo.GetById(1);

            Console.WriteLine($"{singleRoommate.Id} {singleRoommate.FirstName} {singleRoommate.LastName}");

            List<Roommate> roomiesByRoom = roommateRepo.GetRoommatesByRoomId(3);

            foreach(Roommate r in roomiesByRoom)
            {
                Console.WriteLine($"{r.FirstName} in the {r.Room.Name}");
            }

            
            
         
        }
    }
}