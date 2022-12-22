using System.Net;
using System.Net.Sockets;
using System.Text;
// Create new TCP/IP socket for remote access
IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);

// Connect To the Remote Access Server
socket.Connect(iPEndPoint);

// Send Command To server
string command = "Connected To are first RAT server!";
byte[] commandBuffer = Encoding.ASCII.GetBytes(command);
socket.Send(commandBuffer);

// Receive Response From Server
byte[] responseBuffer = new byte[1024];
int recivedBytes = socket.Receive(responseBuffer);
string response = Encoding.ASCII.GetString(responseBuffer, 0, recivedBytes);

// Diplay The Response
Console.WriteLine("response");
Console.ReadLine();

//Close The Socket
socket.Close();
