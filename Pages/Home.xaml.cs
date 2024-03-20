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
                    BuildList(folderInfo.buildName, folderInfo.ImageUrl, folderInfo.folderPath);
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
                        buildName = " 9.10";
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
                        imageUrl = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcTt8MSSeOfubAbpy7773Kn0qSk5O1giuKSgTJNEEWTLozRYmLts";
                    }
                    else if (buildName.Contains("13.40"))
                    {
                        buildName = "13.40";
                        imageUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQJDxx1fTpccMNBLjq_ZI45Qv91LYBeQd9C5QU2cHDIMxQAIAgt";
                    }
                    else if (buildName.Contains("14.30"))
                    {
                        buildName = "14.30";
                        imageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQDq2YXW7riEufXfU2d0OTZiGFn4H1cDeyFW29qNDKhTpmeEVe_";
                    }
                    else if (buildName.Contains("14.60"))
                    {
                        buildName = "14.60";
                        imageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQDq2YXW7riEufXfU2d0OTZiGFn4H1cDeyFW29qNDKhTpmeEVe_";
                    }
                    else if (buildName.Contains("15.30"))
                    {
                        buildName = "15.30";
                        imageUrl = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTNfgc7excW4wqe9gmKZegEZxqr0Ik_4eXUbjQnLmzeuCPo4jvd";
                    }
                    else if (buildName.Contains("16.40"))
                    {
                        buildName = "16.40";
                        imageUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSClL2a4VpwU6NbBb307Ay6HvmtAG01RBZjurisCLNOe2Oy_U1F";
                    }
                    else if (buildName.Contains("18.40"))
                    {
                        buildName = "18.40";
                        imageUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSClL2a4VpwU6NbBb307Ay6HvmtAG01RBZjurisCLNOe2Oy_U1F";
                    }
                    else if (buildName.Contains("19.10"))
                    {
                        buildName = "19.10";
                        imageUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSPb7kThRI1NPQ7yNFGPUITZv07dhfMkb38QPNLFs9W_0ab7Tyr";
                    }
                    else if (buildName.Contains("20.40"))
                    {
                        buildName = "20.40";
                        imageUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSClL2a4VpwU6NbBb307Ay6HvmtAG01RBZjurisCLNOe2Oy_U1F";
                    }
                    else if (buildName.Contains("21.40"))
                    {
                        buildName = "21.40";
                        imageUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSWSVRZmTvq3Os0A2MAjgWz_ku5pfpvu6axiHhEZP9-mNFVFBE4";
                    }
                    else if (buildName.Contains("1.11"))
                    {
                        buildName = " 1.11";
                        imageUrl = "https://cdn.itztiva.com/ogfnlogo.jpg";
                    }
                    else if (buildName.Contains("1.8"))
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
                    else if (buildName.Contains("8.51"))
                    {
                        buildName = " 8.51";
                        imageUrl = "https://upload.wikimedia.org/wikipedia/commons/7/7c/Fortnite_F_lettermark_logo.png";
                    }
                    else if (buildName.Contains("8.40"))
                    {
                        buildName = " 8.40";
                        imageUrl = "https://upload.wikimedia.org/wikipedia/commons/7/7c/Fortnite_F_lettermark_logo.png";
                    }
                    else if (buildName.Contains("8.30"))
                    {
                        buildName = " 8.30";
                        imageUrl = "https://upload.wikimedia.org/wikipedia/commons/7/7c/Fortnite_F_lettermark_logo.png";
                    }
                    else if (buildName.Contains("8.20"))
                    {
                        buildName = " 8.20";
                        imageUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQJDxx1fTpccMNBLjq_ZI45Qv91LYBeQd9C5QU2cHDIMxQAIAgt";
                    }
                    else if (buildName.Contains("8.10"))
                    {
                        buildName = " 8.10";
                        imageUrl = "https://upload.wikimedia.org/wikipedia/commons/7/7c/Fortnite_F_lettermark_logo.png";
                    }
                    else if (buildName.Contains("8.00"))
                    {
                        buildName = " 8.00";
                        imageUrl = "https://upload.wikimedia.org/wikipedia/commons/7/7c/Fortnite_F_lettermark_logo.png";
                    }
                    else if (buildName.Contains("7.40"))
                    {
                        buildName = " 7.40";
                        imageUrl = "https://upload.wikimedia.org/wikipedia/commons/7/7c/Fortnite_F_lettermark_logo.png";
                    }
                    else if (buildName.Contains("7.30"))
                    {
                        buildName = " 7.30";
                        imageUrl = "https://upload.wikimedia.org/wikipedia/commons/7/7c/Fortnite_F_lettermark_logo.png";
                    }
                    else if (buildName.Contains("c2258301-017b-4b6b-89e8-9c5ffea5767c"))
                    {
                        buildName = " 7.40";
                        imageUrl = "https://upload.wikimedia.org/wikipedia/commons/7/7c/Fortnite_F_lettermark_logo.png";
                    }
                    else
                    {
                        MessageBox.Show("This build is not implemented yet. Please make a issue in the github with the Build you are trying to import or add it yourself in the source code and submit a Pull Request!", "Error", MessageBoxButton.OK);
                        return;
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


                    BuildList(buildName, imageUrl, folderPath);
                    folderInfoList.Add(new FolderInfo { buildName = buildName, ImageUrl = imageUrl, folderPath= folderPath });
                    SaveSettings();
                }
                else
                {
                    MessageBox.Show("Unable to identify Fortnite Build.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BuildList(string buildName, string imageUrl, string folderPath)
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

        public string folderPath { get; set; }

    }
}
