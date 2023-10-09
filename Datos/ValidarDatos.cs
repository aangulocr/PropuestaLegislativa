using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace PropuestasLegislativas.Datos
{
    public class ValidarDatos
    {
        //private StringBuilder sValidacion = new StringBuilder();
        private List<string> sValidacion = new List<string>();

        public List<string> ValidarFormulario(Propuesta p)
        {
            //char primerDigito = p.Cedula.ToString()[0];
            int primerDigito = int.Parse(p.Cedula.ToString()[0].ToString());
            int cedulaLength = p.Cedula.ToString().Length;

            //Validación de la Cédula
            if (p.TipoId.Equals("CÉDULA NACIONAL")) {

                if (primerDigito >= 1 && primerDigito <= 7)
                {
                    if (p.Cedula < 100000000 || p.Cedula > 799999999)
                    {
                        sValidacion.Add("Verificar el Formato de Cédula Nacional Ingresada, ejemplo de 9 Números: 102580369");
                       
                     }
                }
                else {
                    sValidacion.Add("Verificar el Formato de Cédula Nacional Ingresada, Primer Número debe estar entre 1 a 7");
                    
                }
            }
            else if (p.TipoId.Equals("CÉDULA RESIDENTE"))
            {                
                if( cedulaLength != 12)
                {
                    sValidacion.Add("Verificar el Formato de Cédula Residente Ingresada, Debe ser de 12 números");
                    
                }
                else { 

                    //Cédula DIMEX
                    if(primerDigito == 1) { 
                                if (p.Cedula < 100000000000 || p.Cedula > 199999999999)
                                {
                                    sValidacion.Add("Verificar el Formato de Cédula Residente Ingresada, DIMEX Inicia con 1 + 11 números");                        
                                    
                                }
                    }

                    //Cédula DIMEX-DIDI
                    else if(primerDigito == 5)
                    {
                        if (p.Cedula < 500000000000 || p.Cedula > 599999999999)
                        {
                            sValidacion.Add("Verificar el Formato de Cédula Residente Ingresada, DIMEX-DIDI Inicia con 5 + 11 números");
                            
                        }
                    }else
                    {
                        sValidacion.Add("Formato de Cédula Residente Ingresado es Incorrecto Debe ser de 12 Números e iniciar con 1 o 5");                        
                        
                    }                    
                }
            }
            else if(p.TipoId.Equals("- Identificación -"))
              {
                    sValidacion.Add("Seleccionar el Tipo de Cédula");                    
                    
             }


            //Validación de la Nombre y Apellido
            //Nombre
            if (p.Nombre.Length > 2 && p.Nombre.Length < 21)
            {
                if (!Regex.IsMatch(p.Nombre, "^[^0-9]+$"))
                {
                    sValidacion.Add("Nombre debe No Tener Números");                    
                    
                }                
            }
            else
            {
                sValidacion.Add("Nombre debe tener de 3 a 20 caracteres");               
                
            }

            // Apellido
            if (p.Apellido.Length > 2 && p.Apellido.Length < 21)
            {
                if (!Regex.IsMatch(p.Apellido, "^[^0-9]+$"))
                {
                    sValidacion.Add("Apellido No debe Tener Números");                   
                    
                }

            }
            else
            {
                sValidacion.Add("Apellido debe tener de 3 a 20 caracteres");               
                
            }

            //Validación de Telefono
            if (p.Telefono < 10000000 || p.Telefono > 89999999)
            {
                sValidacion.Add("Formato de Número Telefónico Incorrecto: ejemplo de 8 números: 12345678");                
                
            }

           //Validación de Email                   
           string strReg = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";          
           if (!Regex.IsMatch(p.Correo, strReg))       
           {
                sValidacion.Add("Formato Correo Electrónico Incorrecto");
                
           }

           //Validación de Descripción de Propuesta
           if(p.Descripcion.Length < 50 || p.Descripcion.Length > 200)
            {
                sValidacion.Add("La Propuesta debe Tener entre 50 y 200 Caracteres");
                
            }

            //Validación de - Provincia -            
            if (p.Provincia.Equals("- PROVINCIA -")){
                sValidacion.Add("Debe Seleccionar una Provincia");
                
            }

            //Validación de - Cantón -
            if (p.Canton.Equals("- CANTÓN -"))
            {
                sValidacion.Add("Debe Seleccionar un Cantón");
                
            }


            return sValidacion;
        }

    }
}