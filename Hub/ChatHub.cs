using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public class ChatHub : Hub
{
    public async Task EnviarMensagem(string usuario, string mensagem)
    {
        // Implemente lógica para processar a mensagem e enviar para os clientes
        await Clients.All.SendAsync("ReceberMensagem", usuario, mensagem);
    }
}
