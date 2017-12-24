using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TareaAbolBB
{
    public partial class Form1 : Form
    {
        ABB arbol = new ABB();
        NodoABB nodo;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            arbol.insertar(Int32.Parse(textBox1.Text));
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "PreORden" + arbol.preOrden(arbol.raiz)+ "\nInOrden" + arbol.inOrden(arbol.raiz)+
                "\nPostOrden" + arbol.postOrden(arbol.raiz);
        }

     
    }
}
