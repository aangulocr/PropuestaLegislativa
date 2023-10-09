using Newtonsoft.Json;
using System.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PropuestasLegislativas.Datos
{
    public class Provincia
    {
        public string provincia { get; set; }
        public List<string> cantones { get; set; }
    }

    public class Canton
    {
        private List<string> cantones = new List<string>();
        private List<Provincia> source = new List<Provincia>();       

        public List<string> GetCantones(string bProvincia)
        {
           
            string FileJson = HttpContext.Current.Server.MapPath(@"~/Datos/Provincias.json");
           

            using (StreamReader r = new StreamReader(FileJson))
            {
                string json = r.ReadToEnd();
                source = JsonConvert.DeserializeObject<List<Provincia>>(json);
                
            }

            foreach (var p in source)
            {
                if (p.provincia == bProvincia)
                {
                    Console.WriteLine(bProvincia);
                    foreach (var c in p.cantones)
                    {
                        Console.WriteLine($"\t{c}");
                        cantones.Add(c);
                    }

                    break;
                }
            }
            return cantones;
        }
    }
 }