using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace EasyTools.Tools
{
    public class ImageChanged:IDisposable
    {
        Image image = null;
        public ImageChanged(string path)
        {
            image = Image.FromFile(path);
            fpath = path;
        }
        string fpath = "";
        public void Save(string path, ImageFormat format)
        {
            if (format == ImageFormat.Icon)
            {
                
                Icon icn = new Icon(fpath, new Size(128, 128));
                FileStream fs = File.Open(path, FileMode.Create, FileAccess.Write, FileShare.Delete);
                icn.Save(fs);
            }
            else
            image.Save(path, format);
        }

        public void Dispose()
        {
            if (image != null)
                image.Dispose();
            
        }

        public void SaveIco(string text, int v)
        {
            Image p = new Bitmap(v, v);
            Graphics g = Graphics.FromImage(p);
            g.DrawImage(image, 0, 0, v, v);
            MemoryStream msImg = new MemoryStream();
            Stream icos = File.Open(text, FileMode.OpenOrCreate, FileAccess.Write);
            p.Save(msImg, ImageFormat.Png);
            using (var bin = new BinaryWriter(icos))
            {
                //写图标头部
                bin.Write((short)0);           //0-1保留
                bin.Write((short)1);           //2-3文件类型。1=图标, 2=光标
                bin.Write((short)1);           //4-5图像数量（图标可以包含多个图像）

                bin.Write((byte)image.Width);  //6图标宽度
                bin.Write((byte)image.Height); //7图标高度
                bin.Write((byte)0);            //8颜色数（若像素位深>=8，填0。这是显然的，达到8bpp的颜色数最少是256，byte不够表示）
                bin.Write((byte)0);            //9保留。必须为0
                bin.Write((short)0);           //10-11调色板
                bin.Write((short)32);          //12-13位深
                bin.Write((int)msImg.Length);  //14-17位图数据大小
                bin.Write(22);                 //18-21位图数据起始字节

                //写图像数据
                bin.Write(msImg.ToArray());

                bin.Flush();
                bin.Seek(0, SeekOrigin.Begin);
                bin.Close();
            }


        }
    }
}
