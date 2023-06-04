using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using Microsoft.VisualBasic.FileIO;
using TestReading;
using System.Text.RegularExpressions;

namespace CSVreadFile
{

    class Program
    {
        static void Main(string[] args)

        {
            
                string csvFilePath = "C:\\Users\\david\\source\\repos\\TestReading\\TestReading\\Cells.csv";
                Console.WriteLine("File exists " + csvFilePath);
                ParseCells parseCells = new ParseCells(csvFilePath);

                Console.WriteLine(parseCells);
                Console.WriteLine("Size of the file is: " + parseCells.GetPhones().Count);
                Console.WriteLine(parseCells.HasSingleSensor());
                Console.WriteLine("Phones announced ");

                List<Cells> phoneList = parseCells.GetListWithDifferentYears(); ;
                foreach (Cells phone in phoneList)
                {
                    Console.WriteLine(phone.OEM + "\t" + phone.Model);
                }



            }
        }

    }