using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EasyTools.ImageTool
{
    public class FileSplit : IDisposable
    {
        FileStream fs = null;

        public FileSplit(string path)
        {
            // TODO: Complete member initialization
            fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }
        public FileSplit()
        {

        }

        public void Split(int size, string savePath)
        {
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);
            string safeName = savePath.Split('\\')[savePath.Split('\\').Length - 1];
            byte[] buff = new byte[1024];
            int po = 0;
            int fileIndex = 0;
            FileStream fsW = File.Create(savePath + "\\" + safeName + fileIndex);
            while (true)
            {
                int rl = fs.Read(buff, 0, 1024);
                if (rl == 0)
                {
                    fsW.Flush();
                    fsW.Close();
                    break;
                }
                if (po + rl < size)
                {
                    fsW.Write(buff, 0, rl);
                    po += rl;
                }
                else if (po + rl == size)
                {
                    fsW.Write(buff, 0, rl);
                    fsW.Flush();
                    fsW.Close();
                    fileIndex++;
                    fsW = File.Create(savePath + "\\" + safeName + fileIndex);
                    po = 0;
                }
                else
                {
                    fsW.Write(buff, 0, size - po);
                    fsW.Flush();
                    fsW.Close();
                    fileIndex++;
                    fsW = File.Create(savePath + "\\" + safeName + fileIndex);
                    fsW.Write(buff, size - po, rl - size + po);
                    po = rl - size + po;
                }

            }
        }

        public void Connect(string from, string to)
        {
            FileStream fs = File.Create(to);
            string safeName = from.Split('\\')[from.Split('\\').Length - 1];
            int index=0;
            string filename = from + "\\" + safeName + index;
            byte[] bf =new byte[1024];
            while (File.Exists(filename))
            {
                FileStream r = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                while (true)
                {
                    int rl = r.Read(bf, 0, 1024);
                    if (rl == 0)
                    {
                        break;
                    }
                    fs.Write(bf, 0, rl);

                }
                r.Close();
                index++;
                filename = from + "\\" + safeName + index;
            }
            fs.Flush();
            fs.Close();
        }

        public void Dispose()
        {
            if (fs != null)
                fs.Dispose();

        }
    }
}
