using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReading
{
    internal class Cells
    {
        
        private string oem;
        private string model;
        private int launch_announced;
        private int year_released;
        private string status;
        private string body_dimensions;
        private float body_weight;
        private string body_sim;
        private string display_type;
        private float display_size;
        private string display_resolution;
        private string features_sensors;
        private string platform_os;
        private int? announcedYear;
        private string launchStatus;
        private float? bodyWeight;
        private float? displaySize;
        private string resolution;
        private string sensors;
        private string os;

        public Cells(string oem, string model, int? announcedYear, string launchStatus, string bodyDimensions, float? bodyWeight, string bodySim, string displayType, float? displaySize, string resolution, string sensors, string os)
        {
            this.oem = oem;
            this.model = model;
            this.announcedYear = announcedYear;
            this.launchStatus = launchStatus;
            BodyDimensions = bodyDimensions;
            this.bodyWeight = bodyWeight;
            BodySim = bodySim;
            DisplayType = displayType;
            this.displaySize = displaySize;
            this.resolution = resolution;
            this.sensors = sensors;
            this.os = os;
        }

    
        public string OEM
        {
            get { return oem; }
            set { oem = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int LaunchAnnounced
        {
            get { return launch_announced; }
            set { launch_announced = value; }
        }

        public int YearReleased
        {
            get { return year_released; }
            set { year_released = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string BodyDimensions
        {
            get { return body_dimensions; }
            set { body_dimensions = value; }
        }

        public float BodyWeight
        {
            get { return body_weight; }
            set { body_weight = value; }
        }

        public string BodySim
        {
            get { return body_sim; }
            set { body_sim = value; }
        }

        public string DisplayType
        {
            get { return display_type; }
            set { display_type = value; }
        }

        public float DisplaySize
        {
            get { return display_size; }
            set { display_size = value; }
        }

        public string DisplayResolution
        {
            get { return display_resolution; }
            set { display_resolution = value; }
        }

        public string FeaturesSensors
        {
            get { return features_sensors; }
            set { features_sensors = value; }
        }

        public string PlatformOS
        {
            get { return platform_os; }
            set { platform_os = value; }
        }


        public string toString()
        {
            String str = "";

            str += "Cell Phone -> {\n";
            str += $"\tOEM : '{OEM}',\n";
            str += $"\tModel : '{Model}',\n";
            str += $"\tLaunch Announced : {LaunchAnnounced},\n";
            str += $"\tLaunch Year : {(YearReleased != 0 ? YearReleased.ToString() : "NULL")},\n";
            str += $"\tLaunch Status : '{Status}',\n";
            str += $"\tBody Dimensions : '{BodyDimensions}',\n";
            str += $"\tBody Weight : {BodyWeight},\n";
            str += $"\tBody Sim : '{BodySim}',\n";
            str += $"\tDisplay Type : '{DisplayType}'\n";
            str += $"\tDisplay Size : {DisplaySize},\n";
            str += $"\tDisplay Resolution : '{DisplayResolution}',\n";
            str += $"\tFeatures Sensors : '{FeaturesSensors}',\n";
            str += $"\tPlatform Os : '{PlatformOS}'\n";
            str += "}";



            return str;
        }


    }
}
