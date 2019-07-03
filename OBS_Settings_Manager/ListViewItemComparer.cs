using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Diagnostics;

namespace OBS_Settings_Manager
{
    class ListViewItemComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return String.Compare(((ListViewItem)y).SubItems[1].ToString(), ((ListViewItem)x).SubItems[1].ToString());
        }
    }
}
