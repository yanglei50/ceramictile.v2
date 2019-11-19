//using Markdig;
using NetronLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ceramictile.v3
{
    public partial class MainForm : Form
    {
        private Point StartP = new Point(0, 0);
        private bool isMouseDown = false;
        private float fScale = 1.0f;
        private bool isHuanchong = false;
        private int imgIndexBy1000 = 0;
        private bool rdbMove = false;
        private Size beforeResizeSize = Size.Empty;

        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripButton_OpenImageFile_Click(object sender, EventArgs e)
        {
            //浏览图像
            try
            {
                OpenFileDialog MyDlg = new OpenFileDialog();
                MyDlg.Filter = "图像文件(JPeg, Gif, Bmp, etc.)|*.jpg;*.jpeg;*.gif;*.bmp;*.tif; *.tiff; *.png| JPeg图像文件(*.jpg;*.jpeg)| *.jpg;*.jpeg |GIF图像文件(*.gif)|*.gif |BMP图像文件(*.bmp)|*.bmp|Tiff图像文件(*.tif;*.tiff)|*.tif;*.tiff|Png图像文件(*.png)| *.png |所有文件(*.*)|*.*";
                MyDlg.CheckFileExists = true;
                if (MyDlg.ShowDialog() == DialogResult.OK)
                {
                    string MyFile = MyDlg.FileName;
                    this.SystemStatusLabel.Text = MyFile;
                    Bitmap tBitmap = (Bitmap)Image.FromFile(MyFile);
                    this.LeftImageDisplayPictureBox1.Image = ResizeImage(tBitmap, LeftImageDisplayPictureBox1);// (Bitmap)Image.FromFile(MyFile);
                    if (isHuanchong)
                    {
                        LeftImageDisplayPictureBox1.LoadAsync(MyFile);
                    }
                    else
                    {
                        ImgLocationOrigin();
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Bitmap ResizeImage(Bitmap bmp, PictureBox picBox)
        {
            float xRate = (float)bmp.Width / picBox.Size.Width;
            float yRate = (float)bmp.Height / picBox.Size.Height;
            if (xRate <= 1 && yRate <= 1)
            {
                return bmp;
            }
            else
            {
                float tRate = (xRate >= yRate) ? xRate : yRate;
                Graphics g = null;
                try
                {
                    int newW = (int)(bmp.Width / tRate);
                    int newH = (int)(bmp.Height / tRate);
                    Bitmap b = new Bitmap(newW, newH);
                    g = Graphics.FromImage(b);
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                    g.Dispose();
                    //bmp.Dispose();
                    return b;
                }
                catch
                {
                    //bmp.Dispose();
                    return null;
                }
                finally
                {
                    if (null != g)
                    {
                        g.Dispose();
                    }
                }
            }
        }

        private void ImgLocationOrigin()
        {
            //设定图片位置   
            LeftImageDisplayPictureBox1.Location = new Point(0, 0);
            //设定图片初始尺寸   
            LeftImageDisplayPictureBox1.Size = LeftImageDisplayPictureBox1.Image.Size;
            //设定图片纵横比   
            imgIndexBy1000 = (LeftImageDisplayPictureBox1.Image.Height * 1000) / LeftImageDisplayPictureBox1.Image.Width;
            //设定滚动条   
            //if (LeftImageDisplayPictureBox1.Width - this.splitContainer1.Panel1.Width > 0)
            //{
            //    ImgArea_hScrollBar1.Maximum = LeftImageDisplayPictureBox1.Width - this.splitContainer1.Panel1.Width + ImgArea_vScrollBar1.Width + 2;//+ hScrollBar1.LargeChange   
            //    ImgArea_hScrollBar1.Visible = true;
            //}
            //if (LeftImageDisplayPictureBox1.Height - this.splitContainer1.Panel1.Height > 0)
            //{
            //    ImgArea_vScrollBar1.Maximum = LeftImageDisplayPictureBox1.Height - this.splitContainer1.Panel1.Height + ImgArea_hScrollBar1.Height + 2;//+ vScrollBar1.LargeChange   
            //    ImgArea_vScrollBar1.Visible = true;
            //}
        }

        private void LeftImageDisplayPictureBox1_Click(object sender, EventArgs e)
        {
            //取消加载
            this.LeftImageDisplayPictureBox1.CancelAsync();
        }

        private void LeftImageDisplayPictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            StartP = e.Location;
            isMouseDown = true;
        }

        private void LeftImageDisplayPictureBox1_MouseEnter(object sender, EventArgs e)
        {
            LeftImageDisplayPictureBox1.Focus();
        }

        private void LeftImageDisplayPictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.rdbMove && isMouseDown)
            {
                //计算出移动后两个滚动条应该的Value   
                int x = -LeftImageDisplayPictureBox1.Left + StartP.X - e.X;
                int y = -LeftImageDisplayPictureBox1.Top + StartP.Y - e.Y;

                //如果滚动条的value有效则执行操作；   
                //if (x >= -this.splitContainer1.Panel1.Width + 10 && x <= LeftImageDisplayPictureBox1.Width - 10)
                //{
                //    if (ImgArea_hScrollBar1.Visible)
                //    {
                //        if (x > 0)
                //            ImgArea_hScrollBar1.Value = x > ImgArea_hScrollBar1.Maximum ? ImgArea_hScrollBar1.Maximum : x;
                //        LeftImageDisplayPictureBox1.Left = -x - (ImgArea_vScrollBar1.Visible && x < 0 ? ImgArea_vScrollBar1.Width : 0);
                //    }
                //    else
                //        LeftImageDisplayPictureBox1.Left = -x;
                //}

                //if (y >= -this.splitContainer1.Panel1.Height + 10 && y <= LeftImageDisplayPictureBox1.Height - 10)
                //{
                //    if (ImgArea_vScrollBar1.Visible)
                //    {
                //        if (y > 0)
                //            ImgArea_vScrollBar1.Value = y > ImgArea_vScrollBar1.Maximum ? ImgArea_vScrollBar1.Maximum : y;
                //        LeftImageDisplayPictureBox1.Top = -y - (ImgArea_hScrollBar1.Visible && y < 0 ? ImgArea_hScrollBar1.Height : 0);
                //    }
                //    else
                //        LeftImageDisplayPictureBox1.Top = -y;
                //}

                /*****************************************************  
                 * 给予调整滚动条调整图片位置  
                 *****************************************************  
                //计算出移动后两个滚动条应该的Value  
                int x = hScrollBar1.Value + StartP.X -e.X;  
                int y = vScrollBar1.Value + StartP.Y -e.Y;  
                //如果滚动条的value有效则执行操作；  
                //否则将滚动条按不同情况拉到两头  
                if (x >= 0 && x <= hScrollBar1.Maximum)  
                {  
                    hScrollBar1.Value = x;  
                }  
                else  
                {  
                    hScrollBar1.Value = (x < 0 ? 0 : hScrollBar1.Maximum);  
                }  
                if (y >= 0 && y <= vScrollBar1.Maximum)  
                {  
                    vScrollBar1.Value = y;  
                }  
                else  
                {  
                    vScrollBar1.Value = (y < 0 ? 0 : vScrollBar1.Maximum);  
                }*/
            }
            if (this.rdbMove && isMouseDown)
            {
                //计算出移动后两个滚动条应该的Value   
                int x = -LeftImageDisplayPictureBox1.Left + StartP.X - e.X;
                int y = -LeftImageDisplayPictureBox1.Top + StartP.Y - e.Y;

                //如果滚动条的value有效则执行操作；   
                //if (x >= -this.splitContainer1.Panel1.Width + 10 && x <= LeftImageDisplayPictureBox1.Width - 10)
                //{
                //    if (ImgArea_hScrollBar1.Visible)
                //    {
                //        if (x > 0)
                //            ImgArea_hScrollBar1.Value = x > ImgArea_hScrollBar1.Maximum ? ImgArea_hScrollBar1.Maximum : x;
                //        LeftImageDisplayPictureBox1.Left = -x - (ImgArea_vScrollBar1.Visible && x < 0 ? ImgArea_vScrollBar1.Width : 0);
                //    }
                //    else
                //        LeftImageDisplayPictureBox1.Left = -x;
                //}

                //if (y >= -this.splitContainer1.Panel1.Height + 10 && y <= LeftImageDisplayPictureBox1.Height - 10)
                //{
                //    if (ImgArea_vScrollBar1.Visible)
                //    {
                //        if (y > 0)
                //            ImgArea_vScrollBar1.Value = y > ImgArea_vScrollBar1.Maximum ? ImgArea_vScrollBar1.Maximum : y;
                //        LeftImageDisplayPictureBox1.Top = -y - (ImgArea_hScrollBar1.Visible && y < 0 ? ImgArea_hScrollBar1.Height : 0);
                //    }
                //    else
                //        LeftImageDisplayPictureBox1.Top = -y;
                //}

                /*****************************************************  
                 * 给予调整滚动条调整图片位置  
                 *****************************************************  
                //计算出移动后两个滚动条应该的Value  
                int x = hScrollBar1.Value + StartP.X -e.X;  
                int y = vScrollBar1.Value + StartP.Y -e.Y;  
                //如果滚动条的value有效则执行操作；  
                //否则将滚动条按不同情况拉到两头  
                if (x >= 0 && x <= hScrollBar1.Maximum)  
                {  
                    hScrollBar1.Value = x;  
                }  
                else  
                {  
                    hScrollBar1.Value = (x < 0 ? 0 : hScrollBar1.Maximum);  
                }  
                if (y >= 0 && y <= vScrollBar1.Maximum)  
                {  
                    vScrollBar1.Value = y;  
                }  
                else  
                {  
                    vScrollBar1.Value = (y < 0 ? 0 : vScrollBar1.Maximum);  
                }*/
            }
        }

        private void ImageControl_SettingButton_Click(object sender, EventArgs e)
        {
            ImageControlSettingDlg idlg = new ImageControlSettingDlg();
            DialogResult ds = idlg.ShowDialog(this);

            if (ds == DialogResult.OK)
            {

            }
            else
            {

            }

            idlg.Dispose();
        }

        private void LeftImageDisplayPictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //显示图像文件加载结果
            if (e.Error != null)
                MessageBox.Show(e.Error.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (e.Cancelled == true)
                MessageBox.Show("异步装载图像操作被取消！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("异步装载图像操作成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LeftImageDisplayPictureBox1_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //显示当前图像文件加载进度
            //this.progressBar1.Value = e.ProgressPercentage;
        }

        private void ImageControl_PanZoomOut_Click(object sender, EventArgs e)
        {
            if (LeftImageDisplayPictureBox1.Image == null) return;
            fScale *= 2.0f;
            if (LeftImageDisplayPictureBox1.Image.Width * fScale > 10000 || LeftImageDisplayPictureBox1.Image.Height * fScale > 10000)
            {
                fScale *= 0.5f;
                return;
            }
            LeftImageDisplayPictureBox1.Width = (int)(LeftImageDisplayPictureBox1.Image.Width * fScale);
            LeftImageDisplayPictureBox1.Height = (int)(LeftImageDisplayPictureBox1.Image.Height * fScale);
            LeftImageDisplayPictureBox1.Update();
        }

        private void ImageControl_PanZoomIn_Click(object sender, EventArgs e)
        {
            if (LeftImageDisplayPictureBox1.Image == null) return;
            fScale *= 0.5f;
            LeftImageDisplayPictureBox1.Width = (int)(LeftImageDisplayPictureBox1.Image.Width * fScale);
            LeftImageDisplayPictureBox1.Height = (int)(LeftImageDisplayPictureBox1.Image.Height * fScale);
            LeftImageDisplayPictureBox1.Update();
        }

        private void ImageControl_PanFullImage_Click(object sender, EventArgs e)
        {
            //moveButton.Checked = false;
            if (LeftImageDisplayPictureBox1.Image == null) return;
            ImgLocationOrigin();
        }

        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {
            base.OnResizeBegin(e);
            beforeResizeSize = this.Size;
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            base.OnResizeEnd(e);
            //窗口resize之后的大小
            Size endResizeSize = this.Size;
            //获得变化比例
            float percentWidth = (float)endResizeSize.Width / beforeResizeSize.Width;
            float percentHeight = (float)endResizeSize.Height / beforeResizeSize.Height;
            foreach (Control control in this.Controls)
            {
                if (control is DataGridView)
                    continue;
                //按比例改变控件大小
                control.Width = (int)(control.Width * percentWidth);
                control.Height = (int)(control.Height * percentHeight);
                //为了不使控件之间覆盖 位置也要按比例变化
                control.Left = (int)(control.Left * percentWidth);
                control.Top = (int)(control.Top * percentHeight);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                ListViewItem Item = new ListViewItem();
                Item.SubItems.Clear();
                Item.ImageIndex = i % 2;
                //Item.View = View.LargeIcon;
                //Item.LargeImageList = imageList1;
                //Item.SubItems[0].Text = dr["u_name"].ToString();//读取数据库中字段  
                Item.SubItems[0].Text = String.Format("{0:D3}", i);//读取数据库中字段  

                Product_listView.Items.Add(Item);//显示  
            }

            //

            #region The shapes
            TextLabel label = this.graphControl1.AddShape(ShapeTypes.TextLabel, new Point(100, 33)) as TextLabel;

            label.Text = "This is the class hierarchy of Netron-Light.";
            label.Width = 350;
            label.Height = 33;


            SimpleRectangle ent = this.graphControl1.AddShape(ShapeTypes.Rectangular, new Point(200, 100)) as SimpleRectangle;
            ent.Text = "Entity";
            ent.Height = 33;
            ent.ShapeColor = Color.SteelBlue;

            SimpleRectangle conn = this.graphControl1.AddShape(ShapeTypes.Rectangular, new Point(100, 200)) as SimpleRectangle;
            conn.Text = "Connection";
            conn.Height = 33;
            conn.ShapeColor = Color.LightSteelBlue;

            SimpleRectangle shbase = this.graphControl1.AddShape(ShapeTypes.Rectangular, new Point(250, 200)) as SimpleRectangle;
            shbase.Text = "ShapeBase";
            shbase.Height = 33;
            shbase.ShapeColor = Color.LightSteelBlue;

            SimpleRectangle con = this.graphControl1.AddShape(ShapeTypes.Rectangular, new Point(400, 200)) as SimpleRectangle;
            con.Text = "Connector";
            con.Height = 33;
            con.ShapeColor = Color.LightSteelBlue;

            OvalShape oval = this.graphControl1.AddShape(ShapeTypes.Oval, new Point(100, 300)) as OvalShape;
            oval.Text = "Oval";
            oval.Height = 33;
            oval.ShapeColor = Color.AliceBlue;

            OvalShape rec = this.graphControl1.AddShape(ShapeTypes.Oval, new Point(225, 350)) as OvalShape;
            rec.Text = "SimpleRectangle";
            rec.Height = 33;
            rec.Width = 150;
            rec.ShapeColor = Color.AliceBlue;

            OvalShape tl = this.graphControl1.AddShape(ShapeTypes.Oval, new Point(400, 300)) as OvalShape;
            tl.Text = "TextLabel";
            tl.Height = 33;
            tl.ShapeColor = Color.AliceBlue;

            #endregion

            #region The connections
            this.graphControl1.AddConnection(ent.Connectors[0], conn.Connectors[3]);
            this.graphControl1.AddConnection(ent.Connectors[0], con.Connectors[3]);
            this.graphControl1.AddConnection(ent.Connectors[0], shbase.Connectors[3]);
            this.graphControl1.AddConnection(shbase.Connectors[0], oval.Connectors[3]);
            this.graphControl1.AddConnection(shbase.Connectors[0], rec.Connectors[3]);
            this.graphControl1.AddConnection(shbase.Connectors[0], tl.Connectors[3]);



            #endregion

       //     var result = Markdown.ToHtml("This is a text with some *emphasis*");
         //   Console.WriteLine(result);   // prints: <p>This is a text with some <em>emphasis</em></p>
        }



        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
