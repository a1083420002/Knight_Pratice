using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_MemoryCache
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 獲取快取
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            CacheHelper.CacheInsert("Yes", textBox1.Text);
            //CacheHelper.CacheInsertAddMin("Yes", textBox1.Text,1);
        }
        /// <summary>
        /// 刪除快取
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button2_Click(object sender, EventArgs e)
        {
           CacheHelper.CacheRemove("Yes");
        }
        /// <summary>
        /// 讀取快取
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            object cache = CacheHelper.CacheRead("Yes");
            string cacheNow = "";
            if (cache != null)
            {
                cacheNow = cache.ToString();
            }

            MessageBox.Show(cacheNow);
        }
    }
}
