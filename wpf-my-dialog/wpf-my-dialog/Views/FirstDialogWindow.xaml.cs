using GalaSoft.MvvmLight.Command;
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
using System.Windows.Shapes;
namespace wpf_my_dialog.Views
{
    /// <summary>
    /// Логика взаимодействия для FirstDialogWindow.xaml
    /// </summary>
    public partial class FirstDialogWindow : Window
    {
        private MainWindow _mainWindow;
        public FirstDialogWindow(MainWindow _mainWindow)
        {
            InitializeComponent();

            this._mainWindow = _mainWindow;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void cancelDialogButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.OK:
                    {
                        try
                        {
                            Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        _mainWindow.dialogResultText.Text = "users choise :cancel -> ok";
                        break;
                    }
                case MessageBoxResult.Cancel:
                    {
                        _mainWindow.dialogResultText.Text = "users choise :cancel -> cancel";
                    }
                    break;
            }

           
        }

        private void okDialogButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.OK:
                    {
                        _mainWindow.whichOptionbutton.IsEnabled = true; 
                        _mainWindow.dialogResultText.Text = dialogTextbox.Text + " users choise ok -> ok";
                        Close();
                        break;
                    }
                case MessageBoxResult.Cancel:
                    {
                        _mainWindow.dialogResultText.Text = "users choise ok -> cancel";
                    }
                    break;
            }
           
        }

   
    }

}
