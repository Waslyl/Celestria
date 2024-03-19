using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using MaterialDesignThemes.Wpf;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Ookii.Dialogs.Wpf;
using System.Windows.Media.Imaging;
using System.Xml;

namespace Celestria
{
    public partial class Home : Page
    {
        private string settingsFilePath;
        private List<FolderInfo> folderInfoList;

        public Home()
        {
            InitializeComponent();
            settingsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Celestria", "settings.json");
            LoadSettings();
        }

        private void LoadSettings()
        {
            if (File.Exists(settingsFilePath))
            {
                string json = File.ReadAllText(settingsFilePath);
                folderInfoList = JsonConvert.DeserializeObject<List<FolderInfo>>(json);
                if (folderInfoList == null)
                {
                    folderInfoList = new List<FolderInfo>();
                }
                foreach (var folderInfo in folderInfoList)
                {
                    BuildList(folderInfo.buildName, folderInfo.ImageUrl);
                }
            }
            else
            {
                folderInfoList = new List<FolderInfo>();
            }
        }

        private void SaveSettings()
        {
            string json = JsonConvert.SerializeObject(folderInfoList, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(settingsFilePath, json);
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new VistaFolderBrowserDialog();

            if (dialog.ShowDialog() == true)
            {
                string folderPath = dialog.SelectedPath;

                if (Directory.Exists(Path.Combine(folderPath, "FortniteGame")) && Directory.Exists(Path.Combine(folderPath, "Engine")))
                {
                    string buildName = new DirectoryInfo(folderPath).Name;
                    string imageUrl;
                    bool buildExists = false;

                    if (buildName == "9.10")
                    {   
                        buildName= " 9.10";
                        imageUrl = "https://upload.wikimedia.org/wikipedia/commons/7/7c/Fortnite_F_lettermark_logo.png";
                    }
                    else if (buildName.Contains("12.41"))
                    {
                        buildName = "12.41";
                        imageUrl = "https://wallpapercave.com/wp/wp5588400.jpg";
                    }
                    else if (buildName.Contains("000edbaa-2f69-453f-8e3c-52734365483e"))
                    {
                        buildName = " 5.41";
                        imageUrl = "https://cdn.itztiva.com/ogfnlogo.jpg";
                    }
                    else if (buildName.Contains("17.30"))
                    {
                        buildName = "17.30";
                        imageUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQJDxx1fTpccMNBLjq_ZI45Qv91LYBeQd9C5QU2cHDIMxQAIAgt";
                    }
                    else if (buildName.Contains("13.40"))
                    {
                        buildName = "13.40";
                        imageUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQJDxx1fTpccMNBLjq_ZI45Qv91LYBeQd9C5QU2cHDIMxQAIAgt";
                    }
                    else if (buildName.Contains("1.11"))
                    {
                        buildName = " 1.11";
                        imageUrl = "https://cdn.itztiva.com/ogfnlogo.jpg";
                    }
                    else if (buildName.Contains(" 1.8"))
                    {
                        buildName = " 1.8";
                        imageUrl = "https://cdn.itztiva.com/ogfnlogo.jpg";
                    }
                    else if (buildName.Contains("1.7.2"))
                    {
                        buildName = "1.7.2";
                        imageUrl = "https://cdn.itztiva.com/ogfnlogo.jpg";
                    }
                                        else if (buildName.Contains("1.7.2"))
                    {
                        buildName = "1.7.2";
                        imageUrl = "https://cdn.itztiva.com/ogfnlogo.jpg";
                    }
                    else
                    {
                        buildName =  "Error";
                        imageUrl = "https://fortnite.gg/img/assets/icons/1783.jpg";
                    }

                    foreach (var item in folderInfoList)
                    {
                        if (item.buildName == buildName)
                        {
                            buildExists = true;
                            break;
                        }
                    }


                    if (buildExists)
                    {
                        MessageBox.Show("This build is already imported.", "Error", MessageBoxButton.OK);
                        return; 
                    }


                    BuildList(buildName, imageUrl);
                    folderInfoList.Add(new FolderInfo { buildName = buildName, ImageUrl = imageUrl });
                    SaveSettings();
                }
                else
                {
                    MessageBox.Show("Unable to identify Fortnite Build.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BuildList(string buildName, string imageUrl)
        {
            ListBoxItem newItem = new ListBoxItem();

            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;

            Image img = new Image();
            img.Width = 50;
            img.Margin = new Thickness(0, 0, 10, 0);
            img.Height = 50;
            BitmapImage bitmap = new BitmapImage(new Uri(imageUrl, UriKind.Absolute));
            img.Source = bitmap;
            stackPanel.Children.Add(img);

            TextBlock textBlock = new TextBlock();
            textBlock.Margin = new Thickness(840, 0, 0, 0);
            textBlock.Text = buildName;
            textBlock.Foreground = Brushes.White;
            textBlock.FontSize = 30;
            stackPanel.Children.Add(textBlock);

            newItem.Content = stackPanel;

            newItem.Background = new SolidColorBrush(Color.FromArgb(76, 0, 0, 0));


            newItem.PreviewMouseDown += (sender, e) =>
            {
                e.Handled = true;
            };

            folderList.Items.Add(newItem);
        }
    }

        public class FolderInfo
    {
        public string buildName { get; set; }
        public string ImageUrl { get; set; }
    }
}
