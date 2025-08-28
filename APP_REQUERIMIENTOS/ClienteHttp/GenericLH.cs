using Newtonsoft.Json;
using APP_REQUERIMIENTOS.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace APP_REQUERIMIENTOS.ClienteHttp
{
   
        public class GenericLH
        {


            public static async Task<int> Delete(string url)
            {
                HttpClient cliente = new HttpClient();

                var rpta = await cliente.DeleteAsync(url);
                if (!rpta.IsSuccessStatusCode) return 0;
                else
                {
                    //Cadena(1 -> Exitoso , 0->Error) ->int ""
                    var result = await rpta.Content.ReadAsStringAsync();
                    return int.Parse(result);
                }


            }

            //Retorne la data
            public static async Task<Respuesta> GetAll<M>(string url, M obj)
            {
                HttpClient cliente = new HttpClient();
                //var rpta = await cliente.GetAsync(url);

                var cadena = JsonConvert.SerializeObject(obj);
                var body = new StringContent(cadena, Encoding.UTF8, "application/json");
                var rpta = await cliente.PostAsync(url, body);
                if (!rpta.IsSuccessStatusCode) return new Respuesta { codigo = 0 };
                else
                {
                    //Como String
                    var result = await rpta.Content.ReadAsStringAsync();
                //List<T> l = JsonConvert.DeserializeObject<List<L>>(result);
                    Respuesta res = JsonConvert.DeserializeObject<Respuesta>(result);
                    return res;
                }

            }


            public static async Task<T> Get<T>(string url)
            {
                HttpClient cliente = new HttpClient();
                var rpta = await cliente.GetAsync(url);

                //Como String
                var result = await rpta.Content.ReadAsStringAsync();
                T l = JsonConvert.DeserializeObject<T>(result);
                return l;


            }

            public static async Task<Respuesta> Post<T>(string url, T obj)
            {
                HttpClient cliente = new HttpClient();
                Respuesta res= new Respuesta();
                var cadena = JsonConvert.SerializeObject(obj);
                var body = new StringContent(cadena, Encoding.UTF8, "application/json");
                
                try
                {
                    var response = await cliente.PostAsync(url, body);
                    if (!response.IsSuccessStatusCode) return new Respuesta { codigo = 0 };
                    else
                    {
                        //int respuesta = int.Parse(await response.Content.ReadAsStringAsync());
                        var result = await response.Content.ReadAsStringAsync();
                         res = JsonConvert.DeserializeObject<Respuesta>(result);
                        
                    }
                }
                catch(Exception ex)
                {

                }
                return res;


        }
          
           

         


        }
    
}
