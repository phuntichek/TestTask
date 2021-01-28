using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Service;

namespace TestTask.Data
{
    public class DateCurrencyExchangeConfiguration : IEntityTypeConfiguration<DateCurrencyExchange>
    {
        public void Configure(EntityTypeBuilder<DateCurrencyExchange> currencyExchanges)
        {
            currencyExchanges.ToTable("DateCurrencyExchanges");
            currencyExchanges.HasKey(u => u.Id);
            currencyExchanges.Property(u => u.Date).IsRequired();
            currencyExchanges.Property(u => u.Exchange).IsRequired();
            currencyExchanges.Property(u => u.CurrencyName).IsRequired();
        }
    }
}
