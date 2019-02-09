using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using PublishingService.Models;

namespace PublishingService.Logic
{
    public class DataFactory
    {
        #region Singleton Istance
        static DataFactory df = null;
        private DataFactory(){}

        public static DataFactory GetInstance()
        {
            if(df == null)
            {
                df = new DataFactory();
                return df;
            }
            else
            {
                return df;
            }
        }
        #endregion

        private readonly string Path = "../../data.txt";

        public IReceivable GetData()
        {
            String line;

            Debug.WriteLine("DEBUG: Init");


            try
            {
                //Pass the file path and file name to the StreamReader constructor
                //"//IP//home/silvio/Documents/PubblicazioneAST/PubblicazioneWS/data.txt""../../../../data.txt
                StreamReader sr = new StreamReader(Path);
                Debug.WriteLine("DEBUG: " + sr.ToString());
                
                PublishModel infoPublish = new PublishModel();

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    string key = line.Substring(0, line.IndexOf(':'));

                    switch (key.ToLower())
                    {
                        case "stato":
                            infoPublish.Stato = line.Substring(line.IndexOf(':') + 1);
                            break;
                        case "orario":
                            infoPublish.Orario = line.Substring(line.IndexOf(':') + 1);
                            break;
                        case "data":
                            infoPublish.Data = line.Substring(line.IndexOf(':') + 1);
                            break;
                        case "ambienti":
                            List<string> ambientiToPublish = line.Substring(line.IndexOf(':') + 1).Split('-', StringSplitOptions.None).OfType<string>().ToList();
                            if(ambientiToPublish.Count != 0)
                            {
                                infoPublish.Ambienti = new List<string>(ambientiToPublish);
                            }
                            break;
                        case "versione":
                            infoPublish.Versione = line.Substring(line.IndexOf(':') + 1);
                            break;
                        default:
                            break;
                    }

                    //Read the next line
                    line = sr.ReadLine();

                }

                //close the file
                if (sr != null)
                    sr.Close();

                return infoPublish;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return new PublishErrorModel(e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
