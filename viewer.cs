using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yviewer
{
    public partial class viewer : Form
    {
        
        WebBrowser wbYoutube = new WebBrowser();

        public viewer()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (txtVideoUrl.Text != string.Empty)
            {

                string url = txtVideoUrl.Text;
                string id = Regex.Match(url, @"^(?:https?\:\/\/)?(?:www\.)?(?:youtu\.be\/|youtube\.com\/(?:embed\/|v\/|watch\?v\=))([\w-]{10,12})(?:$|\&|\?\#).*").Groups[1].Value;

                if (id != string.Empty)
                {
                    wbYoutube.Url = new Uri("http://www.youtube.com/embed/" + id + "?autoplay=1&hl=en&fs=1");
                    panel1.Controls.Add(wbYoutube);
                    wbYoutube.Dock = DockStyle.Fill;
                }
                else
                {
                    MessageBox.Show("Please insert a valid youtube url", "Invalid Youtube URL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

            }
        }

        private void viewer_Resize(object sender, EventArgs e)
        {
            panel1.AutoSize = true;
            wbYoutube.Size = new System.Drawing.Size(this.Size.Width, this.Size.Height);
            
        }


    }
}
