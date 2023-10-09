using PropuestasLegislativas.Datos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace PropuestasLegislativas
{
    public partial class _Default : Page
    {
        private Propuesta nPropuesta = new Propuesta();
        private Canton _cantones = new Canton();
        List<string> cantones;
        private string _provincia;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Btn_limpiar_Click(object sender, EventArgs e)
        {           
            LimpiarDatos(false);
        }

        protected void Btn_guardar_Click(object sender, EventArgs e)
        {
            bool pageReload = false;
            var sb = new List<string>();
            ValidarDatos valDatos = new ValidarDatos();

            // - Identificación -
            nPropuesta.TipoId = Ddl_identificacion.Text.Trim().ToUpper();

            if (Regex.IsMatch(txt_identificacion.Text.Trim().ToUpper(), "^[0-9]+$"))
            {
                nPropuesta.Cedula = double.Parse(txt_identificacion.Text.Trim().ToUpper());
            }
            else 
            {
                Response.Write("<script language=javascript>alert('Cédula debe ser solo Numérico');</script>");
            }
            
            nPropuesta.Nombre = txt_nombre.Text.Trim().ToUpper();
            nPropuesta.Apellido = txt_apellido.Text.Trim().ToUpper();

            if (Regex.IsMatch(txt_telefono.Text.Trim().ToUpper(), "^[0-9]+$"))
            {
                nPropuesta.Telefono = int.Parse(txt_telefono.Text.Trim().ToUpper());
            }
            else
            {
                Response.Write("<script language=javascript>alert('Teléfono debe ser solo Numérico');</script>");
            }
            
            nPropuesta.Correo = txt_email.Text.Trim().ToUpper();
            nPropuesta.Provincia = Ddl_provincia.Text.Trim().ToUpper();
            nPropuesta.Canton = Ddl_canton.Text.Trim().ToUpper();
            nPropuesta.Descripcion = txt_propuesta.Text.Trim().ToUpper();

            //***********************************************
            // antes de guardar validar los datos en BackEnd
            //***********************************************                    

            sb = valDatos.ValidarFormulario(nPropuesta);

            if (sb.Count > 0) { 
                BulletedList1.DataSource = sb;
                BulletedList1.DataBind();
            }
            else
            {
                GuardarDatos();
                
                Response.Write("<script language=javascript>alert('PROPUESTA LEGISLATIVA GUARDADA CORRECTAMENTE');</script>");
                pageReload = true;              
                LimpiarDatos(pageReload);
                BulletedList1.DataSource="";
                BulletedList1.DataBind();
            }

           
            

        }

        private void GuardarDatos()
        {
            if (File.Exists(Server.MapPath("Datos\\propuesta.xml")) == false)
            {
                XDocument documento = new XDocument(new XDeclaration("1.0", "utf-8", null));
                XElement nodoRaiz = new XElement("propuestas");
                documento.Add(nodoRaiz);

                XElement propuesta = new XElement("Propuesta");
                propuesta.Add(new XElement("Cedula", nPropuesta.Cedula));
                propuesta.Add(new XElement("Nombre", nPropuesta.Nombre));
                propuesta.Add(new XElement("Apellido", nPropuesta.Apellido));
                propuesta.Add(new XElement("Telefono", nPropuesta.Telefono));
                propuesta.Add(new XElement("Email", nPropuesta.Correo));
                propuesta.Add(new XElement("Provincia", nPropuesta.Provincia));
                propuesta.Add(new XElement("Canton", nPropuesta.Canton));
                propuesta.Add(new XElement("Descripcion", nPropuesta.Descripcion));
                nodoRaiz.Add(propuesta);

                documento.Save(Server.MapPath("Datos\\propuesta.xml"));                
            }
            else
            {
                XDocument doc = XDocument.Load(Server.MapPath("Datos\\propuesta.xml"));
                XElement propuestas = doc.Element("propuestas");

                propuestas.Add(new XElement("propuesta",
                   new XElement("Cedula", nPropuesta.Cedula),
                   new XElement("Nombre", nPropuesta.Nombre),
                   new XElement("Apellido", nPropuesta.Apellido),
                   new XElement("Telefono", nPropuesta.Telefono),
                   new XElement("Email", nPropuesta.Correo),
                   new XElement("Provincia", nPropuesta.Provincia),
                   new XElement("Canton", nPropuesta.Canton),
                   new XElement("Descripcion", nPropuesta.Descripcion)));
                doc.Save(Server.MapPath("Datos\\propuesta.xml"));                
            }        
        }

        private void LimpiarDatos(bool _pageReload)
        {
            string msg = "SE BORRARÁN TODOS LOS DATOS DEL FORMULARIO";
            if (_pageReload)
            {                
                Ddl_identificacion.SelectedIndex = 0;
                txt_identificacion.Text = "";
                txt_nombre.Text = "";
                txt_apellido.Text = "";
                txt_telefono.Text = "";
                txt_email.Text = "";
                Ddl_provincia.SelectedIndex = 0;
                Ddl_canton.Items.Clear();
                Ddl_canton.Items.Add("- Cantón -");
                txt_propuesta.Text = "";
            }
            else {
                ScriptManager.RegisterStartupScript(
                    this, this.GetType(),
                    "alert",
                    "alert('" + msg + "');window.location = 'Default.aspx';", true);
            }                
        }
     
        protected void Ddl_provincia_SelectedIndexChanged(object sender,EventArgs e)
        {
            _provincia = Ddl_provincia.SelectedValue;
            Ddl_canton.Items.Clear();

            if (Ddl_provincia.SelectedValue.Equals("- Provincia -"))
            {
                Ddl_canton.Items.Add("- Cantón -");
            }
            else
            {
                cantones = _cantones.GetCantones(_provincia);

                foreach (var canton in cantones)
                {
                    Ddl_canton.Items.Add(canton);
                }
            }
                
        }       
    }
}