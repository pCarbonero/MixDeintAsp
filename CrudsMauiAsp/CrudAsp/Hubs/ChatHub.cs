using Microsoft.AspNetCore.SignalR;
using CrudAsp.Models;


namespace CrudAsp.Hubs
{
    public class ChatHub: Hub
    {
        public Task JoinRoom(string roomName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }

        public Task LeaveRoom(string roomName)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }

        public async Task SendMessage(clsMensajeUsuario mensaje)
        {
            await Clients.Group(mensaje.Grupo).SendAsync("ReceiveMessage", mensaje);
        }
    }
}
