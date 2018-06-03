using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using System.IO;

namespace ReadWriteRules
{
    class Program
    {

        public static string ProcessConvert(string begin, string value, string finish)
        {
            string[] separators = { "," };
            string[] words = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string Convert;
            Convert = begin;
            foreach (var word in words)
            {
                if (word.Equals(words[words.Length - 1]))
                    Convert += "'" + word + "'";
                else Convert += "'" + word + "',";
            }
            Convert += finish;
            return Convert;
        }
        static void Main(string[] args)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\Wind\Documents\visual studio 2013\Projects\ReadWrite\Rules\bin\Debug\Rules.xlsx");
            Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.Sheets.get_Item(1);
            Excel.Range xlRange = xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
            string pathtxt = @"C:\Users\Wind\Documents\visual studio 2013\Projects\ReadWrite\Rules\bin\Debug\rules.txt";
            FileStream fs = new FileStream(pathtxt, FileMode.Create);
            StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);

            for (int i = 3; i <= rowCount; i++)// Row
            {
                int k = i - 2;
                sWriter.WriteLine("<Rules" + k + " >");
                sWriter.WriteLine(ProcessConvert("          GT : [", xlRange.Cells[i, 2].Value2.ToString(), "],"));
                sWriter.WriteLine(ProcessConvert("          KL : [", xlRange.Cells[i, 3].Value2.ToString(), "]"));
                sWriter.WriteLine("<Rules" + k + " >");
                sWriter.WriteLine();
                sWriter.Flush();
            }
            Console.Write("Done");
            Console.ReadKey();
        }

    }
}
