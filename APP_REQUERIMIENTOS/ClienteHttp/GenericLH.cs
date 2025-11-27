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


   public static async Task<Respuesta> Delete(string url)
        {
            HttpClient cliente = new HttpClient();
            Respuesta res = new Respuesta();
            try
            {
                var response = await cliente.DeleteAsync(url);


                if (!response.IsSuccessStatusCode) return new Respuesta { codigo = 0 };
                else
                {
                    //int respuesta = int.Parse(await response.Content.ReadAsStringAsync());
                    var result = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<Respuesta>(result);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return res;
        }

            //Retorne la data
   public static async Task<Respuesta> GetAll<M>(string url, M obj)
    {
        HttpClient cliente = new HttpClient();
        Respuesta res = new Respuesta();
        //var rpta = await cliente.GetAsync(url);
        try
        {
            var cadena = JsonConvert.SerializeObject(obj);
            var body = new StringContent(cadena, Encoding.UTF8, "application/json");
              
            var rpta = await cliente.PostAsync(url, body);
                

                      
            //var rpta = await cliente.GetAsync(url);
            if (!rpta.IsSuccessStatusCode) return new Respuesta { codigo = 0 };
            else
            {
                //Como String
                var result = await rpta.Content.ReadAsStringAsync();
                //List<T> l = JsonConvert.DeserializeObject<List<L>>(result);
                res = JsonConvert.DeserializeObject<Respuesta>(result);
                    
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return res;


}


    public static async Task<Respuesta> Get(string url)
    {
        HttpClient cliente = new HttpClient();
        Respuesta res = new Respuesta();
        var rpta = await cliente.GetAsync(url);

        //Como String
       // var result = await rpta.Content.ReadAsStringAsync();
        if (!rpta.IsSuccessStatusCode) return new Respuesta { codigo = 0 };
        else
        {
            //Como String
            var result = await rpta.Content.ReadAsStringAsync();
            //List<T> l = JsonConvert.DeserializeObject<List<L>>(result);
            res = JsonConvert.DeserializeObject<Respuesta>(result);

        }

            return res;

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
            throw new Exception(ex.Message);
        }
        return res;


}

        public static async Task<Respuesta> PostFile<T>(byte[] imgmedia,string extension, string url,T obj)
        {
            HttpClient cliente = new HttpClient();
            Respuesta res = new Respuesta();
            var content = new MultipartFormDataContent();

            var cadena = JsonConvert.SerializeObject(obj);
            content.Add(new StringContent(cadena, Encoding.UTF8, "application/json"), "objetojson");
            if (imgmedia != null)
            {
                content.Add(new ByteArrayContent(imgmedia), "fotobit", $"cliente{extension}");

            }

            //var body = new StringContent(cadena, Encoding.UTF8, "application/json");

            try
            {
                var response = await cliente.PostAsync(url, content);
                if (!response.IsSuccessStatusCode) return new Respuesta { codigo = 0 };
                else
                {
                    
                   
                    var result = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<Respuesta>(result);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return res;

        }
        public static async Task<Respuesta> Put<T>(string url, T obj)
       {
            HttpClient cliente = new HttpClient();
            Respuesta res = new Respuesta();
            var cadena = JsonConvert.SerializeObject(obj);
            var body = new StringContent(cadena, Encoding.UTF8, "application/json");

            try
            {
                var response = await cliente.PutAsync(url, body);
                if (!response.IsSuccessStatusCode) return new Respuesta { codigo = 0 };
                else
                {
                    //int respuesta = int.Parse(await response.Content.ReadAsStringAsync());
                    var result = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<Respuesta>(result);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return res;


     }






    }
    
}
