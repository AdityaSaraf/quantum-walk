using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Threading.Tasks;

using System.IO;

using System.Globalization;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using LiveCharts.Configurations;
using LiveCharts.Charts;


namespace GraphWalk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public SeriesCollection SeriesCollection { get; set; }
        private double _maxValue;
        public Double MaxValue { get { return _maxValue; } set { _maxValue = value;  OnPropertyChanged("MaxValue"); } }
        public ChartValues<ObservableValue> Vals { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            Vals = new ChartValues<ObservableValue>();
            for(int i = 0; i < 64; i++)
            {
                Vals.Add(new ObservableValue(0.0));
            }
   


            var lineSeries = new LineSeries
            {
                Values = Vals,
                StrokeThickness = 2,
                Fill = Brushes.Transparent,
                PointGeometrySize = 5
            
            };

            SeriesCollection = new SeriesCollection();
            SeriesCollection.Add(lineSeries);
            MaxValue = 1.0;

            DataContext = this;
          

                    
            
        }

        private void Read()
        {
            ProcessStartInfo script = new ProcessStartInfo();
            script.FileName = "CMD.exe";
            script.RedirectStandardOutput = false;
            script.UseShellExecute = false;
            script.Arguments = "/c " + System.IO.Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\walk.bat";            
            Process p = Process.Start(script);
           
            
            p.WaitForExit();
            
            Console.WriteLine("Compiled");

            for (int i = 0; i <= 30; i++)
            {
                var path = System.IO.Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\QuantumWalk";
               // Console.WriteLine(System.IO.Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName);
                var dump = File.ReadAllLines(path+ $"\\step{i}.txt");
                dump = dump.Skip(1).ToArray();
                Dictionary<double, double> dict = ParseDumpFile(dump);
                foreach (var ind in dict.ToArray())
                {
                    Vals[(int)ind.Key].Value = dict[ind.Key];
                }

                if (MaxValue > .35)
                {
                    MaxValue -= 1.0 / 30.0;
                }
                Thread.Sleep(300);
            }

        }

        static Dictionary<double, double> ParseDumpFile(String[] dump)
        {
            Dictionary<double, double> dict = new Dictionary<double, double>();
            int offset = dump.Length / 2;
            for (int i = 0; i < dump.Length / 2; i++)
            {
                string line = dump[i];
                (double num, double prob) = ParseLine(line);
                string offsetLine = dump[i + offset];
                (double offsetNum, double offsetProb) = ParseLine(offsetLine);
                double finalProb = prob + offsetProb;
                if (finalProb < 0.0000005)
                {
                    finalProb = 0;
                }
                dict[num] = finalProb;
            }
            return dict;
        }

        static (double, double) ParseLine(String line)
        {
            string[] arr = line.Split('\t');
            double num = Int32.Parse(arr[0].Remove(arr[0].Length - 1));
            double prob = Double.Parse(arr[1], NumberStyles.Float);
            // need to square the amplitude to get the probability. this also ensures it's positive
            prob *= prob;
            return (num, prob);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void HWalk(object sender, RoutedEventArgs e)
        {
            MaxValue = 1;
            Task.Factory.StartNew(Read);
        }
        private void CWalk(object sender, RoutedEventArgs e)
        {
            MaxValue = 1;
        }
    }
}
