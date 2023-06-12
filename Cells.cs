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
        private string body_dimensions;
        private float body_weight;
        private string body_sim;
        private string display_type;
        private float display_size;
        private string display_resolution;
        private string features_sensors;
        private int? announcedYear;
        private string launchStatus;
        private float? displaySize;
        private string resolution;
        private string os;

        public Cells(string oem, string model, int? announcedYear, string launchStatus, string bodyDimensions, float body_weight, string bodySim, string displayType, float? displaySize, string resolution, string sensors, string os)
        {
            this.oem = oem;
            this.model = model;
            this.announcedYear = announcedYear;
            this.launchStatus = launchStatus;
            BodyDimensions = bodyDimensions;
            getBodyWeight = body_weight;
            BodySim = bodySim;
            DisplayType = displayType;
            this.displaySize = displaySize;
            this.resolution = resolution;
            features_sensors = sensors;
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
            get { return launchStatus; }
            set { launchStatus = value; }
        }

        public string BodyDimensions
        {
            get { return body_dimensions; }
            set { body_dimensions = value; }
        }

        public float getBodyWeight
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

        public string getFeatures_sensors
        {
            get { return features_sensors; }
            set { features_sensors = value; }
        }

        public string PlatformOS
        {
            get { return os; }
            set { os = value; }
        }



        public string toString()
        {
            return "CellPhone{" +
           "oem='" + oem + '\'' +
           ", model='" + model + '\'' +
           ", launch_announced=" + launchStatus +
           ", launch_status='" + launch_announced + '\'' +
           ", body_dimensions='" + body_dimensions + '\'' +
           ", body_weight=" + body_weight +
           ", body_sim='" + body_sim + '\'' +
           ", display_type='" + display_type + '\'' +
           ", display_size=" + display_size +
           ", display_resolution='" + display_resolution + '\'' +
           ", features_sensors='" + features_sensors + '\'' +
           ", platform_os='" + os + '\'' +
           '}';
        }
    }
}
