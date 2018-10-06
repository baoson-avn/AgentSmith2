using MahApps.Metro.Controls;

namespace AvnAgent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        //View Model for Mainwindow
        MainWindowViewModel viewModel = new MainWindowViewModel();
    
        //The Constructor
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
