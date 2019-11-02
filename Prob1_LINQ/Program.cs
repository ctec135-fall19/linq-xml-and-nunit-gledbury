/*
Author: George Ledbury 
Date: 11/01/19
CTEC 135: Microsoft Software Development with C#
Module 6, Programming Assignment 5, Problem 1

** Problem 1 LINQ-Region 1
    Create a static method that:
    -creates an array of strings (the ordering of the strings should be random)
    -create a LINQ statement that returns the strings that start with 'a' - 'f'
    -output the result 
    -modify the array in such a way that the result will be different
    -output the result again
    -modify the array in such a way that the result will be different
    -capture the result as a List<string> object and return it
    -in Main, output the returned result

** Problem2 XML Using LINQ region2
    Create a static method that creates an XML document and saves it.
 Create a static method that creates an XML document from an array and saves it
  Create a static method that loads an XML document and prints it to the screen. 
       

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Prob1_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // array of states
            string[] states = {"Alaska", "Texas", "Oregon", "Washington",
                "Arizona", "Florida", "California", "Idaho", "Arkansas",
                "Georgia", "Nevada", "Deleware", "Hawaii", "Colorado"};

            Console.WriteLine("Original list of states:\n");
            foreach (var s in states)
            {
                Console.WriteLine("{0}", s);
            }
            Console.WriteLine();

            List<string> listResults = QueryOverStrings(states);
            List<string> listResults2 = QueryOverStrings2(states);
            List<string> listResults3 = QueryOverStrings3(states);


            Console.WriteLine();

            //XMLDocWithLINQ();
            Console.WriteLine();
            //XMLDocFromArray();
            XDocument blazerPlayer = XDocument.Load("BlazerRosterWithLINQ.xml");
            Console.WriteLine(blazerPlayer);

            #region 1 Problem1
            //LINQ query
            static List<string> QueryOverStrings(string[] inputArray)
            {
                var statesAthroughF = (from state in inputArray
                                       where state.StartsWith("A") ||
                                       state.StartsWith("B") ||
                                       state.StartsWith("C") ||
                                       state.StartsWith("D") ||
                                       state.StartsWith("E") ||
                                       state.StartsWith("F")
                                       orderby state ascending
                                       select state).ToList<string>();
                Console.WriteLine("states that start with a-f using a LINQ query\n");
                foreach (var i in statesAthroughF)
                {
                    Console.WriteLine("State: {0}", i);
                }
                Console.WriteLine();
                return statesAthroughF;

            }
            Console.WriteLine();

            static List<string> QueryOverStrings2(string[] inputArray)
            //modify array to show states that start with a vowel
            {
                var startsWithVowel = (from state in inputArray
                                       where state.StartsWith("A") ||
                                       state.StartsWith("E") ||
                                       state.StartsWith("I") ||
                                       state.StartsWith("O") ||
                                       state.StartsWith("U")
                                       orderby state ascending
                                       select state).ToList<string>();
                Console.WriteLine("states that start with a vowel using LINQ query\n");
                foreach (var i in startsWithVowel)
                {
                    Console.WriteLine("State: {0}", i);
                }
                Console.WriteLine();
                return startsWithVowel;
            }
            // modify again to states end with a
            static List<string> QueryOverStrings3(string[] inputArray)
            {
                var endsWithA = (from state in inputArray
                                 where state.EndsWith("a")
                                 orderby state ascending
                                 select state).ToList<string>();
                Console.WriteLine("states that end with a using LINQ query\n");
                foreach (var i in endsWithA)
                {
                    Console.WriteLine("State: {0}", i);
                }
                Console.WriteLine();
                return endsWithA;

            }
            #endregion 1

            #region: 2 Problem2
            // Create a static method that creates an XML document and saves it
            static void XMLDocWithLINQ()
            {
                XElement blazerRoster =
                    new XElement("Roster",
                    new XElement("Player", new XAttribute("Number", "00"),
                    new XElement("Name", "Damian Lillard"),
                    new XElement("Position", "Point Guard"),
                    new XElement("Height", "6'3")
                    )
                    );
                // save to file
                blazerRoster.Save("BlazerRosterWithLINQ.xml");
            }

            // static method that creates an XML document 
            // from an array and saves it
            static void XMLDocFromArray()
            {
                var players = new[]
                {
                    new {PlayerName = "CJ McCollum", Number = "3"},
                    new {PlayerName = "Jusuf Nurkic", Number = "27"},
                    new {PlayerName = "Zach Collins", Number = "33"},
                    new {PlayerName = "Hassan Whiteside", Number = "21"}
                };

                XElement blazerDoc = 
                    new XElement("Blazers",
                    from p in players select new XElement("Player", 
                    new XAttribute("Number", p.Number),
                    new XElement("PlayerName", p.PlayerName))
                );
                    blazerDoc.Save("BlazerRosterFromArray.xml");
                    Console.WriteLine(blazerDoc);
            }
        }
        #endregion 2

    }



    
}
