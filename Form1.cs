using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenSaver
{
    public partial class frmScSaver : Form
    {

        List<Image> BGImages = new List<Image>();
        List<BritPic> BritPics = new List<BritPic>();
        Random rand = new Random();

        class BritPic
        {
            public int PicNum;
            public float X;
            public float Y;
        }

        public frmScSaver()
        {
            InitializeComponent();
        }

        private void frmScSaver_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }

        private void frmScSaver_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void frmScSaver_Load(object sender, EventArgs e)
        {
            String[] images = System.IO.Directory.GetFiles("pics");

            foreach (string image in images)
            {
                BGImages.Add(new Bitmap(image));
            }

           for(int i = 0; i < 30; ++i)
            {
                BritPic mp = new BritPic();
                mp.PicNum = i % BGImages.Count;
                mp.X = rand.Next(-200, Width);
                mp.Y = rand.Next(-200, Height);

                BritPics.Add(mp);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void frmScSaver_Paint(object sender, PaintEventArgs e)
        {

            foreach (BritPic bp in BritPics)
            {
                e.Graphics.DrawImage(BGImages[bp.PicNum], bp.X, bp.Y);
                bp.X = rand.Next(-200, Width);
                bp.Y = rand.Next(-200, Height);

            }
        }
    }
}
