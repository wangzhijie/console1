using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;  

namespace ConsoleApplication1
{
    class Program
    {
        
        private static byte[] result = new byte[1024];  
        private static int myProt = 4193;   //端口  
        static Socket serverSocket;  
        static void Main(string[] args)  
        {  
            //服务器IP地址  
            IPAddress ip = IPAddress.Parse("127.0.0.1");  
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  
            serverSocket.Bind(new IPEndPoint(ip, myProt));  //绑定IP地址：端口  
            serverSocket.Listen(20);    //设定最多10个排队连接请求  
            Console.WriteLine("启动监听{0}成功", serverSocket.LocalEndPoint.ToString());  
            //通过Clientsoket发送数据  
            Thread myThread = new Thread(ListenClientConnect);  
            myThread.Start();  
            Console.ReadLine();  
        }  
  
        /// <summary>  
        /// 监听客户端连接  
        /// </summary>  
        private static void ListenClientConnect()  
        {  
            while (true)  
            {  
                Socket clientSocket = serverSocket.Accept();  
                //clientSocket.Send(Encoding.ASCII.GetBytes("Server Say Hello"));  
                Thread receiveThread = new Thread(ReceiveMessage);  
                receiveThread.Start(clientSocket);  
            }  
        }  
  
        /// <summary>  
        /// 接收消息  
        /// </summary>  
        /// <param name="clientSocket"></param>  
        private static void ReceiveMessage(object clientSocket)  
        {  
            Socket myClientSocket = (Socket)clientSocket;  
            while (true)  
            {  
                try  
                {  
                    //通过clientSocket接收数据  
                    int receiveNumber = myClientSocket.Receive(result,result.Length,0);
                    string s="";
                    s+=Encoding.ASCII.GetString(result, 0, receiveNumber);
                    Console.WriteLine(s);
                  //  Console.WriteLine("接收客户端{0}消息{1}", myClientSocket.RemoteEndPoint.ToString(), Encoding.ASCII.GetString(result, 0, receiveNumber));
                    
                    switch(s){
                        case "Q100": myClientSocket.Send(Encoding.ASCII.GetBytes("100")); break;
                        case "Q101": myClientSocket.Send(Encoding.ASCII.GetBytes("101")); break;
                        case "Q102": myClientSocket.Send(Encoding.ASCII.GetBytes("102")); break;
                        case "Q104": myClientSocket.Send(Encoding.ASCII.GetBytes("104")); break;
                        case "Q200": myClientSocket.Send(Encoding.ASCII.GetBytes("200")); break;
                        case "Q201": myClientSocket.Send(Encoding.ASCII.GetBytes("201")); break;
                        case "Q300": myClientSocket.Send(Encoding.ASCII.GetBytes("300")); break;
                        case "Q301": myClientSocket.Send(Encoding.ASCII.GetBytes("301")); break;
                        case "Q303": myClientSocket.Send(Encoding.ASCII.GetBytes("303")); break;
                        case "Q304": myClientSocket.Send(Encoding.ASCII.GetBytes("304")); break;
                        case "Q402": myClientSocket.Send(Encoding.ASCII.GetBytes("402")); break;
                        case "Q403": myClientSocket.Send(Encoding.ASCII.GetBytes("403sss")); break;
                        case "Q500": myClientSocket.Send(Encoding.ASCII.GetBytes("500")); break;
                        default: myClientSocket.Send(Encoding.ASCII.GetBytes("-1")); break;
                    }
                }  
                catch(Exception ex)  
                {  
                    Console.WriteLine(ex.Message);  
                    myClientSocket.Shutdown(SocketShutdown.Both);  
                    myClientSocket.Close();  
                    break;  
                }  
            }  
        }
        /*static int alarmNum = 4;
        public static List<long> alarmNo=new List<long>();
        public static   List<short> alarmType=new List<short>();
        public static List<short> alarmAxis=new List<short>();
        public static List<short> alarmMsg=new List<short>();
        public static string alarmStr = "";
        public static void init()
        {
            for (int i = 0; i < alarmNum;i++ )
            {
                alarmNo.Add(i);
                alarmType.Add((short)(i));
                alarmAxis.Add((short)(i));
                alarmMsg.Add((short)(i));
            }
        }
        public static void alarmDatabase(int DepartmentID, int MachineID)
        {
            
            //每次采集完成的时间
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            try{
                
                for(int i=0;i<alarmNum;i++){
                    alarmStr =  alarmStr+"," +"(" + DepartmentID + "," + MachineID + "," + alarmNo[i] + "," + alarmType[i]+ "," + alarmAxis[i] + "," + alarmMsg[i] + "," + time + ")";
                }
                alarmStr = alarmStr.Substring(1);
                
            }catch(Exception e){
               
            }
           
            
        }
        static void Main(string[] args)
        {
            init();
            alarmDatabase(1,1);
            Console.WriteLine(alarmStr);
            
            Console.Read();
   
        } */
    }  
}  
    

