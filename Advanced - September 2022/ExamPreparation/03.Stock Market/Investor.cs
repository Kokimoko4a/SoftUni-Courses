using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName )
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new List<Stock>();
        }

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public decimal MoneyToInvest { get; set; }

        public string BrokerName { get; set; }
        public List<Stock> Portfolio { get; set; }

        public int Count
        {
            get { return Portfolio.Count; }
        }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization>10000 && MoneyToInvest >= stock.PricePerShare)
            {
                Portfolio.Add(stock);
                MoneyToInvest-=stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock currName = Portfolio.FirstOrDefault(x => x.CompanyName == companyName);

            if (!Portfolio.Any(x=>x.CompanyName == companyName))
            {
                return $"{companyName} does not exist.";
            }

            if (currName.PricePerShare> sellPrice)
            {
                return $"Cannot sell {companyName}.";
            }

            Portfolio.Remove(Portfolio.First(x => x.CompanyName == companyName));
            MoneyToInvest += sellPrice;
            return $"{currName.CompanyName} was sold.";
        }

        public Stock FindStock(string companyName)
        { 
            return Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            return this.Portfolio.OrderByDescending(s => s.MarketCapitalization).FirstOrDefault();

        }

        public string InvestorInformation()
        {
           /* StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks: ");

            sb.AppendLine(String.Join(Environment.NewLine, Portfolio));

            return sb.ToString().TrimEnd(); не то изпобзвай*/

            return $"The investor {this.FullName} with a broker {this.BrokerName} has stocks:" +
               Environment.NewLine +
               string.Join(Environment.NewLine, this.Portfolio);
        }
    }
}
