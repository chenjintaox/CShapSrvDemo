using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;//引入系统IO

namespace CShapSrvDemo
{
    public partial class Service : ServiceBase
    {
        //trace文件名
        readonly string traceName = "CShapSrvDemo.log";
        
        //trace文件读写流
        FileStream fsTrace = null;
        StreamWriter sw = null;
        
        public Service()
        {
            InitializeComponent();
        }

        //服务启动
        protected override void OnStart(string[] args)
        {
            //服务器启动message写入trace
            fsTrace = new FileStream(traceName, FileMode.OpenOrCreate, FileAccess.Write);
            sw = new StreamWriter(fsTrace);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine("{0} CShapSrvDemo has started.", DateTime.Now.ToString());
            sw.Flush();  
        }

        //服务停止
        protected override void OnStop()
        {
            //服务器停止message写入trace
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine("{0} CShapSrvDemo has stopped.", DateTime.Now.ToString());
            sw.Flush();
            sw.Close();
            fsTrace.Close();
        }
    }
}
