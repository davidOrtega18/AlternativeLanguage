using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReading
{
    internal class ParseCells
    {
        private List<Cells> list;

        public ParseCells(string filename)
        {
            list = new List<Cells>();
            try
            {
                FileInfo file = new FileInfo(filename);
                using (StreamReader sr = new StreamReader(file.OpenRead()))
                {
                    if (sr.ReadLine() != null)
                    {
                        // Skip the first line
                    }
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Cells phone = CreatePhone(line);
                        list.Add(phone);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Cells CreatePhone(string line)
        {
            string[] tokens = line.Split(",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)", StringSplitOptions.None);
            //if (tokens.Length != 12)
           // {
             //   throw new InvalidOperationException("Input string is malformed");
           // }



            for (int i = 0; i < tokens.Length; i++)
            {
                tokens[i] = tokens[i].Replace("\"", "");
            }

            string oem = CheckStringInput(tokens[0]);
            string model = CheckStringInput(tokens[1]);
            int? announcedYear = GetYearInt(tokens[2]);
            string launchStatus = GetYearStr(tokens[3]);
            string bodyDimensions = tokens[4];
            float? bodyWeight = GetBodyWeight(tokens[5]);
            string bodySim = GetBodySim(tokens[6]);
            string displayType = CheckStringInput(tokens[7]);
            float? displaySize = GetDisplaySize(tokens[8]);
            string resolution = CheckStringInput(tokens[9]);
            string sensors = GetFeatureSensors(tokens[10]);
            string os = GetPlatformOS(tokens[11]);

            return new Cells(oem, model, announcedYear, launchStatus, bodyDimensions, bodyWeight, bodySim, displayType, displaySize, resolution, sensors, os);
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (Cells phone in list)
            {
                sb.Append(phone);
                sb.Append("\n");
            }
            return sb.ToString();
        }

        public string CheckStringInput(string input)
        {
            if (input == null)
            {
                return input;
            }

            if (input.Length == 0)
            {
                return null;
            }

            foreach (char ch in input)
            {
                if (char.IsLetterOrDigit(ch))
                {
                    return input;
                }
            }
            return null;
        }

        public int? GetYearInt(string input)
        {
            input = System.Text.RegularExpressions.Regex.Replace(input, @"[^\d]", "");
            if (input.Length != 4)
            {
                return null;
            }

            int? res = null;
            try
            {
                res = int.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            return res;
        }

        public string GetYearStr(string input)
        {
            if (input.Equals("Discontinued", StringComparison.OrdinalIgnoreCase) ||
                input.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
            {
                return input;
            }
            string res = System.Text.RegularExpressions.Regex.Replace(input, @"[^\d]", "");

            return res.Substring(0, 4);
        }

        public float? GetBodyWeight(string input)
        {
            int index = input.IndexOf("g");
            if (index == -1)
            {
                return null;
            }
            input = input.Substring(0, index).Replace(@"[^\d]", "");
            float? res = null;
            try
            {
                res = float.Parse(input);
            }
            catch (FormatException e)
            {
                // Console.WriteLine(e.Message);
            }
            return res;
        }

        public string GetBodySim(string input)
        {
            if (input.Equals("no", StringComparison.OrdinalIgnoreCase) ||
                input.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }
            return input;
        }

        public float? GetDisplaySize(string input)
        {
            int index = input.IndexOf("inch");
            if (index == -1)
            {
                return null;
            }

            input = input.Substring(0, index);
            System.Text.RegularExpressions.Regex.Replace(input, @"[^\d]", "");
            float? res = null;
            try
            {
                res = float.Parse(input);
            }
            catch (FormatException e)
            {
                // Console.WriteLine(e.Message);
            }
            return res;
        }

        public string GetFeatureSensors(string input)
        {
            bool hasLetters = false;

            foreach (char ch in input)
            {
                if (char.IsLetter(ch))
                {
                    hasLetters = true;
                }
            }

            return hasLetters ? input : null;
        }

        public string GetPlatformOS(string input)
        {
            int index = input.IndexOf(",");
            return index == -1 ? input : input.Substring(0, index);
        }

        public HashSet<Cells> GetUniqueOEMs()
        {
            HashSet<Cells> set = new HashSet<Cells>();
            foreach (Cells phone in list)
            {
                set.Add(phone);
            }
            return set;
        }

        public int HasSingleSensor()
        {
            int count = 0;
            foreach (Cells phone in list)
            {
                string sensors = phone.FeaturesSensors;
                if (!sensors.Contains(","))
                {
                    count++;
                }
            }
            return count;
        }

        public string OEMWithHighestAverageWeight()
        {
            Dictionary<string, List<double>> map = new Dictionary<string, List<double>>();

            foreach (Cells phone in list)
            {
                if (phone.OEM == null || phone.BodyWeight == null)
                {
                    continue;
                }

                if (map.ContainsKey(phone.OEM))
                {
                    map[phone.OEM].Add((double)phone.BodyWeight);
                }
                else
                {
                    map[phone.OEM] = new List<double> { (double)phone.BodyWeight };
                }
            }

            string oem = "";
            double avg = 0.0;

            foreach (string key in map.Keys)
            {
                List<double> weights = map[key];
                double sum = weights.Sum();
                if (avg < sum / weights.Count)
                {
                    avg = sum / weights.Count;
                    oem = key;
                }
            }

            Console.WriteLine("Highest average weight: " + avg);
            return oem;
        }

        public int NumberOfUniqueModels()
        {
            HashSet<string> set = new HashSet<string>();
            foreach (Cells phone in list)
            {
                set.Add(phone.Model);
            }
            return set.Count;
        }

        public List<string> GetListOfPlatforms()
        {
            List<string> res = new List<string>();
            foreach (Cells phone in list)
            {
                res.Add(phone.PlatformOS);
            }
            return res;
        }

        public int FindEarliestYear()
        {
            List<int> res = new List<int>();
            foreach (Cells phone in list)
            {
                res.Add(phone.LaunchAnnounced);
            }
            res.Sort();
            return res[0];
        }

        public float? FindLowestWeight()
        {
            List<float> res = new List<float>();
            foreach (Cells phone in list)
            {
                if (phone.BodyWeight != null)
                {
                    res.Add((float)phone.BodyWeight);
                }
            }
            res.Sort();
            return res[0];
        }

        public int GetYearMostLaunch()
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (Cells phone in list)
            {
                if (phone.LaunchAnnounced != null)
                {
                    int year = (int)phone.LaunchAnnounced;
                    map[year] = map.GetValueOrDefault(year, 0) + 1;
                }
            }

            int maxYear = -1;
            int maxNum = -1;
            foreach (int year in map.Keys)
            {
                if (year != null && map[year] != null && map[year] > maxNum)
                {
                    maxNum = map[year];
                    maxYear = year;
                }
            }
            return maxYear;
        }

        public List<Cells> GetPhones()
        {
            return list;
        }

        public static bool CheckFile(string path)
        {
            FileInfo file = new FileInfo(path);
            return file.Exists;
        }

        public List<Cells> GetListWithDifferentYears()
        {
            int announce = -1;
            int launch = -1;
            List<Cells> diff = new List<Cells>();
            foreach (Cells phone in list)
            {
                if (phone.LaunchAnnounced == null)
                {
                    continue;
                }
                announce = (int)phone.LaunchAnnounced;
                string launchStr = phone.Status;
                if (launchStr.Length > 4)
                {
                    continue;
                }
                launch = int.Parse(launchStr);
                if (launch != announce)
                {
                    diff.Add(phone);
                }
            }
            return diff;
        }
    }
}
