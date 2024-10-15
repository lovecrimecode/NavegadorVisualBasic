using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class MiNavegador : Form
    {
        public MiNavegador()
        {
            InitializeComponent();
        }
        private void textBoxURL_TextChanged(object sender, EventArgs e)
        {

        }

        private void SetWatermark()
        {
            textBoxURL.Text = "Escribe la URL aquí";
            textBoxURL.ForeColor = System.Drawing.Color.Gray; 
        }

        private void textBoxURL_Enter(object sender, EventArgs e)
        {
            if (textBoxURL.Text == "Escribe la URL aquí")
            {
                textBoxURL.Text = ""; 
                textBoxURL.ForeColor = System.Drawing.Color.Black; 
            }
        }

        private void textBoxURL_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxURL.Text))
            {
                SetWatermark();
            }
        }
        private void buttonGo_Click(object sender, EventArgs e)
        {
            string url = textBoxURL.Text;
            try
            {
                webBrowser1.Navigate(url);
            }
            catch (UriFormatException)
            {
                MessageBox.Show("La URL ingresada no es válida. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private string homeUrl = "https://www.google.com";
        private void buttonHome_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(new Uri(homeUrl));
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack)
            {
                webBrowser1.GoBack();
            }
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward)
            {
                webBrowser1.GoForward();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }
    }
}
