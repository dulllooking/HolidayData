using HolidayData_ClassDB;
using HolidayData_ClassDB.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HolidayData_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            SetHolidayDataToDB();
        }

        private static void SetHolidayDataToDB()
        {
            // 參考 : https://ithelp.ithome.com.tw/articles/10221928?sc=pt
            // 資料行 : "date","name","isHoliday","holidayCategory","description"\n

            ApplicationDbContext db = new ApplicationDbContext();
            string fileName = "政府行政機關辦公日曆表.csv";
            // C:\Users\user\source\repos\HolidayData\HolidayData_Console\bin\Debug
            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            // 宣告 DirectoryInfo 後可用 .Parent 搭配 .FullName 取得上層資料夾位置
            string filePath = dir.Parent.Parent.FullName + "\\File\\" + fileName;
            
            // 先清空並歸零 index
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE HolidayInfoes");
            db.SaveChanges();

            // ---逐行讀取的方式---
            // 使用 StreamReader 讀取文字檔
            StreamReader streamReader = new StreamReader(filePath);
            // 逐行讀取,目前為標題行
            string rowContent = streamReader.ReadLine();
            // 逐行讀取,直到讀到 null
            while (rowContent != null) {
                rowContent = streamReader.ReadLine();
                if (!string.IsNullOrEmpty(rowContent)) {
                    var cells = rowContent.Split(',');
                    HolidayInfo csvData = new HolidayInfo
                    {
                        Date = DateTime.Parse(cells[0].Trim('"').Trim('\\')),
                        Name = cells[1].Trim('"').Trim('\\'),
                        IsHoliday = cells[2].Trim('"').Trim('\\').Equals("是") ? true : false,
                        HolidayCatalog = cells[3].Trim('"').Trim('\\'),
                        Description = cells[4].Trim('"').Trim('\\')
                    };
                    db.HolidayInfo.Add(csvData);
                }
            }
            db.SaveChanges();

            // ---讀成一行的方式---
            var readCSV = File.ReadAllText(filePath, Encoding.UTF8);
            string[] csvFileRecoord = readCSV.Split('\n');

            int count = 0;
            foreach (var row in csvFileRecoord) {
                if (!string.IsNullOrEmpty(row) && count > 0) {
                    var cells = row.Split(',');
                    HolidayInfo csvData = new HolidayInfo
                    {
                        Date = DateTime.Parse(cells[0].Trim('"').Trim('\\')),
                        Name = cells[1].Trim('"').Trim('\\'),
                        IsHoliday = cells[2].Trim('"').Trim('\\').Equals("是") ? true : false,
                        HolidayCatalog = cells[3].Trim('"').Trim('\\'),
                        Description = cells[4].Trim('"').Trim('\\')
                    };
                    db.HolidayInfo.Add(csvData);
                }
                count++;
            }
            db.SaveChanges();
        }
    }
}
