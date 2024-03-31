using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
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
using static RepDesktop.Classes.Helper;

using System.Text.Json;
using RepDesktop.Models;
using System.ComponentModel;


namespace RepDesktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private class Date
        {
            public List<string> message { get; set; }
        }
        Date date1 = new Date();
        List<Day> days = new List<Day>();

        private class Day
        {
            public Message message { get; set; }
        }

        public class Message
        {
            public date date { get; set; }
            public rooms_count rooms_count { get; set; }
            public windows_for_room windows_for_room { get; set; }
            public windows windows { get; set; }


        }
        public class date
        {
            public int data { get; set; }
            public string description { get; set; }

        }
        public class rooms_count
        {
            public int data { get; set; }
            public string description { get; set; }

        }
        public class windows_for_room
        {
            public List<int> data { get; set; }
            public string description { get; set; }

        }
        public class windows
        {
            public data data { get; set; }
            public string description { get; set; }

        }
        public class data
        {
            public List<bool> floor_1 { get; set; }
            public List<bool> floor_2 { get; set; }

            public List<bool> floor_3 { get; set; }

            public List<bool> floor_4 { get; set; }

        }


        public MainWindow()
        {
            InitializeComponent();
        }
        HttpClient httpClient = new HttpClient();

        private async Task loadDatesAsync()
        {

            try
            {
                string url = "https://olimp.miet.ru/ppo_it_final/date";
                HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, url);
                msg.Headers.Add("X-Auth-Token", "ppo_10_21881");
                var response = await httpClient.SendAsync(msg);
                if(response != null)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        date1 = JsonSerializer.Deserialize<Date>(content);
                        DateCbx.ItemsSource = date1.message.ToList();
                        DateCbx.SelectedIndex = 0;
                    }
                }

                foreach (var item in date1.message)
                {
                    

                    var date = item.Split('-');
                    string url2 = $"https://olimp.miet.ru/ppo_it_final?day={date[0]}&month={date[1]}&year={date[2]}";
                    
                    HttpRequestMessage msg2 = new HttpRequestMessage(HttpMethod.Get, url2);
                    msg2.Headers.Add("X-Auth-Token", "ppo_10_21881");
                    var response2 = await httpClient.SendAsync(msg2);
                    if (response2 != null)
                    {
                        if (response2.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var content = await response2.Content.ReadAsStringAsync();
                            var message = JsonSerializer.Deserialize<Day>(content);
                            days.Add(message);

                        }
                    }
                }


                foreach (var item in days)
                {
                    Models.Message message = new Models.Message();

                    message.Date =item.message.date.data;
                    if(item.message.date != null)
                    {
                        message.DateDescription = item.message.date.description;

                    }
                    if(item.message.rooms_count != null)
                    {
                        message.RoomsCountDescription = item.message.rooms_count.description;

                    }
                    if(item.message.rooms_count != null)
                    {
                        message.RoomsCount = item.message.rooms_count.data;

                    }
                    if (item.message.windows != null)
                    {
                        message.WindowsDescriptiono = item.message.windows.description;

                    }
                    if(item.message.windows_for_room != null)
                    {
                        message.WindowsForRoomDescription = item.message.windows_for_room.description;

                    }
                    try
                    {
                        if(item.message.windows_for_room != null)
                        {
                            foreach (var i in item.message.windows_for_room.data)
                            {
                                WindowsForRoom windowsFor = new WindowsForRoom();
                                windowsFor.Count = i;
                                message.WindowsForRoom.Add(windowsFor);
                            }
                        }
                        
                        foreach (var i in item.message.windows.data.floor_1)
                        {
                            Floor1ForMessage floor = new Floor1ForMessage();
                            floor.Light = i;
                            message.Floor1ForMessage.Add(floor);
                        }
                        foreach (var i in item.message.windows.data.floor_2)
                        {
                            Flooor2ForMessage floor = new Flooor2ForMessage();
                            floor.Light = i;
                            message.Flooor2ForMessage.Add(floor);
                        }
                        foreach (var i in item.message.windows.data.floor_3)
                        {
                            Floor3forMessage floor = new Floor3forMessage();
                            floor.Light = i;
                            message.Floor3forMessage.Add(floor);
                        }
                        foreach (var i in item.message.windows.data.floor_4)
                        {
                            Flor4ForMessage floor = new Flor4ForMessage();
                            floor.Light = i;
                            message.Flor4ForMessage.Add(floor);
                        }
                    }
                    catch
                    {

                    }
                    
                    Db.Message.Add(message);

                }
                Db.SaveChanges();
                messageDataGrid.ItemsSource = Db.Message.ToList();


            }
            catch (Exception ex)
            {
                Error();
	        }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadDatesAsync();

            System.Windows.Data.CollectionViewSource messageViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("messageViewSource")));
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            // messageViewSource.Source = [универсальный источник данных]
        }

        private void DateCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
