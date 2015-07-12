using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace EnrollmentSystem
{
    public class Forms
    {
        public enum OpenType
        {
            CloseOtherChild,
            CloseOtherInstance,
            OpenAsNew
        }

        /// <summary>
        /// Showing form in fucntion
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <param name="openType"></param>
        public static void ShowThisForm<T>(XtraForm parent, OpenType openType)
            where T: XtraForm, new()
        {
            T xfrmName = (T)OpenForm(typeof(T), openType, parent);
        }

        public static void ShowLabelError(LabelControl Label, MessageType MessageType, string Message, int FadeTimeoutMilli)
        {
            switch (MessageType)
            {
                case MessageType.Error:
                    Label.Text = "<b>Error: </b> " + Message;
                    break;
                case MessageType.Warning:
                    Label.Text = "<b>Warning: </b> " + Message;
                    break;
            }

            Functions.PauseForMilliSeconds(FadeTimeoutMilli);
            Label.Text = string.Empty;
        }

        public enum MessageType
        {
            Error,
            Warning
        }

        public static XtraForm OpenForm(Type t, OpenType oType, XtraForm parent)
        {
            bool instanceFound = false;

            if (!t.IsSubclassOf(typeof(XtraForm)) && !(t == typeof(XtraForm)))
            {
                throw new ArgumentException("Type is not a form", "t");
            }

            XtraForm result = (XtraForm)Activator.CreateInstance(t);

            switch (oType)
            {
                case OpenType.CloseOtherInstance:
                    try
                    {
                        foreach (XtraForm x in Application.OpenForms)
                        {
                            if (x.Text == result.Text)
                            {
                                instanceFound = true;
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                    break;


                case OpenType.CloseOtherChild:
                    try
                    {
                        List<XtraForm> frms = new List<XtraForm>();
                        foreach (XtraForm x in Application.OpenForms)
                        {
                            if (x.IsMdiChild)
                            {
                                frms.Add(x);
                            }
                        }

                        while (frms.Count > 0)
                        {
                            Form f = frms[0];
                            f.Close();
                            f.Dispose();
                            frms.RemoveAt(0);
                        }

                        result.MdiParent = parent;
                        result.Show();
                    }
                    catch (Exception)
                    {
                        //XtraMessageBox.Show(ex.Message);
                    }
                    break;

                case OpenType.OpenAsNew:

                    result.MdiParent = parent;
                    result.Show();

                    break;
            }

            if (!instanceFound)
            {
                result.MdiParent = parent;
                result.Show();
            }

            return result;
        }


        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            using (XtraForm form = new XtraForm())
            {
                using (LabelControl label = new LabelControl())
                {
                    using (TextEdit textBox = new TextEdit())
                    {
                        SimpleButton buttonOk = new SimpleButton();
                        SimpleButton buttonCancel = new SimpleButton();
                        form.Text = title;
                        label.Text = promptText;
                        textBox.Text = value;
                        buttonOk.Text = "OK";
                        buttonCancel.Text = "Cancel";
                        buttonOk.DialogResult = DialogResult.OK;
                        buttonCancel.DialogResult = DialogResult.Cancel;
                        label.SetBounds(9, 20, 372, 13);
                        textBox.SetBounds(12, 38, 372, 20);
                        buttonOk.SetBounds(228, 72, 75, 23);
                        buttonCancel.SetBounds(309, 72, 75, 23);
                        label.AutoSize = true;
                        textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
                        buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                        buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                        form.ClientSize = new Size(396, 107);
                        form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
                        form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
                        form.FormBorderStyle = FormBorderStyle.FixedDialog;
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.MinimizeBox = false;
                        form.MaximizeBox = false;
                        form.AcceptButton = buttonOk;
                        form.CancelButton = buttonCancel;
                        DialogResult dialogResult = form.ShowDialog();
                        value = textBox.Text;
                        return dialogResult;
                    }
                }
            }
        }
    }
}
