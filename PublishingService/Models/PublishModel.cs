using System;
using System.Collections.Generic;

namespace PublishingService.Models
{
    public class PublishModel : IReceivable
    {
        private string _stato;
        public string Stato
        {
            get => _stato;
            set => _stato = value;
        }

        private string _orario;
        public string Orario
        {
            get => _orario;
            set => _orario = value;
        }

        private string _data;
        public string Data
        {
            get => _data;
            set => _data = value;
        }

        private List<string> _ambienti;
        public List<string> Ambienti
        {
            get => _ambienti;
            set => _ambienti = value;
        }

        private string _versione;
        public string Versione
        {
            get => _versione;
            set => _versione = value;
        }

        public PublishModel() {}

        public PublishModel(string stato, string orario, string data, List<string> ambienti, string versione) 
        {
            this.Stato = stato;
            this.Orario = orario;
            this.Data = data;
            ambienti.ForEach(p => this.Ambienti.Add(p));
            this.Versione = versione;
        }

        //public Object GetTempValue(IReceivable pm)
        //{
        //    if (pm.GetType() == PublishModel)
        //        return pm;
        //}
    }
}
