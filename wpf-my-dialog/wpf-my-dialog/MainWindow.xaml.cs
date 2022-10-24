using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using wpf_my_dialog.Views;

namespace wpf_my_dialog
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FirstDialogWindow _firstDialogWindow;
        public MainWindow()
        {
            
        }
        public MainWindow(FirstDialogWindow _firstDialogWindow)
        {
            InitializeComponent();
            this._firstDialogWindow = _firstDialogWindow;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void YNC_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Yes, No, Cancel", "", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.OK:
                    {
                        dialogResultText.Text = "Ok";
                        break;
                    }
                case MessageBoxResult.Cancel:
                    {
                        dialogResultText.Text = "Cancel";
                    }
                    break;
            }
        }

        private void ARI_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Abort, Retry, Ignore", "", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.OK:
                    {
                        dialogResultText.Text = "Ok";
                        break;
                    }
                case MessageBoxResult.Cancel:
                    {
                        dialogResultText.Text = "Cancel";
                    }
                    break;
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fileOpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            dialog.ShowDialog();
            var fileName = System.IO.Path.GetFileName(dialog.FileName);
            dialogResultText.Text = fileName;
        }

        private void customDialogButton_Click(object sender, RoutedEventArgs e)
        {
            FirstDialogWindow fdw = new FirstDialogWindow(this);
            _firstDialogWindow = fdw;
            fdw.ShowDialog();
           
        }

        private void whichOptionbutton_Click(object sender, RoutedEventArgs e)
        {
           
            if (_firstDialogWindow.Option1.IsChecked == true)
            {
                dialogResultText.Text = "Option 1";
            }
            else if (_firstDialogWindow.Option2.IsChecked == true)
            {
                dialogResultText.Text = "Option 2";
            }
            else if (_firstDialogWindow.Option3.IsChecked == true)
            {
                dialogResultText.Text = "Option 3";
            }
            else if (_firstDialogWindow.Option4.IsChecked == true)
            {
                dialogResultText.Text = "Option 4";
            }
            else { dialogResultText.Text = "Option not found"; }

        }
    }
}
