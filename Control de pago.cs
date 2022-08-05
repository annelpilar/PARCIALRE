using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Control_de_pago : Form
    {
        double sueldo;
        int cPersonal, cComision;
        double aPersonal, aComision;

        int cVentas, cMarketing, cLogistica, cPrestamos;
        double aVentas, aMarketing, aLogistica, aPrestamos;

        DateTime Fecha;
        

        private void button5_Click(object sender, EventArgs e)
        {

        }

     

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Esta seguro de salir?", "Pago",
               MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (r == DialogResult.Yes) this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //condicion seleccionada

            string condicion = comboBox2.Text;

            //asignacion de sueldo de acorde a la condicion

            if (condicion == "Personal") sueldo = 2500;
            if (condicion == "Comision") sueldo = 1100;

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Captura de los datos

            string empleado = txtEmpleado.Text;
           // string hijos = txtHijos.Text;
            string area = comboBox1.Text;
            string condicion = comboBox2.Text;

            // Conteo y acumulacion

            switch (condicion)
            {
                case "Jefe": cPersonal++; aPersonal += sueldo; break;
                case "Comision": cComision++; aComision += sueldo; break;
            }

            switch (area)
            {
                case "Ventas": cVentas++; aVentas += sueldo; break;
                case "Marketing": cMarketing++; aMarketing += sueldo; break;
                case "Logistica": cLogistica++; aLogistica += sueldo; break;
                case "Prestamos": cPrestamos++; aPrestamos += sueldo; break;

            }

            // Realizando Calculo

            double descuento = 0;
            double asignacion = 0;
            double movilidad = 0;
            int hijos = 0;
             

            if (sueldo > 2500) descuento = (sueldo * 17) / 100; 
            if (sueldo > 1100) descuento = (sueldo * 17) / 100;

            
            asignacion = hijos*20;

            if (sueldo > 2500) movilidad = (sueldo * 10) / 100;
            if (sueldo > 1100) movilidad = (sueldo * 10) / 100;

            double neto = sueldo + movilidad + asignacion - descuento;

            // imprimiendo los resultados

            ListViewItem fila = new ListViewItem(empleado);
            fila.SubItems.Add(Convert.ToString(hijos));
            fila.SubItems.Add(area);
            fila.SubItems.Add(condicion);
            fila.SubItems.Add(Fecha.ToString("d"));
            fila.SubItems.Add(sueldo.ToString("C"));
            fila.SubItems.Add(Convert.ToString(movilidad));
            fila.SubItems.Add(asignacion.ToString("C"));
            fila.SubItems.Add(descuento.ToString("C"));
            fila.SubItems.Add(neto.ToString("C"));

            listView1.Items.Add(fila);

            // Imprimir estadisticas
            listView2.Items.Clear();
            string[] elementosFila = new string[4];
            ListViewItem row;

            //impresion de los datos de Ventas
            elementosFila[0] = "Ventas";
            elementosFila[1] = cVentas.ToString();
            elementosFila[2] = aVentas.ToString("C");
            row = new ListViewItem(elementosFila);
            listView2.Items.Add(row);

            //impresion de los datos de Marketing
            elementosFila[0] = "Marketing";
            elementosFila[1] = cMarketing.ToString();
            elementosFila[2] = aMarketing.ToString("C");
            row = new ListViewItem(elementosFila);
            listView2.Items.Add(row);

            //impresion de los datos de lOGISTICA
            elementosFila[0] = "Logistica";
            elementosFila[1] = cLogistica.ToString();
            elementosFila[2] = aLogistica.ToString("C");
            row = new ListViewItem(elementosFila);
            listView2.Items.Add(row);

            //impresion de los datos de prestamos
            elementosFila[0] = "Prestamos";
            elementosFila[1] = cPrestamos.ToString();
            elementosFila[2] = aPrestamos.ToString("C");
            row = new ListViewItem(elementosFila);
            listView2.Items.Add(row);
        }

       

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void fecha_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void Control_de_pago_Load(object sender, EventArgs e)
        {

        }

        public Control_de_pago()
        {
            InitializeComponent();
        }

        private void txtEmpleado_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
