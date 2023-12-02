using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MemoryGame
{
    public partial class MainWindow : Window
    {        
        const int K = 4;        

        List<Brush> allColors  = new List<Brush>{
            Brushes.Red,
            Brushes.Blue,
            Brushes.Green,
            Brushes.Yellow,
            Brushes.Purple,
            Brushes.Orange,
            Brushes.Pink,
            Brushes.Turquoise,
            Brushes.Brown,
            Brushes.Black,
            Brushes.White,
            Brushes.Gray,
            Brushes.Maroon,
            Brushes.Navy,
            Brushes.Olive,
            Brushes.Teal,
            Brushes.Aqua,
            Brushes.Lime,
            Brushes.Fuchsia,
            Brushes.Silver,
            Brushes.Gold,
            Brushes.Salmon,
            Brushes.Indigo,
            Brushes.Lavender,
            Brushes.Cyan,
            Brushes.Beige,
            Brushes.Plum,
            Brushes.Coral,
            Brushes.Khaki,
            Brushes.SkyBlue,
            Brushes.Violet,
            Brushes.Tan,
            Brushes.SteelBlue,
            Brushes.Tomato,
            Brushes.DarkGreen,
            Brushes.DarkBlue,
            Brushes.DarkRed,
            Brushes.DarkGray,
            Brushes.LightBlue,
            Brushes.LightGreen,
            Brushes.LightYellow,
            Brushes.LightPink,
            Brushes.LightGray,
            Brushes.DarkCyan,
            Brushes.DarkMagenta,
            Brushes.DarkSalmon,
            Brushes.DarkSlateGray,
            Brushes.LightCoral,
            Brushes.LightCyan,
            Brushes.LightSteelBlue,
            Brushes.MediumAquamarine,
            Brushes.MediumPurple,
            Brushes.MediumSlateBlue,
            Brushes.MediumTurquoise,
            Brushes.MediumVioletRed,
            Brushes.MidnightBlue,
            Brushes.MistyRose,
            Brushes.NavajoWhite,
            Brushes.OldLace,
            Brushes.OliveDrab,
            Brushes.OrangeRed,
            Brushes.Orchid,
            Brushes.PaleGoldenrod,
            Brushes.PaleGreen,
            Brushes.PaleTurquoise,
            Brushes.PaleVioletRed,
            Brushes.PapayaWhip,
            Brushes.Peru,
            Brushes.PowderBlue,
            Brushes.RoyalBlue,
            Brushes.SaddleBrown,
            Brushes.SeaGreen,
            Brushes.Sienna,
            Brushes.SlateBlue,
            Brushes.SlateGray,
            Brushes.Snow,
            Brushes.SpringGreen,
            Brushes.SteelBlue,
            Brushes.Tan,
            Brushes.Thistle,
            Brushes.Tomato,
            Brushes.Turquoise,
            Brushes.Violet,
            Brushes.Wheat,
            Brushes.WhiteSmoke,
            Brushes.YellowGreen,
            Brushes.AntiqueWhite,
            Brushes.Aquamarine,
            Brushes.Azure,
            Brushes.Bisque,
            Brushes.BlanchedAlmond,
            Brushes.CadetBlue,
            Brushes.Chartreuse,
            Brushes.Chocolate,
            Brushes.CornflowerBlue,
            Brushes.Cornsilk,
            Brushes.DarkOliveGreen,
            Brushes.DarkOrange,
            Brushes.DarkOrchid,
            Brushes.DarkSeaGreen,
            Brushes.DarkSlateBlue,
            Brushes.DarkTurquoise,
            Brushes.DeepPink,
            Brushes.DeepSkyBlue,
            Brushes.DimGray,
            Brushes.DodgerBlue,
            Brushes.Firebrick,
            Brushes.FloralWhite,
            Brushes.ForestGreen,
            Brushes.Gainsboro,
            Brushes.GhostWhite,
            Brushes.Goldenrod,
            Brushes.GreenYellow,
            Brushes.Honeydew,
            Brushes.HotPink,
            Brushes.IndianRed,
            Brushes.Ivory,
            Brushes.Khaki,
            Brushes.LavenderBlush,
            Brushes.LawnGreen,
            Brushes.LemonChiffon,
            Brushes.LightGoldenrodYellow,
            Brushes.LightSalmon,
            Brushes.LightSeaGreen,
            Brushes.LightSlateGray,
            Brushes.Linen,
            Brushes.MediumBlue,
            Brushes.MediumOrchid,
            Brushes.MediumSeaGreen,
            Brushes.MediumSpringGreen,
            Brushes.MediumTurquoise,
            Brushes.Moccasin,
            Brushes.NavajoWhite,
            Brushes.PaleGreen,
            Brushes.PaleTurquoise,
            Brushes.PaleVioletRed,
            Brushes.PapayaWhip,
            Brushes.PeachPuff,
            Brushes.Pink,
            Brushes.Plum,
            Brushes.PowderBlue,
            Brushes.RosyBrown,
            Brushes.RoyalBlue,
            Brushes.SaddleBrown,
            Brushes.Salmon,
            Brushes.SandyBrown,
            Brushes.SeaGreen,
            Brushes.SkyBlue,
            Brushes.SlateBlue,
            Brushes.SlateGray,
            Brushes.Snow,
            Brushes.SpringGreen,
            Brushes.SteelBlue,
            Brushes.Tan,
            Brushes.Thistle,
            Brushes.Tomato,
            Brushes.Turquoise,
            Brushes.Violet,
            Brushes.Wheat,
            Brushes.White,
            Brushes.Yellow,
            Brushes.DarkKhaki,
            Brushes.DarkSalmon,
            Brushes.DarkSlateGray,
            Brushes.DarkTurquoise,
            Brushes.LightCoral,
            Brushes.LightCyan,
            Brushes.LightSteelBlue,
            Brushes.MediumAquamarine,
            Brushes.MediumPurple,
            Brushes.MediumSlateBlue,
            Brushes.MediumTurquoise,
            Brushes.MediumVioletRed,
            Brushes.MidnightBlue,
            Brushes.MistyRose,
            Brushes.NavajoWhite,
            Brushes.OldLace,
            Brushes.OliveDrab,
            Brushes.OrangeRed,
            Brushes.Orchid,
            Brushes.PaleGoldenrod,
            Brushes.PaleGreen,
            Brushes.PaleTurquoise,
            Brushes.PaleVioletRed,
            Brushes.PapayaWhip,
            Brushes.Peru,
            Brushes.PowderBlue,
            Brushes.RoyalBlue,
            Brushes.SaddleBrown,
            Brushes.SeaGreen
    };

        Brush backgroundBrush;
        Brush[] backColors;

        int[] numbers;
        long score = 0;
        long totalClicks = 0;

        List<Rectangle> openedRectangles = new List<Rectangle>();
        System.Media.SoundPlayer normalClick;
        System.Media.SoundPlayer wrongClick;
        System.Media.SoundPlayer successClick;

        Grid gameGrid = new Grid();

        void StartGame()
        {
            this.Title = $"Scores: {0}   Total clicks: {0}";
            this.score = 0;
            this.totalClicks = 0;
            openedRectangles.Clear();

            Random random = new Random();

            backColors = allColors.OrderBy(x => Guid.NewGuid()).Take(K*K).ToArray();
            allColors.RemoveAll(x => backColors.Contains(x));
            backgroundBrush = allColors.OrderBy(x => Guid.NewGuid()).Take(1).ToArray()[0];

            Rectangle[,] rectangles = new Rectangle[K, K];
            List<int> numbers = new List<int>(this.numbers);
            int index = numbers[random.Next(numbers.Count)];
            backgroundBrush = backColors[index - 1];
            numbers.RemoveAll(x => x == index);
            
            for (int  i = 0; i < K; i++)
            {
                for (int j = 0; j < K; j++)
                {
                    rectangles[i, j] = new Rectangle();
                    gameGrid.Children.Add(rectangles[i, j]);
                    Grid.SetColumn(rectangles[i, j], j);
                    Grid.SetRow(rectangles[i, j], i);

                    index = numbers[random.Next(numbers.Count)];
                    rectangles[i, j].Stroke = backColors[index - 1];
                    rectangles[i, j].Fill = backgroundBrush;
                    numbers.Remove(index);
                    rectangles[i, j].StrokeThickness = 0;
                    rectangles[i, j].Margin = new Thickness(2);
                    rectangles[i, j].MouseDown += MainWindow_MouseDown;

                }
            }
        }
 
        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {   
            if (sender is Rectangle)
            {
                Rectangle rect = (sender as Rectangle);

                if(rect.Fill == rect.Stroke)
                {
                    return;
                }

                if (openedRectangles.Count != 2)
                {
                    this.normalClick.Play();
                    rect.Fill = rect.Stroke;
                }
                else
                {
                    rect.Fill = rect.Stroke;

                    if (openedRectangles[0].Stroke != openedRectangles[1].Stroke)
                    {
                        this.wrongClick.Play();
                        openedRectangles[0].Fill = openedRectangles[1].Fill = backgroundBrush;
                    }
                    else
                    {
                        this.successClick.Play();
                        openedRectangles[0].MouseDown -= MainWindow_MouseDown;
                        openedRectangles[1].MouseDown -= MainWindow_MouseDown;
                        score += 2;
                    }
                    openedRectangles.Clear();
                }
                
                openedRectangles.Add(rect);
                totalClicks++;
                this.Title = $"Scores: {score}   Total clicks: {totalClicks}";

                if (score == K*K - 2)
                {
                    if(MessageBox.Show($"You won! Redundant clicks: {this.totalClicks-score}.",
                                        "Do you want to play again?",
                                        MessageBoxButton.YesNo) 
                                        == MessageBoxResult.Yes)
                    {
                        StartGame();
                    }                  
                }
            }
        }

        void InitializeGrid()
        {

            for (int i = 0; i < K; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = new GridLength(1, GridUnitType.Star);
                gameGrid.RowDefinitions.Add(rowDef);
            }

            for (int i = 0; i < K; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                colDef.Width = new GridLength(1, GridUnitType.Star);
                gameGrid.ColumnDefinitions.Add(colDef);
            }

            this.Content = gameGrid;
        }

        void InitializeSounds()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            this.normalClick = new System.Media.SoundPlayer($"{projectDirectory}\\sounds\\normal-click.wav");
            this.wrongClick = new System.Media.SoundPlayer($"{projectDirectory}\\sounds\\wrong-click.wav");
            this.successClick = new System.Media.SoundPlayer($"{projectDirectory}\\sounds\\success-click.wav");
        }

        public MainWindow()
        {
            Debug.Assert(K % 2  == 0, "");

            var temp = Enumerable.Range(1, K*K/2+1);
            temp = temp.Concat(temp);
            this.numbers = temp.ToArray();

            InitializeComponent();
            InitializeGrid();
            InitializeSounds();
            StartGame();
            
        }
    }
}
