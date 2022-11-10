namespace ConnectFourForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}













/*
using System;
using System.Windows.Forms;
using System.Drawing;

namespace FormsApplication
{
    class WindowsApp
    {
        static void Main()
        {
            Form SimpleForm = new FormsByHand();
            Application.Run(SimpleForm);
        }
    }
    public class FormsByHand : Form
    {
        private Button column1;
        public FormsByHand()
        {
            this.Text = "Forms By Hand";
            column1 = new Button();
            column1.Location = new Point(96, 112);
            column1.Size = new Size(72, 24);
            column1.Text = "Status";
            this.Controls.Add(column1);
            column1.Click += new EventHandler(column1_Click);
        }
        void column1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Up and Running");
        }
    }
}
*/