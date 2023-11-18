using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WhiteSpace_removal
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Topmost = true;
        }

        private void btnProceed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Proceed();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Proceed()
        {
            try
            {
                string strText = tbxIN.Text;
                tbxOUT.Text = string.Concat(strText.Where(s => !Char.IsWhiteSpace(s)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CopyToClipboard()
        {
            try
            {
                if (tbxOUT.Text != String.Empty)
                {
                    Clipboard.SetText(tbxOUT.Text);
                    lblFeedback.Content = "Skopiowano do schowka!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Clear()
        {
            try
            {
                tbxIN.Text = String.Empty;
                tbxOUT.Text = String.Empty;
                lblFeedback.Content = "PrzemyDev 2023";
                tbxIN.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearClipboard()
        {
            try
            {
                Clipboard.Clear();
                lblFeedback.Content = "Schowek wyczyszczono!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCopyToClipboard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CopyToClipboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClearClipboard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearClipboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void btnPin_Click(object sender, RoutedEventArgs e)
        {
            WindowPinUnpin();
        }
        private void btnMinimalize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void btnExitApp_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }


        private void Window_Activated(object sender, EventArgs e)
        {
            ellIsFocusedIndicator.Fill = Brushes.MediumSpringGreen;
            tbxIN.Focus();
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            ellIsFocusedIndicator.Fill = Brushes.Red;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.F1)
                {
                    Proceed();
                }

                if (e.Key == Key.F2)
                {
                    CopyToClipboard();
                }

                if (e.Key == Key.F3)
                {
                    Clear();
                }

                if (e.Key == Key.F4)
                {
                    ClearClipboard();
                }
                if (e.Key == Key.F5)
                {
                    WindowPinUnpin();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        private void WindowPinUnpin()
        {
            try
            {
                if (this.Topmost)
                {
                    this.Topmost = false;
                    btnPin.Tag = "Strikethrough";
                }

                else
                {
                    this.Topmost = true;
                    btnPin.Tag = "null";
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            } 
        }
    }
}
