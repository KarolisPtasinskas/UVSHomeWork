using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UVSHomeWork.Models;
using Timer = System.Windows.Forms.Timer;

namespace UVSHomeWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        readonly Random rnd = new();
        readonly Timer timer = new();
        const string connectionString = "Server=.;Database=UvsThreads;Trusted_Connection=True;Integrated Security=SSPI;";

        CancellationTokenSource _tokenSource;
        int threadNumber = 2;
        List<MainModelDto> mainModelDtos = new();

        private void btnStart_Click(object sender, EventArgs e)
        {
            _tokenSource = new CancellationTokenSource();
            var token = _tokenSource.Token;

            btnStart.Enabled = false;
            btnStop.Enabled = true;

            timer.Start();

            for (int i = 0; i < threadNumber; i++)
            {
                Task.Run(() =>
                {
                    GenerateModel(token);
                });
            };
        }

        private void tbSlider_Scroll(object sender, EventArgs e)
        {
            threadNumber = tbSlider.Value;
        }

        private async void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;

            _tokenSource.Cancel();
            _tokenSource.Dispose();

            await Task.Delay(3000);
            timer.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReloadData(sender, e);

            timer.Interval = (3 * 1000);
            timer.Tick += new EventHandler(ReloadData);
        }

        private void ReloadData(object sender, EventArgs e)
        {
            mainModelDtos = GetLastTwenty();

            if (mainModelDtos.Count() == 0)
            {
                lvMainModelList.Items.Clear();
                return;
            }

            lvMainModelList.Items.Clear();

            foreach (var item in mainModelDtos)
            {
                ListViewItem mainModelItem = new(item.ThreadId.ToString());

                mainModelItem.SubItems.Add(item.Data);

                lvMainModelList.Items.Add(mainModelItem);
            }
        }

        public void GenerateModel(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                int seconds = rnd.Next(500, 2001);
                Thread.Sleep(seconds);
                AddModel(CreateModel(seconds));
            }
        }

        public MainModel CreateModel(int seconds)
        {
            var model = new MainModel()
            {
                ThreadId = Thread.CurrentThread.ManagedThreadId,
                Time = seconds,
                Data = RandomString()
            };

            return model;
        }

        public bool AddModel(MainModel model)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $"INSERT INTO [dbo].[MainModels] ([ThreadId], [Time], [Data]) VALUES ('{model.ThreadId}', '{model.Time}', '{model.Data}')";

                    SqlDataReader reader = cmd.ExecuteReader();
                }
                conn.Close();
                
                return true;
            }
        }

        public List<MainModelDto> GetLastTwenty()
        {
            List<MainModelDto> mainModelDtos = new();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $"SELECT * FROM (SELECT TOP 20 [ThreadId], [Data] FROM [UvsThreads].[dbo].[MainModels] ORDER BY [Id] DESC) subquery ORDER BY [ThreadId] ASC";

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        MainModelDto model = new()
                        {
                            ThreadId = (int)reader.GetValue(0),
                            Data = (string)reader.GetValue(1)
                        };

                        mainModelDtos.Add(model);
                    }
                }
                conn.Close();
                return mainModelDtos;
            }
        }

        public string RandomString()
        {
            int length = rnd.Next(5, 11);

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
    }
}
