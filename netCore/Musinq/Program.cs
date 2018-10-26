using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Artist theOne = Artists.Where(a => a.Hometown == "Mount Vernon");

            //Who is the youngest artist in our collection of artists?
            Artist kiddo = Artist.FirstOrDefault(artist => artist.age == Artists.Min(a => a.Age));

            //Display all artists with 'William' somewhere in their real name
            IEnumerabel<Artist> willies = Artists.Where(a => a.Contains("William"));

            //Display the 3 oldest artist from Atlantap;
            IEnumerabel<Artist> oldies = Artists.Take(3).Where(a => a.Hometown == "Atlanta").OrderBy(a => a.age);
            IEnumerabel<Artist> oldies = Artists.Take(3).Where(a => a.Hometown == "Atlanta").OrderBy(a => a.age).Reverse(); //??

            //(Optional) Display the Group Name of all groups that have members that are not from New York City


            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
	    Console.WriteLine(Groups.Count);
        }
    }
}
