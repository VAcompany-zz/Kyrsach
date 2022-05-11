using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using Kyrsach.ViewModel;
using QRCoder;


namespace Kyrsach.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для Receive.xaml
    /// </summary>
    public partial class Receive : Page
    {
        public Receive(WalletViewModel currency)
        {
            InitializeComponent();
            _currency = currency;
            QRcodeGenerate(App.Current.Resources["SaveLogin"].ToString());
        }
        private WalletViewModel _currency;
        public void QRcodeGenerate(string login)
        {
            QRCodeGenerator Qg = new QRCodeGenerator();
            QRCodeData qRCodeData = Qg.CreateQrCode(login, QRCodeGenerator.ECCLevel.M);
            QRCode qRCode = new QRCode(qRCodeData);
            Bitmap qrCodeImage = qRCode.GetGraphic(50);

            pictureBox.Source = BitmapToImageSourse(qrCodeImage);
        }
        private ImageSource BitmapToImageSourse(Bitmap bitmap)
        {
            using(MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }
        private void Close_Window(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ClipboardText(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(IDAddress.Text);
            
        }
    }
}
