using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DevExpress.XtraEditors;

namespace EnrollmentSystem
{
    public class ProcessProgress
    {
        public static void Show(MarqueeProgressBarControl progCtrl)
        {
            Action invoker = () => progCtrl.Visible = true;
            progCtrl.Invoke(invoker);
        }

        public static void Hide(MarqueeProgressBarControl progCtrl)
        {
            Action invoker = () => progCtrl.Visible = false;
            progCtrl.Invoke(invoker);
        }
    }
}
