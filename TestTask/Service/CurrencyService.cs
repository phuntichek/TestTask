using System;
using System.Linq;
using TestTask.Data;

namespace TestTask.Service
{
    public class CurrencyService : ICurrencyService
    {
        private readonly AppDbContext _appDbContext;

        public CurrencyService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string AddNewCurrencyState()
        {
            var newExchanges = GetNewExchanges();
            string URL = "http://www.cbr.ru/scripts/XML_daily.asp?date_req=21.08.2019";
            int i = 3;
            string NameOfCurrency = "";
            string tmp = "";
            string DateStr = "";
            int j = URL.Length - 10;
            while (j < URL.Length)
            {
                DateStr += URL[j];
                j++;
            }
            while (i < newExchanges.Length)
            {
                i += 3;
                while (Char.IsDigit(newExchanges[i]) && i < newExchanges.Length)
                    i++;
                while (!Char.IsDigit(newExchanges[i]) && i < newExchanges.Length)
                {
                    NameOfCurrency += newExchanges[i];
                    i++;
                }
                while (i < newExchanges.Length && !Char.IsLetter(newExchanges[i]))
                {
                    if (tmp.Length < 7)
                        tmp += newExchanges[i];
                    i++;
                }
                var dateCurrencyExchange = new DateCurrencyExchange()
                {
                    Date = DateStr,
                    Exchange = Convert.ToDouble(tmp),
                    CurrencyName = NameOfCurrency
                };
                _appDbContext.Add(dateCurrencyExchange);

                NameOfCurrency = "";
                tmp = "";
            }

            _appDbContext.SaveChanges();
            return "Update Uploaded";
        }

        private string GetNewExchanges()
        {
            string URL = "http://www.cbr.ru/scripts/XML_daily.asp?date_req=21.08.2019";
            return "036AUD1Австралийский доллар45,2862944AZN1Азербайджанский манат39,3658826GBP1Фунт стерлингов Соединенного королевства80,7419051AMD100Армянских драмов14,0332933BYN1Белорусский рубль32,4178975BGN1Болгарский лев37,8101986BRL1Бразильский реал16,3895348HUF100Венгерских форинтов22,6130344HKD10Гонконгских долларов85,1381208DKK10Датских крон99,1788840USD1Доллар США66,7840978EUR1Евро73,9766356INR100Индийских рупий93,1186398KZT100Казахстанских тенге17,2602124CAD1Канадский доллар50,1231417KGS100Киргизских сомов95,5622156CNY10Китайских юаней94,5520498MDL10Молдавских леев37,6566578NOK10Норвежских крон74,3184985PLN1Польский злотый16,9425946RON1Румынский лей15,6260960XDR1" +
            "СДР (специальные права заимствования)91,6377702SGD1Сингапурский доллар48,1812972TJS10Таджикских сомони68,8850949TRY1Турецкая лира11,6919934TMT1Новый туркменский манат19,1084860UZS10000Узбекских сумов72,9880980UAH10Украинских гривен26,5833203CZK10Чешских крон28,6713752SEK10Шведских крон68,9127756CHF1Швейцарский франк68,1539710ZAR10Южноафриканских рэндов43,3795410KRW1000Вон Республики Корея55,2610392JPY100Японских иен62,7463";
        }
    }
}
