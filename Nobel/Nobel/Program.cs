using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Nobel
{
    class Program
    {
        struct nobels
        {
            public int year;
            public string type;
            public string FName;
            public string SName;    
        }
        static List<nobels> ListNobels = new List<nobels>();
        static void Main(string[] args)
        {
            StreamReader ReadFile = new StreamReader("nobel.csv", Encoding.UTF8);
            string Rows = ReadFile.ReadLine();
            while (!ReadFile.EndOfStream)
            {
                Rows = ReadFile.ReadLine();
                string[] Split = Rows.Split(";");
                nobels Prizes = new nobels();
                Prizes.year = Convert.ToInt32(Split[0]);
                Prizes.type = Split[1];
                Prizes.FName = Split[2];
                Prizes.SName = Split[3];
                ListNobels.Add(Prizes);
            }
            ReadFile.Close();
            StreamWriter iras = new StreamWriter("orvosi.txt", false, Encoding.UTF8);

            foreach (nobels item in ListNobels)
            {
                if (item.FName == "Arthur B." && item.SName == "McDonald")
                {
                    Console.WriteLine("3. Feladat");
                    Console.WriteLine("Arthus B. McDonald díj típusa: "+item.type);
                }
            }
            string cur = "Curie";
            bool siker = false;
            bool siker2 = false;
            int chemistry = 0;
            int physics = 0;
            int doctor = 0;
            int literature = 0;
            int peace = 0;
            int economy = 0;
            foreach (nobels item in ListNobels)
            {
                if (item.year == 2017 && item.type == "irodalmi")
                {

                    Console.WriteLine("4. Feladat");
                    Console.WriteLine(item.SName + " " + item.SName);
                }
                else if (item.year >= 1990 && item.type == "béke" && item.SName == "")
                {
                    if (siker == false)
                    {
                        Console.WriteLine("5. Feladat");
                        siker = true;
                    }
                    Console.WriteLine(item.FName + " " + item.SName);
                }
                else if (item.SName.Contains(cur))
                {
                    if (siker2 == false)
                    {
                        Console.WriteLine("6. Feladat");
                        siker2 = true;
                    }
                    Console.WriteLine(item.year + " "+ item.type+" "+item.FName +" "+item.SName);
                }
                else if (item.type == "fizikai")
                {
                    physics++;
                }
                else if (item.type =="kémiai")
                {
                    chemistry++;
                }
                else if (item.type == "béke")
                {
                    peace++;
                }
                else if (item.type == "orvosi")
                {
                    doctor++;
                }
                else if (item.type == "irodalmi")
                {
                    literature++;
                }
                else if (item.type == "közgazdaságtani")
                {
                    economy++;
                }
            }
            Console.WriteLine("7. Feladat");
            Console.WriteLine("Fizikai {0} \n Kémiai: {1} \n Béke: {2} \n  Orvosi : {3} \n Irodalmi: {4} \n  Közgazdasági: {5}",physics,chemistry,peace,doctor,literature,economy);



        }
    }
}
