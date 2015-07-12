using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using System.Diagnostics;
using System.Threading;
using System.Globalization;
using System.IO;
using System.Data;

namespace EnrollmentSystem
{
    public class Functions
    {
        public static void ShowError(Exception Error)
        {
            XtraMessageBox.Show(Error.ToString());
        }

        public static void SyncMyTime()
        {
            using (Process p = new Process() { StartInfo = new ProcessStartInfo("cmd", "/c time 02:30:02") { UseShellExecute = true, CreateNoWindow = true } })
            {
                p.Start();
            }
        }

        public static bool ValidateThisControls(params object[] InputControls)
        {
            bool validAll = true;

            foreach (object obj in InputControls)
            {
                if (obj is TextEdit)
                {
                    TextEdit txtObj = (TextEdit)obj;
                    validAll &= (txtObj.Text.Trim() != string.Empty);
                    txtObj.BackColor = (txtObj.Text.Trim() == string.Empty) ? Variables.ErrorColor : Color.White;
                }

                if (obj is MemoEdit)
                {
                    MemoEdit memObj = (MemoEdit)obj;
                    validAll &= (memObj.Text.Trim() != string.Empty);
                    memObj.BackColor = (memObj.Text.Trim() == string.Empty) ? Variables.ErrorColor : Color.White;
                }
                if (obj is DateEdit)
                {
                    DateEdit dateObj = (DateEdit)obj;
                    validAll &= (dateObj.Text.Trim() != string.Empty);
                    dateObj.BackColor = (dateObj.Text.Trim() == string.Empty) ? Variables.ErrorColor : Color.White;
                }

                if (obj is ComboBoxEdit)
                {
                    ComboBoxEdit cboxOnj = (ComboBoxEdit)obj;
                    validAll &= (cboxOnj.Text.Trim() != string.Empty);
                    cboxOnj.BackColor = (cboxOnj.Text.Trim() == string.Empty) ? Variables.ErrorColor : Color.White;
                }

                if (obj is SpinEdit)
                {
                    SpinEdit spinObj = (SpinEdit)obj;
                    validAll &= !(spinObj.Value <= 0);
                    spinObj.BackColor = (spinObj.Value <= 0) ? Variables.ErrorColor : Color.White;
                }

                if (obj is MRUEdit)
                {
                    MRUEdit cboxOnj = (MRUEdit)obj;
                    validAll &= (cboxOnj.Text.Trim() != string.Empty);
                    cboxOnj.BackColor = (cboxOnj.Text.Trim() == string.Empty) ? Variables.ErrorColor : Color.White;
                }
            }

            return validAll;
        }

        public static string UppercaseFirst(string s)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            String sf = s.ToLower();
            return textInfo.ToTitleCase(sf);
        }

        public static Image GetImageFromBytes(byte[] bytes)
        {
            Image img = null;

            try
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    img = Image.FromStream(ms);
                }
            }
            catch (Exception)
            {

            }

            return img;
        }

        public static byte[] GetByteArrayFromImage(Image image)
        {
            byte[] imgData = null;

            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                    imgData = ms.ToArray();
                }
                catch (Exception)
                {

                }
            }

            return imgData;
        }

        public static byte[] GetByteArrayFromImage(string imagePath)
        {
            byte[] imgData = null;
            Image img = Image.FromFile(imagePath);

            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                    imgData = ms.ToArray();
                }
                catch (Exception)
                {

                }
            }

            return imgData;
        }

        public static bool TableContains(DataTable dataTable, object[] objArr)
        {
            foreach (DataRow dr in dataTable.Rows)
            {
                object[] rowObj = dr.ItemArray;
                int count = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (rowObj[i].ToString().Trim() == objArr[i].ToString().Trim())
                    {
                        count++;
                    }
                }

                if (count == 5)
                {
                    return true;
                }
            }

            return false;
        }

        public static string Ellipse(string str, int length, char append)
        {
            return str.Remove(length - 1, str.Length - length - 1) + append + append + append;
        }

        public static DateTime PauseForMilliSeconds(int MilliSecondsToPauseFor)
        {


            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MilliSecondsToPauseFor);
            DateTime AfterWards = ThisMoment.Add(duration);


            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }


            return DateTime.Now;
        }

    }
}
