using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace MK_Docs_Updater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Erstelle Logdatei mit dem Namen "mkdocsupdater.log"
            string logfilename = "mkdocsupdater.log";
            
            if (!File.Exists(logfilename))
            {
                File.Create(logfilename).Close();
            }
            else
            {
                File.Delete(logfilename);
                File.Create(logfilename).Close();
            }



            // Schreibe in Logdatei "Anwendung gestartet"
            using (StreamWriter sw = File.AppendText(logfilename))
            {
                sw.WriteLine("Anwendung gestartet");
                sw.Close();
            }



            // Stelle Verbindung zur Datenbank her
            MySqlConnection conn = new MySqlConnection(logindata.Connection);
            conn.Open();



            // Lese aus Datenbank alle Einträge
            MySqlCommand cmd = new MySqlCommand("SELECT `systemVersion`, `systemHash`,`systemBaseUrl`, `systemFilename` FROM `system`", conn);
            MySqlDataReader reader = cmd.ExecuteReader();



            //Setze Variablen version, baseURL, filename und hash
            reader.Read();
            string version = reader.GetString("systemVersion");
            string hash = reader.GetString("systemHash");
            string baseURL = reader.GetString("systemBaseURL");
            string filename = reader.GetString("systemFilename");
            reader.Close();

            // schreibe in Logdatei: "Alle Variablen ausgelesen und gesetzt" + Variablen

            using (StreamWriter sw = File.AppendText(logfilename))
            {
                sw.WriteLine("Alle Variablen ausgelesen und gesetzt");
                sw.WriteLine("Version: " + version);
                sw.WriteLine("Hash: " + hash);
                sw.WriteLine("BaseURL: " + baseURL);
                sw.WriteLine("Filename: " + filename);
                sw.Close();
            }
            

            try
            {
                // create folder if not exsistant /tmp in application path
                if (!Directory.Exists("tmp/"))
                {
                    Directory.CreateDirectory("tmp/");
                }
                
                // Download file from URL and save in tmp folder
                WebClient webClient = new WebClient();
                webClient.DownloadFile(baseURL + filename, "tmp/" + filename);
                

                // schreibe in Logdatei: "Datei heruntergeladen"
                using (StreamWriter sw = File.AppendText(logfilename))
                {
                    sw.WriteLine("Datei heruntergeladen");
                    sw.Close();
                }
                Console.WriteLine("Datei heruntergeladen");

                // Build MD5 Hash of downloaded file
                string fileHash = "";
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead("tmp/" + filename))
                    {
                        fileHash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
                    }
                }


                // Build MD5 Hash of current file
                string currentHash = "";
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(filename))
                    {
                        currentHash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
                    }
                }

                // schreibe in Logdatei: "Hash berechnet" + Hash
                using (StreamWriter sw = File.AppendText(logfilename))
                {
                    sw.WriteLine("Hash berechnet");
                    sw.WriteLine("File Hash: " + fileHash);
                    sw.WriteLine("Current Hash: " + currentHash);
                    sw.Close();
                }
            
                
                // Compare MD5 Hash of downloaded file with MD5 Hash of current file
                if (fileHash == currentHash)
                {
                    // Lösche alte Datei im tmp Verzeichnis
                    File.Delete("tmp/" + filename);

                    // schreibe in Logdatei: "Datei ist aktuell!\nStarte Programm"
                    using (StreamWriter sw = File.AppendText(logfilename))
                    {
                        sw.WriteLine("Datei ist aktuell!\nStarte Programm");
                        sw.Close();
                    }

                    // Starte eigentliche Anwendung
                    Process.Start(filename);
                }
                else
                {
                    // lösche eigentliche Datei und kopiere datei im tmp verzeichnis in eigentliches Verzeichnis, lösche danach datei im tmp verzeichnis
                    File.Delete(filename);
                    File.Copy("tmp/" + filename, filename);
                    File.Delete("tmp/" + filename);

                    // schreibe in Logdatei: "Datei ist nicht aktuell!\nDatei wurde kopiert\nStarte Programm!"
                    using (StreamWriter sw = File.AppendText(logfilename))
                    {
                        sw.WriteLine("Datei ist nicht aktuell!\nDatei wurde kopiert!\nStarte Programm!");
                        sw.Close();
                    }
                    Process.Start(filename);
                }
            }
            catch (Exception ex)
            {
                // schreibe in Logdatei: "Fehler beim Herunterladen der Datei" + Fehlermeldung
                using (StreamWriter sw = File.AppendText(logfilename))
                {
                    sw.WriteLine("Fehler beim Herunterladen der Datei");
                    sw.WriteLine(ex.Message);
                    sw.Close();
                }


                // Frage Nutzer mit y/n ob er das Programm trotzdem starten möchte
                DialogResult dialogResult = MessageBox.Show("Fehler!\n\n" + ex.Message + "\n\nMöchten Sie das Programm trotzdem starten?", "Fehler", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.Yes)
                {
                    // Starte Mk-Docs-Server.exe
                    Process.Start(filename);
                }
                else if (dialogResult == DialogResult.No)
                {
                    // schreibe in Logdatei: "Programm wurde beendet"
                    using (StreamWriter sw = File.AppendText(logfilename))
                    {
                        sw.WriteLine("Programm wurde beendet");
                        sw.Close();
                    }
                }
            }
            Application.Exit();
        }
    }
}
