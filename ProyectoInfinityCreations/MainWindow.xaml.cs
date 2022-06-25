using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Input;
namespace ProyectoInfinityCreations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtBlock.BringIntoView();
        }

        private void ButtonCerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BotonMinimize_Click(object sender, RoutedEventArgs e)
        {
            VentanaMain.WindowState = WindowState.Minimized;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlock.Text = "";
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (contraseña.Password == "")
            {
                txtBlock.Text = "Contraseña";
            }
            else
            {
                txtBlock.Text = "";
            }
        }

        private void txtBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            contraseña.Focus();
            txtBlock.Text = "";
        }

        private void contraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (contraseña.Password != "")
            {
                txtBlock.Text = "";
            }
            else {
                txtBlock.Text = "Contraseña";
            }
        }

        private void txtBlockusuario_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            usuario.Focus();
            txtBlockusuario.Text = "";
        }

        private void usuario_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlockusuario.Text = "";
        }

        private void usuario_LostFocus(object sender, RoutedEventArgs e)
        {
            if (usuario.Text == "")
            {
                txtBlockusuario.Text = "Usuario";
            }
            else {
                txtBlockusuario.Text = "";
            }
        }

        private void usuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (usuario.Text != "")
            {
                txtBlockusuario.Text = "";
            }
            else
            {
                txtBlockusuario.Text = "Usuario";
            }
        }

        private void contraseña_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BD.Conexion conexion = new BD.Conexion();

            bool verify = conexion.VerifyUser("SELECT usuario,contraseña FROM usuario where usuario= '" + usuario.Text + "' and contraseña= '" + contraseña.Password + "'");

            if (verify == true)
            {

                MessageBox.Show("Se ha iniciado sesion exitosamente!");
                Views.Lobby hola = new Views.Lobby();
                hola.Show();
                this.Hide();
            }
            else {

                MessageBox.Show("Usuario no existe!");
            }

            usuario.Text = "";
            contraseña.Password = "";

        }
}   }
