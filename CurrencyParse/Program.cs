using System;
using System.Collections.Generic;
using System.Linq;
using CurrencyParse.Extensions;
using CurrencyParse.Helpers;
using CurrencyParse.Models;
using HtmlAgilityPack;
using xNet;

namespace CurrencyParse
{
    /// <summary>
    /// Тестовое задание
    /// 1) Для загрузки страницы необходимо использовать библиотеку xNET: https://github.com/X-rus/xNet, остальные компоненты - стандартные для среды разработки.
    /// 2) Для курсов валют необходимо создать отдельный класс.Поля класса и структуру выбираете сами.Как минимум - строковое название валюты и float - курс.
    /// 3) Название валют можно не склонять.
    /// 4) Каждый найденный курс валют должен передаваться в пустой метод AddCourse() класса, который вы создали для валют.
    /// 5) Среда разработки MS VisualStudio 2017 язык разработки - C#

    /// </summary>
    /// <inheritdoc cref="https://ekaterinburg.hh.ru/vacancy/32198097?utm_medium=email&utm_source=email&utm_campaign=company_interested&utm_content=2019_07_02"/>
    class Program
    {
        private const string CurrencyDailyUrl = "http://www.cbr.ru/currency_base/daily/";

        public static List<Currency> CurrencyRateTable = new List<Currency>();

        static void Main(string[] args)
        {
            using (var request = new HttpRequest())
            {
                HttpResponse response = request.Get(CurrencyDailyUrl);
                var page = response.ToString();
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(page);
                var htmlNodesTr = doc.DocumentNode.SelectSingleNode("//table[@class='data']")
                    .Descendants("tr")
                    // пропускаем шапку
                    .Skip(1);

                foreach (var tr in htmlNodesTr)
                {
                    AddCourse(new Currency
                    {
                        Unit = tr.GetValue(CurrencyParseHelper.IsCurrencyUnitField)
                            .TryParseInt(CurrencyParseHelper.IsCurrencyUnitField),

                        Code = tr.GetValue(CurrencyParseHelper.IsCurrencyCodeField)
                            .TryParseString(CurrencyParseHelper.IsCurrencyCodeField),

                        CodeDescription = tr.GetValue(CurrencyParseHelper.IsCurrencyCodeDescriptionField)
                            .TryParseString(CurrencyParseHelper.IsCurrencyCodeDescriptionField),

                        Name = tr.GetValue(CurrencyParseHelper.IsCurrencyNameField)
                            .TryParseString(CurrencyParseHelper.IsCurrencyNameField),

                        Value = tr.GetValue(CurrencyParseHelper.IsCurrencyValueField)
                            .TryParseDecimal(CurrencyParseHelper.IsCurrencyValueField),
                    });
                }
            }
            Console.ReadKey();
        }

        private static void AddCourse(Currency currency)
        {
            CurrencyRateTable.Add(currency);
        }
    }
}
