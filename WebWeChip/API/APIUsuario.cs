using EntitiesWeChip;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebWeChip.API
{
    public static class APIUsuario
    {
        public static Usuario ApiGet(int id)
        {
            var request = new RestRequest("Buscar?id=" + id, Method.GET);

            return JsonConvert.DeserializeObject<Usuario>(RestClient().Execute(request).Content);
        }
        public static List<Usuario> ApiGetAll()
        {
            var request = new RestRequest("BuscarLista", Method.GET);

            var queryResult = RestClient().Execute(request);

            return JsonConvert.DeserializeObject<List<Usuario>>(queryResult.Content);
        }

        public static void ApiPost(Usuario dados)
        {
            var request = new RestRequest("Cadastrar", Method.POST);
            request.AddJsonBody(dados);
            RestClient().Execute(request);
        }
        public static bool ApiPostEdit(Usuario dados)
        {
            var request = new RestRequest("Atualizar", Method.POST);
            request.AddJsonBody(dados);
            return RestClient().Execute(request).IsSuccessful == true ? true : false;
        }
     
        private static RestClient RestClient()
        {
            return new RestClient("https://localhost:44329/api/Usuario/");
        }
    }
}
