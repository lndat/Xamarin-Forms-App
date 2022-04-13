using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMitAlles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicTacToePage : ContentPage
    {
        int player = 2;
        int move = 0;
        int p1score = 0;
        int p2score = 0;


        public TicTacToePage()
        {
            InitializeComponent();
        }

        public async Task SpeakNow(string speak)
        {
            await TextToSpeech.SpeakAsync(speak);
        }

        private void buttonsClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Text == "")
            {
                if (player % 2 == 0)
                {
                    button.Text = "X";
                    player++;
                    move++;
                    button.IsEnabled = false;
                }
                else
                {
                    button.Text = "O";
                    player++;
                    move++;
                    button.IsEnabled = false;
                }
                if (GameDraw() == true)
                {
                    gameOverStackLayout.IsVisible = true;
                    gameOverButton.Text = "DRAW";
                    Task tasker = SpeakNow("Spiel Unentschieden!");
                }
                if (WinnerFound() == true)
                {
                    if (button.Text == "X")
                    {
                        p1score++;
                        p1Text.Text = $"Player 1: ({p1score})";
                        gameOverStackLayout.IsVisible = true;
                        gameOverButton.Text = "PLAYER 1 WON";
                        Task tasker = SpeakNow("Spieler eins, gewinnt!");
                        button1.IsEnabled = false;
                        button2.IsEnabled = false;
                        button3.IsEnabled = false;
                        button4.IsEnabled = false;
                        button5.IsEnabled = false;
                        button6.IsEnabled = false;
                        button7.IsEnabled = false;
                        button8.IsEnabled = false;
                        button9.IsEnabled = false;
                    }
                    else
                    {
                        p2score++;
                        p2Text.Text = $"Player 2: ({p2score})";
                        gameOverStackLayout.IsVisible = true;
                        gameOverButton.Text = "PLAYER 2 WON";
                        Task tasker = SpeakNow("Spieler zwei, gewinnt!");
                        button1.IsEnabled = false;
                        button2.IsEnabled = false;
                        button3.IsEnabled = false;
                        button4.IsEnabled = false;
                        button5.IsEnabled = false;
                        button6.IsEnabled = false;
                        button7.IsEnabled = false;
                        button8.IsEnabled = false;
                        button9.IsEnabled = false;
                    }
                }
            }

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            move = 0;
            player = 2;
            button1.Text = button2.Text = button3.Text = button4.Text = button5.Text = button6.Text = button7.Text = button8.Text = button9.Text = "";
            button1.IsEnabled = button2.IsEnabled = button3.IsEnabled = button4.IsEnabled = button5.IsEnabled = button6.IsEnabled = button7.IsEnabled = button8.IsEnabled = button9.IsEnabled = true;
            gameOverStackLayout.IsVisible = false;
        }

        bool GameDraw()
        {
            if (move == 9 && WinnerFound() == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool WinnerFound()
        {
            //h
            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && button1.Text != "")
            {
                return true;
            }
            if ((button4.Text == button5.Text) && (button5.Text == button6.Text) && button4.Text != "")
            {
                return true;
            }
            if ((button7.Text == button8.Text) && (button8.Text == button9.Text) && button7.Text != "")
            {
                return true;
            }

            //v
            if ((button1.Text == button4.Text) && (button4.Text == button7.Text) && button1.Text != "")
            {
                return true;
            }
            if ((button2.Text == button5.Text) && (button5.Text == button8.Text) && button2.Text != "")
            {
                return true;
            }
            if ((button3.Text == button6.Text) && (button6.Text == button9.Text) && button3.Text != "")
            {
                return true;
            }

            //q
            if ((button1.Text == button5.Text) && (button5.Text == button9.Text) && button1.Text != "")
            {
                return true;
            }
            if ((button3.Text == button5.Text) && (button5.Text == button7.Text) && button3.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}