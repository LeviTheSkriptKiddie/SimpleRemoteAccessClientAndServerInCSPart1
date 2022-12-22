using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;


// Create New TCP/IP socket for Remote Access
IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 8080);
Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
socket.Bind(iPEndPoint);

// Listen for connection from Clients...

socket.Listen(10);
Socket clientSocket = socket.Accept();

// Recive data from the remote user

byte[] buffer = new byte[1024];
int recivedBytes = clientSocket.Receive(buffer);

// Process the recived data
string recivedData = Encoding.ASCII.GetString(buffer, 0,recivedBytes);

// Execute the recived command 
Console.WriteLine(recivedData);

//Send A response to the remote user
string response = "command Successfully Executed";
byte[] ResponseBuffer = Encoding.ASCII.GetBytes(response);
clientSocket.Send(ResponseBuffer);
Console.ReadLine();

// Close The server off
socket.Close();


