using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace UltimatePower
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static String Link = @"C:\Radiosender\";
        public static String Link2 = ".ini";
        public static int volume = 50;
        public static string url = " ";

        public static WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();


        public static void PlayMusicFromURL(string url)
        {
            player.URL = url;

            player.settings.volume = 100;

            player.controls.play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbFFH.Checked == true)
            {
                PlayMusicFromURL("http://streams.ffh.de/radioffh/mp3/hqlivestream.mp3?amsparams=playerid:RTFFHVtuner.mp3");
            }
            else
            if (rbHarmonyFM.Checked == true)
            {
                PlayMusicFromURL("http://streams.harmonyfm.de/harmonyfm/mp3/hqlivestream.mp3?amsparams=playerid:RTFFHVtuner.mp3");
            }
            else
            if (rbInselradio.Checked == true)
            {
                PlayMusicFromURL("http://stream.inselradio.com:20800/high.inselradio.mp3?origine=1djfkg.mp3");
            }
            else
            if (rbRadioBob.Checked == true)
            {
                PlayMusicFromURL("http://streams.radiobob.de/bob-live/mp3-192/vtuner/.mp3");
            }
            else
            if (rbcustom.Checked == true)
            {
                PlayMusicFromURL(tbcustom.Text);
            }
            else
            if (rbhr3.Checked == true)
            {
                PlayMusicFromURL("http://metafiles.gl-systemhaus.de/hr/hr3_2.m3u");
            }
            else
            if (rbYoufm.Checked == true)
            {
                PlayMusicFromURL("http://youfm.ice.infomaniak.ch/youfm-96.aac");
            }
            else
            if (rbhr4.Checked == true)
            {
                PlayMusicFromURL("https://hr-hr4-live.sslcast.addradio.de/hr/hr4/live/mp3/128/stream.mp3");
            }
            else
            if (rbhrinfo.Checked == true)
            {
                PlayMusicFromURL("http://metafiles.gl-systemhaus.de/hr/hrinfo_2.m3u");
            }
            else
            if (rbdlf.Checked == true)
            {
                PlayMusicFromURL("https://www.deutschlandradio.de/streaming/dlf.m3u");
            }
            else
            if (rbkibofm.Checked == true)
            {
                PlayMusicFromURL("http://listen.kibo.fm:8000/kibofm");
            }
            else
            if (rbnswlive.Checked == true)
            {
                PlayMusicFromURL("http://nsw-radio.de:8000/nswmp3");
            }
            else
            if (rbkawaiiradio.Checked == true)
            {
                PlayMusicFromURL("http://kawaii-music.stream.laut.fm/kawaii-music?ref=vtuner");
            }
            else
            if (rbanimeradiode.Checked == true)
            {
                PlayMusicFromURL("http://stream.animeradio.de/animeradio.mp3");
            }
            else
            {
                MessageBox.Show("Sie haben nichts ausgewählt!", "Fehler", MessageBoxButtons.OK);
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.controls.stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            volume = volume + 10;

            player.settings.volume = volume;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            volume = volume - 10;

            player.settings.volume = volume;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
         
            if (!Directory.Exists(Link))
            {
                System.IO.Directory.CreateDirectory(Link);
            }
            else
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(Link + tbsendername.Text + Link2, true))
            {

                file.WriteLine(tbcustom.Text);

            }
            MessageBox.Show("Sie haben den Sender " + tbsendername.Text + " erfolgreich gespeichert!", "Speichern erfolgreich", MessageBoxButtons.OK);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string[] eingabe = null;
            try
            {
                // einlesen der Datei in ein String-Array
                eingabe = File.ReadAllLines(Link + tbsendername.Text + Link2, Encoding.Default);
            }
            catch (Exception ex)
            {
                // Datei nicht vorhanden ...
                MessageBox.Show("Fehler beim Einlesen:\r\n", ex.Message);
                return;
            }
            tbcustom.Text = eingabe[0];
            MessageBox.Show("Sie haben den Sender " + tbsendername.Text + " erfolgreich geladen!", "Laden erfolgreich", MessageBoxButtons.OK);
        }
    }
}
