using Practika1.Models;
using Practika1.RCommand;
using Practika1.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Practika1.ViewModel
{
    public class MainPageViewModel
    {
        public MainPageView MainPageView { get; set; }
        public RealyyCommand GCommand { get; set; }
        public RealyyCommand AddCommand { get; set; }
        public RealyyCommand EditCommand { get; set; }
        public RealyyCommand RemoveCommand { get; set; }

        public bool Key { get; set; } = true;

        public MainPageViewModel(MainPageView mainPageView)
        {
            MainPageView = mainPageView;
            

            GCommand = new RealyyCommand(GCommnadFunction);
            AddCommand = new RealyyCommand(AddCommnadFunction);
        }

        public async Task ApiCek()
        {

            await Task.Delay(2000);

            if (Key)
            {
                Key = false;
                if (File.Exists($"../../../Text1.json"))
                {

                    MainPageView.MainListView.ItemsSource = JsonSerializer.Deserialize<List<Comment>>(File.ReadAllText("../../../Text1.json"));
                    MessageBox.Show("ALINDI 1 1");
                }
                else
                {
                    var client = new HttpClient();

                    string response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/comments");

                    File.WriteAllText("../../../Text1.json", JsonSerializer.Serialize<List<Comment>>(JsonSerializer.Deserialize<List<Comment>>(response)));
                    MainPageView.MainListView.ItemsSource = JsonSerializer.Deserialize<ObservableCollection<Comment>>(response);

                    MessageBox.Show("ALINDI");
                }
                Key = true;
            }
            
        }

        public async Task AddFunction()
        {
            AddCommentView addCommentView = new AddCommentView();
            addCommentView.DataContext = new AddCommandViewWodel(addCommentView);

            addCommentView.Show();


        }



        public void GCommnadFunction(object? par)
        {

            ApiCek();

        }
        public void AddCommnadFunction(object? par)
        {

            AddFunction();

        }


    }
}
