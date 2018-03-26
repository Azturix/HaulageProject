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
using HypCoreLibrary.Structures.Matrix;
using System.IO;
using System.IO.Compression;
using HypCoreLibrary.IO.ZIP;
using HypCoreLibrary.Models.DataAbstract;
using HypCoreLibrary.Controller.Alpha;
using System.Threading;

namespace HaulageProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //List<DataUnitBase> dataList;

        Alpha60 alpha;


        public event Func<bool> Initiate;

        public MainWindow()
        {
            InitializeComponent();
            alpha = new Alpha60();
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;



            DataUnitBase<DefinitionFileBase> dataUnit = new DataUnitBase<DefinitionFileBase>("Hola");






        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {

        }
        private void ProcessCallback(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            var status = Initiate.Invoke();
        }

    }
}
