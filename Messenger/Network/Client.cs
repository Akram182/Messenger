using Messenger.MVVM.DataBase;
using Messenger.MVVM.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Messenger.Network
{
    public class Client
    {
        public string JwtToken { get; set; }
        public Client(User user)
        {
            using (TcpClient client = new TcpClient())
            {
                client.Connect("127.0.0.1", 8000);
                NetworkStream stream = client.GetStream();

                var message = new 
                { 
                    type =  "login",
                    login = user.Login,
                    password = user.Password
                };


                while (true)
                {
                    string json = JsonSerializer.Serialize(message);//Перевод в json
                    byte[] data = Encoding.UTF8.GetBytes(json); //Перевод в байти для отправки чере сеть
                    stream.Write(data, 0, data.Length);//Отправка 


                    byte[] buffer = new byte[512];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        JwtToken = Encoding.UTF8.GetString(buffer);
                        break;
                    }
                }
            }
        }
    }
}