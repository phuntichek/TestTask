using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Service

{
    public class DateCurrencyExchange
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public double Exchange { get; set; }

        public string CurrencyName { get; set; }
    }
}