using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnrollmentSystem
{
    public class Variables
    {
        public static string passphrase = "dmccfi";

        //View Profile History Key as ID
        public static int Profile_Id { get; set; }

        public static string ConnectionString = string.Format(@"Data Source={0};
                                                                Initial Catalog={1};
                                                                User Id={2};
                                                                Password={3};",
        Properties.Settings.Default.Server,
        Properties.Settings.Default.Database,
        Properties.Settings.Default.Username,
        Properties.Settings.Default.Password);

        //public static string ApplicationTheme = Properties.Settings.Default.ApplicationTheme;

        public static Color ErrorColor = Color.FromArgb(0xFE, 0xDD, 0xDD);

        public static Color ColorFromID(int index)
        {
            switch (index)
            {
                case 0:
                    return Color.LightSkyBlue;
                case 1:
                    return Color.LightCoral;
                case 2:
                    return Color.LightGreen;
                case 3:
                    return Color.Yellow;
                case 4:
                    return Color.LightYellow;
                default:
                    return Color.LightGray;
            }
        }
    }
}
