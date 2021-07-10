using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NumberToVietnamese
{
    public class NumberToVietnamese
    {
        public const string default_numbers = " hai ba bốn năm sáu bảy tám chín";

        List<string> units = ("1 một" + default_numbers).Split(' ').ToList();
        string ch = "lẻ mười" + default_numbers;
        string tr = "không một" + default_numbers;

        List<string> tram;
        List<string> u;
        List<string> chuc;

        public NumberToVietnamese()
        {
            tram = tr.Split(' ').ToList();
            u = "2 nghìn triệu tỉ".Split(' ').ToList();
            chuc = ch.Split(' ').ToList();
        }
        
        /**
         * additional words 
         * a: string representation number with 2 digit
         * @param  {[type]} a [description]
         * @return {[type]}   [description]
         */
        string tenth(string a)
        {
            int a0 = int.Parse(a[0].ToString());
            int a1 = int.Parse(a[1].ToString());

            var sl1 = units[a1];
            var sl2 = chuc[a0];

            string append = "";

            if (a0 > 0 && a1 == 5)
                sl1 = "lăm";

            if (a0 > 1)
            {
                append = " mươi";
                if (a1 == 1)
                    sl1 = " mốt";
            }
            var str = sl2 + "" + append + " " + sl1;
            return str;
        }

        /**
         * convert number in blocks of 3 
         * @param  {[type]} d [description]
         * @return {[type]}   [description]
         */
        string BlockOfThree(string d)
        {
            var _a = d + "";

            if (d == "000") return "";

            switch (_a.Length)
            {
                case 0:
                    return "";

                case 1:
                    return units[Int32.Parse(_a)];

                case 2:
                    return tenth(_a);

                case 3:
                    string sl12 = "";
                    // check last 2 digits
                    if (_a.Substring(1, 2) != "00")
                    {
                        sl12 = tenth(_a.Substring(1, 2));
                    }
                       
                    string sl3 = tram[int.Parse(_a[0].ToString())] + " trăm";
                    return sl3 + ' ' + sl12;
            }

            return "";
        }

        public string ToVietnamese(int str)
        {
            return ToVietnamese(str.ToString());
        }

        public string ToVietnamese(string str)
        {
            int number = 0;
            if (!Int32.TryParse(str, out number))
            {
                return "";
            }

            var arr = new List<string>();
            var result = new List<string>();
          
            var finalString = "";

            var index = str.Length;
            //explode number string into blocks of 3numbers and push to queue
            while (index >= 0)
            {
                arr.Add(str.Substring(Math.Max(index - 3, 0), Math.Min(index, 3)));

                index -= 3;
            }

            //loop though queue and convert each block 
            for (int i = arr.Count - 1; i >= 0; i--)
            {
                if (arr[i] != "" && arr[i] != "000")
                {
                    result.Add(BlockOfThree(arr[i]));
                    if (i < u.Count && !String.IsNullOrEmpty(u[i]))
                        result.Add(u[i]);
                }
            }

            finalString = string.Join(" ", result);

            //remove unwanted white space
            finalString = Regex.Replace(finalString, @"[\d-]", String.Empty);
            finalString = Regex.Replace(finalString, @"\s+", " ");
            finalString = finalString.Trim();

            return finalString;
        }
    }
}
