﻿using System.Text.RegularExpressions;

/*
C#正則表達式搜尋+取代(替換/更換) [C# regex replace]
https://regex101.com/
https://www.c-sharpcorner.com/article/c-sharp-regex-examples/
https://github.com/jash-git/CS_Regex_HTML_Spider [C#(.NET6) 正則(正規) 表達式 HTML 快速 切割/拆解/分割/拆分 字串 資料 測試範例 [爬蟲(SPIDER)基礎]]
*/

namespace CS_formula_params_RegexMatchesReplace
{
    class Program
    {
        static void Pause()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }

        static void Main(string[] args)
        {
            //formula_params原始資料
            string strinput = @"{""formula_data"":{""E04"":{""product_code"":""E04"",""product_name"":""檸檬多多"",""material_list"":[{""material_code"":""b002"",""material_name"":""綠茶"",""material_value"":""50.00"",""material_unit"":""cc"",""print_bill"":""N"",""is_display"":""N""},{""material_code"":""G003"",""material_name"":""冰塊"",""material_value"":""3.00"",""material_unit"":""杯"",""print_bill"":""N"",""is_display"":""N"",""formula_list"":[{""condiment_code"":""I0001"",""condiment_name"":""少冰"",""operator_key"":""*"",""operator_value"":""0.80"",""to_change_code"":null,""unit_name"":""杯""},{""condiment_code"":""I0002"",""condiment_name"":""微冰"",""operator_key"":""*"",""operator_value"":""0.50"",""to_change_code"":null,""unit_name"":""杯""},{""condiment_code"":""I0003"",""condiment_name"":""去冰"",""operator_key"":""*"",""operator_value"":""0.30"",""to_change_code"":null,""unit_name"":""杯""},{""condiment_code"":""I0004"",""condiment_name"":""多冰"",""operator_key"":""*"",""operator_value"":""1.20"",""to_change_code"":null,""unit_name"":""杯""}]},{""material_code"":""b003"",""material_name"":""果糖"",""material_value"":""30.00"",""material_unit"":""cc"",""print_bill"":""N"",""is_display"":""N"",""formula_list"":[{""condiment_code"":""S0001"",""condiment_name"":""少糖"",""operator_key"":""*"",""operator_value"":""0.80"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""S0002"",""condiment_name"":""半糖"",""operator_key"":""*"",""operator_value"":""0.50"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""S0003"",""condiment_name"":""微糖"",""operator_key"":""*"",""operator_value"":""0.30"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""S0004"",""condiment_name"":""無糖"",""operator_key"":""="",""operator_value"":""0.00"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""S0005"",""condiment_name"":""多糖"",""operator_key"":""*"",""operator_value"":""1.20"",""to_change_code"":null,""unit_name"":""cc""}]},{""material_code"":""W001"",""material_name"":""養樂多"",""material_value"":""3.00"",""material_unit"":""罐"",""print_bill"":""N"",""is_display"":""N""}]},""F05-M"":{""product_code"":""F05-M"",""product_name"":""翠玉金萱(中)"",""material_list"":[{""material_code"":""G002"",""material_name"":""水"",""material_value"":""50.00"",""material_unit"":""cc"",""print_bill"":""N"",""is_display"":""N"",""formula_list"":[{""condiment_code"":""I0001"",""condiment_name"":""少冰"",""operator_key"":""+"",""operator_value"":""2.00"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""I0002"",""condiment_name"":""微冰"",""operator_key"":""+"",""operator_value"":""4.00"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""S0001"",""condiment_name"":""少糖"",""operator_key"":""+"",""operator_value"":""10.00"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""S0002"",""condiment_name"":""半糖"",""operator_key"":""+"",""operator_value"":""6.00"",""to_change_code"":null,""unit_name"":""cc""}]},{""material_code"":""G003"",""material_name"":""冰塊"",""material_value"":""1.00"",""material_unit"":""杯"",""print_bill"":""N"",""is_display"":""N"",""formula_list"":[{""condiment_code"":""I0002"",""condiment_name"":""微冰"",""operator_key"":""*"",""operator_value"":""1.50"",""to_change_code"":null,""unit_name"":""杯""}]},{""material_code"":""b003"",""material_name"":""果糖"",""material_value"":""10.00"",""material_unit"":""cc"",""print_bill"":""N"",""is_display"":""N"",""formula_list"":[{""condiment_code"":""I0001"",""condiment_name"":""少冰"",""operator_key"":""+"",""operator_value"":""1.00"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""S0001"",""condiment_name"":""少糖"",""operator_key"":""+"",""operator_value"":""8.00"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""S0002"",""condiment_name"":""半糖"",""operator_key"":""+"",""operator_value"":""6.00"",""to_change_code"":null,""unit_name"":""cc""}]},{""material_code"":""b005"",""material_name"":""特種金萱"",""material_value"":""550.00"",""material_unit"":""cc"",""print_bill"":""N"",""is_display"":""N"",""formula_list"":[{""condiment_code"":""I0001"",""condiment_name"":""少冰"",""operator_key"":""+"",""operator_value"":""2.00"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""I0002"",""condiment_name"":""微冰"",""operator_key"":""+"",""operator_value"":""4.00"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""S0001"",""condiment_name"":""少糖"",""operator_key"":""+"",""operator_value"":""20.00"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""S0002"",""condiment_name"":""半糖"",""operator_key"":""+"",""operator_value"":""16.00"",""to_change_code"":null,""unit_name"":""cc""}]}]},""F06-L"":{""product_code"":""F06-L"",""product_name"":""初露高山茶(大)"",""material_list"":[{""material_code"":""G002"",""material_name"":""水"",""material_value"":""10.00"",""material_unit"":""cc"",""print_bill"":""N"",""is_display"":""N"",""formula_list"":[{""condiment_code"":""I0001"",""condiment_name"":""少冰"",""operator_key"":""-"",""operator_value"":""2.00"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""S0001"",""condiment_name"":""少糖"",""operator_key"":""-"",""operator_value"":""2.00"",""to_change_code"":null,""unit_name"":""cc""}]},{""material_code"":""G003"",""material_name"":""冰塊"",""material_value"":""1.00"",""material_unit"":""杯"",""print_bill"":""N"",""is_display"":""N""},{""material_code"":""b004"",""material_name"":""高山茶"",""material_value"":""500.00"",""material_unit"":""cc"",""print_bill"":""N"",""is_display"":""N"",""formula_list"":[{""condiment_code"":""I0001"",""condiment_name"":""少冰"",""operator_key"":""-"",""operator_value"":""11.00"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""S0001"",""condiment_name"":""少糖"",""operator_key"":""-"",""operator_value"":""10.00"",""to_change_code"":null,""unit_name"":""cc""}]}]},""B05L"":{""product_code"":""B05L"",""product_name"":""宇治鮮奶抹茶"",""material_list"":[{""material_code"":""M001"",""material_name"":""鮮奶"",""material_value"":""400.00"",""material_unit"":""cc"",""print_bill"":""N"",""is_display"":""N"",""formula_list"":[{""condiment_code"":""I0001"",""condiment_name"":""少冰"",""operator_key"":""+"",""operator_value"":""10.00"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""I0002"",""condiment_name"":""微冰"",""operator_key"":""+"",""operator_value"":""15.00"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""I0003"",""condiment_name"":""去冰"",""operator_key"":""+"",""operator_value"":""20.00"",""to_change_code"":null,""unit_name"":""cc""}]},{""material_code"":""b003"",""material_name"":""果糖"",""material_value"":""10.00"",""material_unit"":""cc"",""print_bill"":""N"",""is_display"":""N"",""formula_list"":[{""condiment_code"":""I0001"",""condiment_name"":""少冰"",""operator_key"":""+"",""operator_value"":""2.00"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""I0002"",""condiment_name"":""微冰"",""operator_key"":""+"",""operator_value"":""1.50"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""I0003"",""condiment_name"":""去冰"",""operator_key"":""+"",""operator_value"":""1.10"",""to_change_code"":null,""unit_name"":""cc""}]},{""material_code"":""G002"",""material_name"":""水"",""material_value"":""50.00"",""material_unit"":""cc"",""print_bill"":""N"",""is_display"":""N""},{""material_code"":""G003"",""material_name"":""冰塊"",""material_value"":""1.00"",""material_unit"":""杯"",""print_bill"":""N"",""is_display"":""N""}]},""1010-L"":{""product_code"":""1010-L"",""product_name"":""養樂多綠(大)"",""material_list"":[{""material_code"":""G003"",""material_name"":""冰塊"",""material_value"":""3.00"",""material_unit"":""杯"",""print_bill"":""N"",""is_display"":""N"",""formula_list"":[{""condiment_code"":""I0001"",""condiment_name"":""少冰"",""operator_key"":""*"",""operator_value"":""0.80"",""to_change_code"":null,""unit_name"":""杯""},{""condiment_code"":""I0002"",""condiment_name"":""微冰"",""operator_key"":""-"",""operator_value"":""1.00"",""to_change_code"":null,""unit_name"":""杯""},{""condiment_code"":""I0003"",""condiment_name"":""去冰"",""operator_key"":""="",""operator_value"":""1.00"",""to_change_code"":null,""unit_name"":""杯""},{""condiment_code"":""Q001"",""condiment_name"":""珍珠"",""operator_key"":""="",""operator_value"":""2.50"",""to_change_code"":null,""unit_name"":""杯""},{""condiment_code"":""Q002"",""condiment_name"":""3Q"",""operator_key"":""="",""operator_value"":""2.50"",""to_change_code"":null,""unit_name"":""杯""},{""condiment_code"":""Q003"",""condiment_name"":""椰果2"",""operator_key"":""*"",""operator_value"":""0.80"",""to_change_code"":null,""unit_name"":""杯""}]},{""material_code"":""b003"",""material_name"":""果糖"",""material_value"":""20.00"",""material_unit"":""cc"",""print_bill"":""N"",""is_display"":""N"",""formula_list"":[{""condiment_code"":""S0001"",""condiment_name"":""少糖"",""operator_key"":""="",""operator_value"":""15.00"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""S0002"",""condiment_name"":""半糖"",""operator_key"":""*"",""operator_value"":""0.60"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""S0003"",""condiment_name"":""微糖"",""operator_key"":""*"",""operator_value"":""0.30"",""to_change_code"":null,""unit_name"":""cc""}]},{""material_code"":""W001"",""material_name"":""養樂多"",""material_value"":""3.00"",""material_unit"":""罐"",""print_bill"":""N"",""is_display"":""N""},{""material_code"":""b002"",""material_name"":""綠茶"",""material_value"":""200.00"",""material_unit"":""cc"",""print_bill"":""N"",""is_display"":""N""}],""decline_list"":[{""decline_level"":""1"",""to_product_code"":""1010-L"",""to_product_name"":""養樂多綠(大)""}]},""F05-L"":{""product_code"":""F05-L"",""product_name"":""翠玉金萱(大)"",""material_list"":[{""material_code"":""G003"",""material_name"":""冰塊"",""material_value"":""3.00"",""material_unit"":""杯"",""print_bill"":""N"",""is_display"":""N"",""formula_list"":[{""condiment_code"":""I0001"",""condiment_name"":""少冰"",""operator_key"":""*"",""operator_value"":""0.80"",""to_change_code"":null,""unit_name"":""杯""},{""condiment_code"":""I0002"",""condiment_name"":""微冰"",""operator_key"":""*"",""operator_value"":""0.30"",""to_change_code"":null,""unit_name"":""杯""},{""condiment_code"":""I0003"",""condiment_name"":""去冰"",""operator_key"":""*"",""operator_value"":""0.30"",""to_change_code"":null,""unit_name"":""杯""},{""condiment_code"":""I0004"",""condiment_name"":""多冰"",""operator_key"":""*"",""operator_value"":""1.20"",""to_change_code"":null,""unit_name"":""杯""}]},{""material_code"":""A003"",""material_name"":""660塑膠杯"",""material_value"":""1.00"",""material_unit"":""個"",""print_bill"":""N"",""is_display"":""N""},{""material_code"":""b003"",""material_name"":""果糖"",""material_value"":""35.00"",""material_unit"":""cc"",""print_bill"":""N"",""is_display"":""N""},{""material_code"":""b005"",""material_name"":""特種金萱"",""material_value"":""500.00"",""material_unit"":""cc"",""print_bill"":""N"",""is_display"":""N""}]},""1007"":{""product_code"":""1007"",""product_name"":""蜂蜜綠茶-大"",""material_list"":[{""material_code"":""b002"",""material_name"":""綠茶"",""material_value"":""350.00"",""material_unit"":""cc"",""print_bill"":""N"",""is_display"":""N"",""formula_list"":[{""condiment_code"":""Q001"",""condiment_name"":""珍珠"",""decline_level"":""Y""},{""condiment_code"":""Q002"",""condiment_name"":""3Q"",""decline_level"":""Y""},{""condiment_code"":""Q004"",""condiment_name"":""仙草"",""decline_level"":""Y""},{""condiment_code"":""Q005"",""condiment_name"":""蘆薈"",""decline_level"":""Y""},{""condiment_code"":""Q007"",""condiment_name"":""仙草+布丁+珍珠+蘆薈"",""operator_key"":null,""operator_value"":null,""to_change_code"":null,""unit_name"":""cc""}]},{""material_code"":""G001"",""material_name"":""蜂蜜"",""material_value"":""200.00"",""material_unit"":""cc"",""print_bill"":""N"",""is_display"":""N"",""formula_list"":[{""condiment_code"":""Q001"",""condiment_name"":""珍珠"",""decline_level"":""Y""},{""condiment_code"":""Q002"",""condiment_name"":""3Q"",""decline_level"":""Y""},{""condiment_code"":""Q004"",""condiment_name"":""仙草"",""decline_level"":""Y""},{""condiment_code"":""Q005"",""condiment_name"":""蘆薈"",""decline_level"":""Y""},{""condiment_code"":""Q007"",""condiment_name"":""仙草+布丁+珍珠+蘆薈"",""operator_key"":null,""operator_value"":null,""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""S0001"",""condiment_name"":""少糖"",""operator_key"":""*"",""operator_value"":""0.80"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""S0002"",""condiment_name"":""半糖"",""operator_key"":""*"",""operator_value"":""0.60"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""S0003"",""condiment_name"":""微糖"",""operator_key"":""*"",""operator_value"":""0.30"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""S0004"",""condiment_name"":""無糖"",""operator_key"":""="",""operator_value"":""0.00"",""to_change_code"":null,""unit_name"":""cc""}]},{""material_code"":""G003"",""material_name"":""冰塊"",""material_value"":""3.00"",""material_unit"":""杯"",""print_bill"":""N"",""is_display"":""N"",""formula_list"":[{""condiment_code"":""Q001"",""condiment_name"":""珍珠"",""decline_level"":""Y""},{""condiment_code"":""Q002"",""condiment_name"":""3Q"",""decline_level"":""Y""},{""condiment_code"":""Q004"",""condiment_name"":""仙草"",""decline_level"":""Y""},{""condiment_code"":""Q005"",""condiment_name"":""蘆薈"",""decline_level"":""Y""}]}],""decline_list"":[{""decline_level"":""1"",""to_product_code"":""10072"",""to_product_name"":""蜂蜜綠茶-中""}]},""10072"":{""product_code"":""10072"",""product_name"":""蜂蜜綠茶-中"",""material_list"":[{""material_code"":""b002"",""material_name"":""綠茶"",""material_value"":""200.00"",""material_unit"":""cc"",""print_bill"":""N"",""is_display"":""N"",""formula_list"":[{""condiment_code"":""Q001"",""condiment_name"":""珍珠"",""operator_key"":""-"",""operator_value"":""20.00"",""to_change_code"":null,""unit_name"":""cc""}]},{""material_code"":""G001"",""material_name"":""蜂蜜"",""material_value"":""150.00"",""material_unit"":""cc"",""print_bill"":""N"",""is_display"":""N"",""formula_list"":[{""condiment_code"":""S0001"",""condiment_name"":""少糖"",""operator_key"":""*"",""operator_value"":""0.80"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""S0002"",""condiment_name"":""半糖"",""operator_key"":""*"",""operator_value"":""0.60"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""S0003"",""condiment_name"":""微糖"",""operator_key"":""*"",""operator_value"":""0.30"",""to_change_code"":null,""unit_name"":""cc""},{""condiment_code"":""S0004"",""condiment_name"":""無糖"",""operator_key"":""="",""operator_value"":""0.00"",""to_change_code"":null,""unit_name"":""cc""}]},{""material_code"":""G003"",""material_name"":""冰塊"",""material_value"":""100.00"",""material_unit"":""杯"",""print_bill"":""N"",""is_display"":""N"",""formula_list"":[{""condiment_code"":""I0001"",""condiment_name"":""少冰"",""operator_key"":""="",""operator_value"":""2.00"",""to_change_code"":null,""unit_name"":""杯""},{""condiment_code"":""I0002"",""condiment_name"":""微冰"",""operator_key"":""*"",""operator_value"":""0.50"",""to_change_code"":null,""unit_name"":""杯""},{""condiment_code"":""I0003"",""condiment_name"":""去冰"",""operator_key"":""*"",""operator_value"":""0.30"",""to_change_code"":null,""unit_name"":""杯""},{""condiment_code"":""I0004"",""condiment_name"":""多冰"",""operator_key"":""*"",""operator_value"":""1.20"",""to_change_code"":null,""unit_name"":""杯""}]}],""decline_list"":[{""decline_level"":""1"",""to_product_code"":""1007"",""to_product_name"":""蜂蜜綠茶-大""}]},""1001"":{""product_code"":""1001"",""product_name"":""茉莉綠茶"",""material_list"":[{""material_code"":""G003"",""material_name"":""冰塊"",""material_value"":""3.00"",""material_unit"":""杯"",""print_bill"":""N"",""is_display"":""N""},{""material_code"":""b003"",""material_name"":""果糖"",""material_value"":""30.00"",""material_unit"":""匙"",""print_bill"":""N"",""is_display"":""N""}]}},""condiment_bom"":{""Q001"":{""condiment_code"":""Q001"",""condiment_name"":""珍珠"",""material_list"":[{""material_code"":""D001"",""material_name"":""波霸珍珠"",""material_value"":""1.00"",""material_unit"":""匙""}]},""Q002"":{""condiment_code"":""Q002"",""condiment_name"":""3Q"",""material_list"":[{""material_code"":""D004"",""material_name"":""QQ凍"",""material_value"":""1.00"",""material_unit"":""匙""}]},""Q003"":{""condiment_code"":""Q003"",""condiment_name"":""椰果2"",""material_list"":[{""material_code"":""D005"",""material_name"":""椰果"",""material_value"":""1.00"",""material_unit"":""匙""}]},""Q004"":{""condiment_code"":""Q004"",""condiment_name"":""仙草"",""material_list"":[{""material_code"":""D003"",""material_name"":""仙草凍"",""material_value"":""1.00"",""material_unit"":""份""}]},""Q005"":{""condiment_code"":""Q005"",""condiment_name"":""蘆薈"",""material_list"":[{""material_code"":""D002"",""material_name"":""蘆薈塊"",""material_value"":""1.00"",""material_unit"":""匙""}]}}}";

            //找出所有product_code的值 並把 對應json元件名稱換成固定的formula_obj名詞
            MatchCollection matches = Regex.Matches(strinput, @"""product_code""?:?""(([\s\S])*?)"",");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[1].Value);
                strinput = Regex.Replace(strinput, $"\"{ match.Groups[1].Value}\"?:", "\"formula_obj\":");
            }

            Console.WriteLine("\n"+ strinput);

            Pause();
        }
    }
}
/*
{"formula_data":{"E04":{"product_code":"E04","product_name":"檸檬多多","material_list":[{"material_code":"b002","material_name":"綠茶","material_value":"50.00","material_unit":"cc","print_bill":"N","is_display":"N"},{"material_code":"G003","material_name":"冰塊","material_value":"3.00","material_unit":"杯","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0001","condiment_name":"少冰","operator_key":"*","operator_value":"0.80","to_change_code":null,"unit_name":"杯"},{"condiment_code":"I0002","condiment_name":"微冰","operator_key":"*","operator_value":"0.50","to_change_code":null,"unit_name":"杯"},{"condiment_code":"I0003","condiment_name":"去冰","operator_key":"*","operator_value":"0.30","to_change_code":null,"unit_name":"杯"},{"condiment_code":"I0004","condiment_name":"多冰","operator_key":"*","operator_value":"1.20","to_change_code":null,"unit_name":"杯"}]},{"material_code":"b003","material_name":"果糖","material_value":"30.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"S0001","condiment_name":"少糖","operator_key":"*","operator_value":"0.80","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0002","condiment_name":"半糖","operator_key":"*","operator_value":"0.50","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0003","condiment_name":"微糖","operator_key":"*","operator_value":"0.30","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0004","condiment_name":"無糖","operator_key":"=","operator_value":"0.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0005","condiment_name":"多糖","operator_key":"*","operator_value":"1.20","to_change_code":null,"unit_name":"cc"}]},{"material_code":"W001","material_name":"養樂多","material_value":"3.00","material_unit":"罐","print_bill":"N","is_display":"N"}]},"F05-M":{"product_code":"F05-M","product_name":"翠玉金萱(中)","material_list":[{"material_code":"G002","material_name":"水","material_value":"50.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0001","condiment_name":"少冰","operator_key":"+","operator_value":"2.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"I0002","condiment_name":"微冰","operator_key":"+","operator_value":"4.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0001","condiment_name":"少糖","operator_key":"+","operator_value":"10.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0002","condiment_name":"半糖","operator_key":"+","operator_value":"6.00","to_change_code":null,"unit_name":"cc"}]},{"material_code":"G003","material_name":"冰塊","material_value":"1.00","material_unit":"杯","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0002","condiment_name":"微冰","operator_key":"*","operator_value":"1.50","to_change_code":null,"unit_name":"杯"}]},{"material_code":"b003","material_name":"果糖","material_value":"10.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0001","condiment_name":"少冰","operator_key":"+","operator_value":"1.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0001","condiment_name":"少糖","operator_key":"+","operator_value":"8.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0002","condiment_name":"半糖","operator_key":"+","operator_value":"6.00","to_change_code":null,"unit_name":"cc"}]},{"material_code":"b005","material_name":"特種金萱","material_value":"550.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0001","condiment_name":"少冰","operator_key":"+","operator_value":"2.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"I0002","condiment_name":"微冰","operator_key":"+","operator_value":"4.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0001","condiment_name":"少糖","operator_key":"+","operator_value":"20.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0002","condiment_name":"半糖","operator_key":"+","operator_value":"16.00","to_change_code":null,"unit_name":"cc"}]}]},"F06-L":{"product_code":"F06-L","product_name":"初露高山茶(大)","material_list":[{"material_code":"G002","material_name":"水","material_value":"10.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0001","condiment_name":"少冰","operator_key":"-","operator_value":"2.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0001","condiment_name":"少糖","operator_key":"-","operator_value":"2.00","to_change_code":null,"unit_name":"cc"}]},{"material_code":"G003","material_name":"冰塊","material_value":"1.00","material_unit":"杯","print_bill":"N","is_display":"N"},{"material_code":"b004","material_name":"高山茶","material_value":"500.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0001","condiment_name":"少冰","operator_key":"-","operator_value":"11.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0001","condiment_name":"少糖","operator_key":"-","operator_value":"10.00","to_change_code":null,"unit_name":"cc"}]}]},"B05L":{"product_code":"B05L","product_name":"宇治鮮奶抹茶","material_list":[{"material_code":"M001","material_name":"鮮奶","material_value":"400.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0001","condiment_name":"少冰","operator_key":"+","operator_value":"10.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"I0002","condiment_name":"微冰","operator_key":"+","operator_value":"15.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"I0003","condiment_name":"去冰","operator_key":"+","operator_value":"20.00","to_change_code":null,"unit_name":"cc"}]},{"material_code":"b003","material_name":"果糖","material_value":"10.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0001","condiment_name":"少冰","operator_key":"+","operator_value":"2.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"I0002","condiment_name":"微冰","operator_key":"+","operator_value":"1.50","to_change_code":null,"unit_name":"cc"},{"condiment_code":"I0003","condiment_name":"去冰","operator_key":"+","operator_value":"1.10","to_change_code":null,"unit_name":"cc"}]},{"material_code":"G002","material_name":"水","material_value":"50.00","material_unit":"cc","print_bill":"N","is_display":"N"},{"material_code":"G003","material_name":"冰塊","material_value":"1.00","material_unit":"杯","print_bill":"N","is_display":"N"}]},"1010-L":{"product_code":"1010-L","product_name":"養樂多綠(大)","material_list":[{"material_code":"G003","material_name":"冰塊","material_value":"3.00","material_unit":"杯","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0001","condiment_name":"少冰","operator_key":"*","operator_value":"0.80","to_change_code":null,"unit_name":"杯"},{"condiment_code":"I0002","condiment_name":"微冰","operator_key":"-","operator_value":"1.00","to_change_code":null,"unit_name":"杯"},{"condiment_code":"I0003","condiment_name":"去冰","operator_key":"=","operator_value":"1.00","to_change_code":null,"unit_name":"杯"},{"condiment_code":"Q001","condiment_name":"珍珠","operator_key":"=","operator_value":"2.50","to_change_code":null,"unit_name":"杯"},{"condiment_code":"Q002","condiment_name":"3Q","operator_key":"=","operator_value":"2.50","to_change_code":null,"unit_name":"杯"},{"condiment_code":"Q003","condiment_name":"椰果2","operator_key":"*","operator_value":"0.80","to_change_code":null,"unit_name":"杯"}]},{"material_code":"b003","material_name":"果糖","material_value":"20.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"S0001","condiment_name":"少糖","operator_key":"=","operator_value":"15.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0002","condiment_name":"半糖","operator_key":"*","operator_value":"0.60","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0003","condiment_name":"微糖","operator_key":"*","operator_value":"0.30","to_change_code":null,"unit_name":"cc"}]},{"material_code":"W001","material_name":"養樂多","material_value":"3.00","material_unit":"罐","print_bill":"N","is_display":"N"},{"material_code":"b002","material_name":"綠茶","material_value":"200.00","material_unit":"cc","print_bill":"N","is_display":"N"}],"decline_list":[{"decline_level":"1","to_product_code":"1010-L","to_product_name":"養樂多綠(大)"}]},"F05-L":{"product_code":"F05-L","product_name":"翠玉金萱(大)","material_list":[{"material_code":"G003","material_name":"冰塊","material_value":"3.00","material_unit":"杯","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0001","condiment_name":"少冰","operator_key":"*","operator_value":"0.80","to_change_code":null,"unit_name":"杯"},{"condiment_code":"I0002","condiment_name":"微冰","operator_key":"*","operator_value":"0.30","to_change_code":null,"unit_name":"杯"},{"condiment_code":"I0003","condiment_name":"去冰","operator_key":"*","operator_value":"0.30","to_change_code":null,"unit_name":"杯"},{"condiment_code":"I0004","condiment_name":"多冰","operator_key":"*","operator_value":"1.20","to_change_code":null,"unit_name":"杯"}]},{"material_code":"A003","material_name":"660塑膠杯","material_value":"1.00","material_unit":"個","print_bill":"N","is_display":"N"},{"material_code":"b003","material_name":"果糖","material_value":"35.00","material_unit":"cc","print_bill":"N","is_display":"N"},{"material_code":"b005","material_name":"特種金萱","material_value":"500.00","material_unit":"cc","print_bill":"N","is_display":"N"}]},"1007":{"product_code":"1007","product_name":"蜂蜜綠茶-大","material_list":[{"material_code":"b002","material_name":"綠茶","material_value":"350.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"Q001","condiment_name":"珍珠","decline_level":"Y"},{"condiment_code":"Q002","condiment_name":"3Q","decline_level":"Y"},{"condiment_code":"Q004","condiment_name":"仙草","decline_level":"Y"},{"condiment_code":"Q005","condiment_name":"蘆薈","decline_level":"Y"},{"condiment_code":"Q007","condiment_name":"仙草+布丁+珍珠+蘆薈","operator_key":null,"operator_value":null,"to_change_code":null,"unit_name":"cc"}]},{"material_code":"G001","material_name":"蜂蜜","material_value":"200.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"Q001","condiment_name":"珍珠","decline_level":"Y"},{"condiment_code":"Q002","condiment_name":"3Q","decline_level":"Y"},{"condiment_code":"Q004","condiment_name":"仙草","decline_level":"Y"},{"condiment_code":"Q005","condiment_name":"蘆薈","decline_level":"Y"},{"condiment_code":"Q007","condiment_name":"仙草+布丁+珍珠+蘆薈","operator_key":null,"operator_value":null,"to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0001","condiment_name":"少糖","operator_key":"*","operator_value":"0.80","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0002","condiment_name":"半糖","operator_key":"*","operator_value":"0.60","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0003","condiment_name":"微糖","operator_key":"*","operator_value":"0.30","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0004","condiment_name":"無糖","operator_key":"=","operator_value":"0.00","to_change_code":null,"unit_name":"cc"}]},{"material_code":"G003","material_name":"冰塊","material_value":"3.00","material_unit":"杯","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"Q001","condiment_name":"珍珠","decline_level":"Y"},{"condiment_code":"Q002","condiment_name":"3Q","decline_level":"Y"},{"condiment_code":"Q004","condiment_name":"仙草","decline_level":"Y"},{"condiment_code":"Q005","condiment_name":"蘆薈","decline_level":"Y"}]}],"decline_list":[{"decline_level":"1","to_product_code":"10072","to_product_name":"蜂蜜綠茶-中"}]},"10072":{"product_code":"10072","product_name":"蜂蜜綠茶-中","material_list":[{"material_code":"b002","material_name":"綠茶","material_value":"200.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"Q001","condiment_name":"珍珠","operator_key":"-","operator_value":"20.00","to_change_code":null,"unit_name":"cc"}]},{"material_code":"G001","material_name":"蜂蜜","material_value":"150.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"S0001","condiment_name":"少糖","operator_key":"*","operator_value":"0.80","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0002","condiment_name":"半糖","operator_key":"*","operator_value":"0.60","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0003","condiment_name":"微糖","operator_key":"*","operator_value":"0.30","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0004","condiment_name":"無糖","operator_key":"=","operator_value":"0.00","to_change_code":null,"unit_name":"cc"}]},{"material_code":"G003","material_name":"冰塊","material_value":"100.00","material_unit":"杯","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0001","condiment_name":"少冰","operator_key":"=","operator_value":"2.00","to_change_code":null,"unit_name":"杯"},{"condiment_code":"I0002","condiment_name":"微冰","operator_key":"*","operator_value":"0.50","to_change_code":null,"unit_name":"杯"},{"condiment_code":"I0003","condiment_name":"去冰","operator_key":"*","operator_value":"0.30","to_change_code":null,"unit_name":"杯"},{"condiment_code":"I0004","condiment_name":"多冰","operator_key":"*","operator_value":"1.20","to_change_code":null,"unit_name":"杯"}]}],"decline_list":[{"decline_level":"1","to_product_code":"1007","to_product_name":"蜂蜜綠茶-大"}]},"1001":{"product_code":"1001","product_name":"茉莉綠茶","material_list":[{"material_code":"G003","material_name":"冰塊","material_value":"3.00","material_unit":"杯","print_bill":"N","is_display":"N"},{"material_code":"b003","material_name":"果糖","material_value":"30.00","material_unit":"匙","print_bill":"N","is_display":"N"}]}},"condiment_bom":{"Q001":{"condiment_code":"Q001","condiment_name":"珍珠","material_list":[{"material_code":"D001","material_name":"波霸珍珠","material_value":"1.00","material_unit":"匙"}]},"Q002":{"condiment_code":"Q002","condiment_name":"3Q","material_list":[{"material_code":"D004","material_name":"QQ凍","material_value":"1.00","material_unit":"匙"}]},"Q003":{"condiment_code":"Q003","condiment_name":"椰果2","material_list":[{"material_code":"D005","material_name":"椰果","material_value":"1.00","material_unit":"匙"}]},"Q004":{"condiment_code":"Q004","condiment_name":"仙草","material_list":[{"material_code":"D003","material_name":"仙草凍","material_value":"1.00","material_unit":"份"}]},"Q005":{"condiment_code":"Q005","condiment_name":"蘆薈","material_list":[{"material_code":"D002","material_name":"蘆薈塊","material_value":"1.00","material_unit":"匙"}]}}}
{
	"formula_data": {
		"E04": {
			"product_code": "E04",
			"product_name": "檸檬多多",
			"material_list": [
				{
					"material_code": "b002",
					"material_name": "綠茶",
					"material_value": "50.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N"
				},
				{
					"material_code": "G003",
					"material_name": "冰塊",
					"material_value": "3.00",
					"material_unit": "杯",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0001",
							"condiment_name": "少冰",
							"operator_key": "*",
							"operator_value": "0.80",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "I0002",
							"condiment_name": "微冰",
							"operator_key": "*",
							"operator_value": "0.50",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "I0003",
							"condiment_name": "去冰",
							"operator_key": "*",
							"operator_value": "0.30",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "I0004",
							"condiment_name": "多冰",
							"operator_key": "*",
							"operator_value": "1.20",
							"to_change_code": null,
							"unit_name": "杯"
						}
					]
				},
				{
					"material_code": "b003",
					"material_name": "果糖",
					"material_value": "30.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "S0001",
							"condiment_name": "少糖",
							"operator_key": "*",
							"operator_value": "0.80",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0002",
							"condiment_name": "半糖",
							"operator_key": "*",
							"operator_value": "0.50",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0003",
							"condiment_name": "微糖",
							"operator_key": "*",
							"operator_value": "0.30",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0004",
							"condiment_name": "無糖",
							"operator_key": "=",
							"operator_value": "0.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0005",
							"condiment_name": "多糖",
							"operator_key": "*",
							"operator_value": "1.20",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				},
				{
					"material_code": "W001",
					"material_name": "養樂多",
					"material_value": "3.00",
					"material_unit": "罐",
					"print_bill": "N",
					"is_display": "N"
				}
			]
		},
		"F05-M": {
			"product_code": "F05-M",
			"product_name": "翠玉金萱(中)",
			"material_list": [
				{
					"material_code": "G002",
					"material_name": "水",
					"material_value": "50.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0001",
							"condiment_name": "少冰",
							"operator_key": "+",
							"operator_value": "2.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "I0002",
							"condiment_name": "微冰",
							"operator_key": "+",
							"operator_value": "4.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0001",
							"condiment_name": "少糖",
							"operator_key": "+",
							"operator_value": "10.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0002",
							"condiment_name": "半糖",
							"operator_key": "+",
							"operator_value": "6.00",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				},
				{
					"material_code": "G003",
					"material_name": "冰塊",
					"material_value": "1.00",
					"material_unit": "杯",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0002",
							"condiment_name": "微冰",
							"operator_key": "*",
							"operator_value": "1.50",
							"to_change_code": null,
							"unit_name": "杯"
						}
					]
				},
				{
					"material_code": "b003",
					"material_name": "果糖",
					"material_value": "10.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0001",
							"condiment_name": "少冰",
							"operator_key": "+",
							"operator_value": "1.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0001",
							"condiment_name": "少糖",
							"operator_key": "+",
							"operator_value": "8.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0002",
							"condiment_name": "半糖",
							"operator_key": "+",
							"operator_value": "6.00",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				},
				{
					"material_code": "b005",
					"material_name": "特種金萱",
					"material_value": "550.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0001",
							"condiment_name": "少冰",
							"operator_key": "+",
							"operator_value": "2.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "I0002",
							"condiment_name": "微冰",
							"operator_key": "+",
							"operator_value": "4.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0001",
							"condiment_name": "少糖",
							"operator_key": "+",
							"operator_value": "20.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0002",
							"condiment_name": "半糖",
							"operator_key": "+",
							"operator_value": "16.00",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				}
			]
		},
		"F06-L": {
			"product_code": "F06-L",
			"product_name": "初露高山茶(大)",
			"material_list": [
				{
					"material_code": "G002",
					"material_name": "水",
					"material_value": "10.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0001",
							"condiment_name": "少冰",
							"operator_key": "-",
							"operator_value": "2.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0001",
							"condiment_name": "少糖",
							"operator_key": "-",
							"operator_value": "2.00",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				},
				{
					"material_code": "G003",
					"material_name": "冰塊",
					"material_value": "1.00",
					"material_unit": "杯",
					"print_bill": "N",
					"is_display": "N"
				},
				{
					"material_code": "b004",
					"material_name": "高山茶",
					"material_value": "500.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0001",
							"condiment_name": "少冰",
							"operator_key": "-",
							"operator_value": "11.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0001",
							"condiment_name": "少糖",
							"operator_key": "-",
							"operator_value": "10.00",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				}
			]
		},
		"B05L": {
			"product_code": "B05L",
			"product_name": "宇治鮮奶抹茶",
			"material_list": [
				{
					"material_code": "M001",
					"material_name": "鮮奶",
					"material_value": "400.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0001",
							"condiment_name": "少冰",
							"operator_key": "+",
							"operator_value": "10.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "I0002",
							"condiment_name": "微冰",
							"operator_key": "+",
							"operator_value": "15.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "I0003",
							"condiment_name": "去冰",
							"operator_key": "+",
							"operator_value": "20.00",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				},
				{
					"material_code": "b003",
					"material_name": "果糖",
					"material_value": "10.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0001",
							"condiment_name": "少冰",
							"operator_key": "+",
							"operator_value": "2.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "I0002",
							"condiment_name": "微冰",
							"operator_key": "+",
							"operator_value": "1.50",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "I0003",
							"condiment_name": "去冰",
							"operator_key": "+",
							"operator_value": "1.10",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				},
				{
					"material_code": "G002",
					"material_name": "水",
					"material_value": "50.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N"
				},
				{
					"material_code": "G003",
					"material_name": "冰塊",
					"material_value": "1.00",
					"material_unit": "杯",
					"print_bill": "N",
					"is_display": "N"
				}
			]
		},
		"1010-L": {
			"product_code": "1010-L",
			"product_name": "養樂多綠(大)",
			"material_list": [
				{
					"material_code": "G003",
					"material_name": "冰塊",
					"material_value": "3.00",
					"material_unit": "杯",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0001",
							"condiment_name": "少冰",
							"operator_key": "*",
							"operator_value": "0.80",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "I0002",
							"condiment_name": "微冰",
							"operator_key": "-",
							"operator_value": "1.00",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "I0003",
							"condiment_name": "去冰",
							"operator_key": "=",
							"operator_value": "1.00",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "Q001",
							"condiment_name": "珍珠",
							"operator_key": "=",
							"operator_value": "2.50",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "Q002",
							"condiment_name": "3Q",
							"operator_key": "=",
							"operator_value": "2.50",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "Q003",
							"condiment_name": "椰果2",
							"operator_key": "*",
							"operator_value": "0.80",
							"to_change_code": null,
							"unit_name": "杯"
						}
					]
				},
				{
					"material_code": "b003",
					"material_name": "果糖",
					"material_value": "20.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "S0001",
							"condiment_name": "少糖",
							"operator_key": "=",
							"operator_value": "15.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0002",
							"condiment_name": "半糖",
							"operator_key": "*",
							"operator_value": "0.60",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0003",
							"condiment_name": "微糖",
							"operator_key": "*",
							"operator_value": "0.30",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				},
				{
					"material_code": "W001",
					"material_name": "養樂多",
					"material_value": "3.00",
					"material_unit": "罐",
					"print_bill": "N",
					"is_display": "N"
				},
				{
					"material_code": "b002",
					"material_name": "綠茶",
					"material_value": "200.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N"
				}
			],
			"decline_list": [
				{
					"decline_level": "1",
					"to_product_code": "1010-L",
					"to_product_name": "養樂多綠(大)"
				}
			]
		},
		"F05-L": {
			"product_code": "F05-L",
			"product_name": "翠玉金萱(大)",
			"material_list": [
				{
					"material_code": "G003",
					"material_name": "冰塊",
					"material_value": "3.00",
					"material_unit": "杯",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0001",
							"condiment_name": "少冰",
							"operator_key": "*",
							"operator_value": "0.80",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "I0002",
							"condiment_name": "微冰",
							"operator_key": "*",
							"operator_value": "0.30",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "I0003",
							"condiment_name": "去冰",
							"operator_key": "*",
							"operator_value": "0.30",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "I0004",
							"condiment_name": "多冰",
							"operator_key": "*",
							"operator_value": "1.20",
							"to_change_code": null,
							"unit_name": "杯"
						}
					]
				},
				{
					"material_code": "A003",
					"material_name": "660塑膠杯",
					"material_value": "1.00",
					"material_unit": "個",
					"print_bill": "N",
					"is_display": "N"
				},
				{
					"material_code": "b003",
					"material_name": "果糖",
					"material_value": "35.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N"
				},
				{
					"material_code": "b005",
					"material_name": "特種金萱",
					"material_value": "500.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N"
				}
			]
		},
		"1007": {
			"product_code": "1007",
			"product_name": "蜂蜜綠茶-大",
			"material_list": [
				{
					"material_code": "b002",
					"material_name": "綠茶",
					"material_value": "350.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "Q001",
							"condiment_name": "珍珠",
							"decline_level": "Y"
						},
						{
							"condiment_code": "Q002",
							"condiment_name": "3Q",
							"decline_level": "Y"
						},
						{
							"condiment_code": "Q004",
							"condiment_name": "仙草",
							"decline_level": "Y"
						},
						{
							"condiment_code": "Q005",
							"condiment_name": "蘆薈",
							"decline_level": "Y"
						},
						{
							"condiment_code": "Q007",
							"condiment_name": "仙草+布丁+珍珠+蘆薈",
							"operator_key": null,
							"operator_value": null,
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				},
				{
					"material_code": "G001",
					"material_name": "蜂蜜",
					"material_value": "200.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "Q001",
							"condiment_name": "珍珠",
							"decline_level": "Y"
						},
						{
							"condiment_code": "Q002",
							"condiment_name": "3Q",
							"decline_level": "Y"
						},
						{
							"condiment_code": "Q004",
							"condiment_name": "仙草",
							"decline_level": "Y"
						},
						{
							"condiment_code": "Q005",
							"condiment_name": "蘆薈",
							"decline_level": "Y"
						},
						{
							"condiment_code": "Q007",
							"condiment_name": "仙草+布丁+珍珠+蘆薈",
							"operator_key": null,
							"operator_value": null,
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0001",
							"condiment_name": "少糖",
							"operator_key": "*",
							"operator_value": "0.80",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0002",
							"condiment_name": "半糖",
							"operator_key": "*",
							"operator_value": "0.60",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0003",
							"condiment_name": "微糖",
							"operator_key": "*",
							"operator_value": "0.30",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0004",
							"condiment_name": "無糖",
							"operator_key": "=",
							"operator_value": "0.00",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				},
				{
					"material_code": "G003",
					"material_name": "冰塊",
					"material_value": "3.00",
					"material_unit": "杯",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "Q001",
							"condiment_name": "珍珠",
							"decline_level": "Y"
						},
						{
							"condiment_code": "Q002",
							"condiment_name": "3Q",
							"decline_level": "Y"
						},
						{
							"condiment_code": "Q004",
							"condiment_name": "仙草",
							"decline_level": "Y"
						},
						{
							"condiment_code": "Q005",
							"condiment_name": "蘆薈",
							"decline_level": "Y"
						}
					]
				}
			],
			"decline_list": [
				{
					"decline_level": "1",
					"to_product_code": "10072",
					"to_product_name": "蜂蜜綠茶-中"
				}
			]
		},
		"10072": {
			"product_code": "10072",
			"product_name": "蜂蜜綠茶-中",
			"material_list": [
				{
					"material_code": "b002",
					"material_name": "綠茶",
					"material_value": "200.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "Q001",
							"condiment_name": "珍珠",
							"operator_key": "-",
							"operator_value": "20.00",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				},
				{
					"material_code": "G001",
					"material_name": "蜂蜜",
					"material_value": "150.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "S0001",
							"condiment_name": "少糖",
							"operator_key": "*",
							"operator_value": "0.80",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0002",
							"condiment_name": "半糖",
							"operator_key": "*",
							"operator_value": "0.60",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0003",
							"condiment_name": "微糖",
							"operator_key": "*",
							"operator_value": "0.30",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0004",
							"condiment_name": "無糖",
							"operator_key": "=",
							"operator_value": "0.00",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				},
				{
					"material_code": "G003",
					"material_name": "冰塊",
					"material_value": "100.00",
					"material_unit": "杯",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0001",
							"condiment_name": "少冰",
							"operator_key": "=",
							"operator_value": "2.00",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "I0002",
							"condiment_name": "微冰",
							"operator_key": "*",
							"operator_value": "0.50",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "I0003",
							"condiment_name": "去冰",
							"operator_key": "*",
							"operator_value": "0.30",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "I0004",
							"condiment_name": "多冰",
							"operator_key": "*",
							"operator_value": "1.20",
							"to_change_code": null,
							"unit_name": "杯"
						}
					]
				}
			],
			"decline_list": [
				{
					"decline_level": "1",
					"to_product_code": "1007",
					"to_product_name": "蜂蜜綠茶-大"
				}
			]
		},
		"1001": {
			"product_code": "1001",
			"product_name": "茉莉綠茶",
			"material_list": [
				{
					"material_code": "G003",
					"material_name": "冰塊",
					"material_value": "3.00",
					"material_unit": "杯",
					"print_bill": "N",
					"is_display": "N"
				},
				{
					"material_code": "b003",
					"material_name": "果糖",
					"material_value": "30.00",
					"material_unit": "匙",
					"print_bill": "N",
					"is_display": "N"
				}
			]
		}
	},
	"condiment_bom": {
		"Q001": {
			"condiment_code": "Q001",
			"condiment_name": "珍珠",
			"material_list": [
				{
					"material_code": "D001",
					"material_name": "波霸珍珠",
					"material_value": "1.00",
					"material_unit": "匙"
				}
			]
		},
		"Q002": {
			"condiment_code": "Q002",
			"condiment_name": "3Q",
			"material_list": [
				{
					"material_code": "D004",
					"material_name": "QQ凍",
					"material_value": "1.00",
					"material_unit": "匙"
				}
			]
		},
		"Q003": {
			"condiment_code": "Q003",
			"condiment_name": "椰果2",
			"material_list": [
				{
					"material_code": "D005",
					"material_name": "椰果",
					"material_value": "1.00",
					"material_unit": "匙"
				}
			]
		},
		"Q004": {
			"condiment_code": "Q004",
			"condiment_name": "仙草",
			"material_list": [
				{
					"material_code": "D003",
					"material_name": "仙草凍",
					"material_value": "1.00",
					"material_unit": "份"
				}
			]
		},
		"Q005": {
			"condiment_code": "Q005",
			"condiment_name": "蘆薈",
			"material_list": [
				{
					"material_code": "D002",
					"material_name": "蘆薈塊",
					"material_value": "1.00",
					"material_unit": "匙"
				}
			]
		}
	}
}

---------------------------------------

{"formula_data":{"formula_obj":{"product_code":"E04","product_name":"檸檬多多","material_list":[{"material_code":"b002","material_name":"綠茶","material_value":"50.00","material_unit":"cc","print_bill":"N","is_display":"N"},{"material_code":"G003","material_name":"冰塊","material_value":"3.00","material_unit":"杯","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0001","condiment_name":"少冰","operator_key":"*","operator_value":"0.80","to_change_code":null,"unit_name":"杯"},{"condiment_code":"I0002","condiment_name":"微冰","operator_key":"*","operator_value":"0.50","to_change_code":null,"unit_name":"杯"},{"condiment_code":"I0003","condiment_name":"去冰","operator_key":"*","operator_value":"0.30","to_change_code":null,"unit_name":"杯"},{"condiment_code":"I0004","condiment_name":"多冰","operator_key":"*","operator_value":"1.20","to_change_code":null,"unit_name":"杯"}]},{"material_code":"b003","material_name":"果糖","material_value":"30.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"S0001","condiment_name":"少糖","operator_key":"*","operator_value":"0.80","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0002","condiment_name":"半糖","operator_key":"*","operator_value":"0.50","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0003","condiment_name":"微糖","operator_key":"*","operator_value":"0.30","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0004","condiment_name":"無糖","operator_key":"=","operator_value":"0.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0005","condiment_name":"多糖","operator_key":"*","operator_value":"1.20","to_change_code":null,"unit_name":"cc"}]},{"material_code":"W001","material_name":"養樂多","material_value":"3.00","material_unit":"罐","print_bill":"N","is_display":"N"}]},"formula_obj":{"product_code":"F05-M","product_name":"翠玉金萱(中)","material_list":[{"material_code":"G002","material_name":"水","material_value":"50.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0001","condiment_name":"少冰","operator_key":"+","operator_value":"2.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"I0002","condiment_name":"微冰","operator_key":"+","operator_value":"4.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0001","condiment_name":"少糖","operator_key":"+","operator_value":"10.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0002","condiment_name":"半糖","operator_key":"+","operator_value":"6.00","to_change_code":null,"unit_name":"cc"}]},{"material_code":"G003","material_name":"冰塊","material_value":"1.00","material_unit":"杯","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0002","condiment_name":"微冰","operator_key":"*","operator_value":"1.50","to_change_code":null,"unit_name":"杯"}]},{"material_code":"b003","material_name":"果糖","material_value":"10.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0001","condiment_name":"少冰","operator_key":"+","operator_value":"1.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0001","condiment_name":"少糖","operator_key":"+","operator_value":"8.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0002","condiment_name":"半糖","operator_key":"+","operator_value":"6.00","to_change_code":null,"unit_name":"cc"}]},{"material_code":"b005","material_name":"特種金萱","material_value":"550.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0001","condiment_name":"少冰","operator_key":"+","operator_value":"2.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"I0002","condiment_name":"微冰","operator_key":"+","operator_value":"4.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0001","condiment_name":"少糖","operator_key":"+","operator_value":"20.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0002","condiment_name":"半糖","operator_key":"+","operator_value":"16.00","to_change_code":null,"unit_name":"cc"}]}]},"formula_obj":{"product_code":"F06-L","product_name":"初露高山茶(大)","material_list":[{"material_code":"G002","material_name":"水","material_value":"10.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0001","condiment_name":"少冰","operator_key":"-","operator_value":"2.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0001","condiment_name":"少糖","operator_key":"-","operator_value":"2.00","to_change_code":null,"unit_name":"cc"}]},{"material_code":"G003","material_name":"冰塊","material_value":"1.00","material_unit":"杯","print_bill":"N","is_display":"N"},{"material_code":"b004","material_name":"高山茶","material_value":"500.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0001","condiment_name":"少冰","operator_key":"-","operator_value":"11.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0001","condiment_name":"少糖","operator_key":"-","operator_value":"10.00","to_change_code":null,"unit_name":"cc"}]}]},"formula_obj":{"product_code":"B05L","product_name":"宇治鮮奶抹茶","material_list":[{"material_code":"M001","material_name":"鮮奶","material_value":"400.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0001","condiment_name":"少冰","operator_key":"+","operator_value":"10.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"I0002","condiment_name":"微冰","operator_key":"+","operator_value":"15.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"I0003","condiment_name":"去冰","operator_key":"+","operator_value":"20.00","to_change_code":null,"unit_name":"cc"}]},{"material_code":"b003","material_name":"果糖","material_value":"10.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0001","condiment_name":"少冰","operator_key":"+","operator_value":"2.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"I0002","condiment_name":"微冰","operator_key":"+","operator_value":"1.50","to_change_code":null,"unit_name":"cc"},{"condiment_code":"I0003","condiment_name":"去冰","operator_key":"+","operator_value":"1.10","to_change_code":null,"unit_name":"cc"}]},{"material_code":"G002","material_name":"水","material_value":"50.00","material_unit":"cc","print_bill":"N","is_display":"N"},{"material_code":"G003","material_name":"冰塊","material_value":"1.00","material_unit":"杯","print_bill":"N","is_display":"N"}]},"formula_obj":{"product_code":"1010-L","product_name":"養樂多綠(大)","material_list":[{"material_code":"G003","material_name":"冰塊","material_value":"3.00","material_unit":"杯","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0001","condiment_name":"少冰","operator_key":"*","operator_value":"0.80","to_change_code":null,"unit_name":"杯"},{"condiment_code":"I0002","condiment_name":"微冰","operator_key":"-","operator_value":"1.00","to_change_code":null,"unit_name":"杯"},{"condiment_code":"I0003","condiment_name":"去冰","operator_key":"=","operator_value":"1.00","to_change_code":null,"unit_name":"杯"},{"condiment_code":"Q001","condiment_name":"珍珠","operator_key":"=","operator_value":"2.50","to_change_code":null,"unit_name":"杯"},{"condiment_code":"Q002","condiment_name":"3Q","operator_key":"=","operator_value":"2.50","to_change_code":null,"unit_name":"杯"},{"condiment_code":"Q003","condiment_name":"椰果2","operator_key":"*","operator_value":"0.80","to_change_code":null,"unit_name":"杯"}]},{"material_code":"b003","material_name":"果糖","material_value":"20.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"S0001","condiment_name":"少糖","operator_key":"=","operator_value":"15.00","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0002","condiment_name":"半糖","operator_key":"*","operator_value":"0.60","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0003","condiment_name":"微糖","operator_key":"*","operator_value":"0.30","to_change_code":null,"unit_name":"cc"}]},{"material_code":"W001","material_name":"養樂多","material_value":"3.00","material_unit":"罐","print_bill":"N","is_display":"N"},{"material_code":"b002","material_name":"綠茶","material_value":"200.00","material_unit":"cc","print_bill":"N","is_display":"N"}],"decline_list":[{"decline_level":"1","to_product_code":"1010-L","to_product_name":"養樂多綠(大)"}]},"formula_obj":{"product_code":"F05-L","product_name":"翠玉金萱(大)","material_list":[{"material_code":"G003","material_name":"冰塊","material_value":"3.00","material_unit":"杯","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0001","condiment_name":"少冰","operator_key":"*","operator_value":"0.80","to_change_code":null,"unit_name":"杯"},{"condiment_code":"I0002","condiment_name":"微冰","operator_key":"*","operator_value":"0.30","to_change_code":null,"unit_name":"杯"},{"condiment_code":"I0003","condiment_name":"去冰","operator_key":"*","operator_value":"0.30","to_change_code":null,"unit_name":"杯"},{"condiment_code":"I0004","condiment_name":"多冰","operator_key":"*","operator_value":"1.20","to_change_code":null,"unit_name":"杯"}]},{"material_code":"A003","material_name":"660塑膠杯","material_value":"1.00","material_unit":"個","print_bill":"N","is_display":"N"},{"material_code":"b003","material_name":"果糖","material_value":"35.00","material_unit":"cc","print_bill":"N","is_display":"N"},{"material_code":"b005","material_name":"特種金萱","material_value":"500.00","material_unit":"cc","print_bill":"N","is_display":"N"}]},"formula_obj":{"product_code":"1007","product_name":"蜂蜜綠茶-大","material_list":[{"material_code":"b002","material_name":"綠茶","material_value":"350.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"Q001","condiment_name":"珍珠","decline_level":"Y"},{"condiment_code":"Q002","condiment_name":"3Q","decline_level":"Y"},{"condiment_code":"Q004","condiment_name":"仙草","decline_level":"Y"},{"condiment_code":"Q005","condiment_name":"蘆薈","decline_level":"Y"},{"condiment_code":"Q007","condiment_name":"仙草+布丁+珍珠+蘆薈","operator_key":null,"operator_value":null,"to_change_code":null,"unit_name":"cc"}]},{"material_code":"G001","material_name":"蜂蜜","material_value":"200.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"Q001","condiment_name":"珍珠","decline_level":"Y"},{"condiment_code":"Q002","condiment_name":"3Q","decline_level":"Y"},{"condiment_code":"Q004","condiment_name":"仙草","decline_level":"Y"},{"condiment_code":"Q005","condiment_name":"蘆薈","decline_level":"Y"},{"condiment_code":"Q007","condiment_name":"仙草+布丁+珍珠+蘆薈","operator_key":null,"operator_value":null,"to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0001","condiment_name":"少糖","operator_key":"*","operator_value":"0.80","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0002","condiment_name":"半糖","operator_key":"*","operator_value":"0.60","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0003","condiment_name":"微糖","operator_key":"*","operator_value":"0.30","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0004","condiment_name":"無糖","operator_key":"=","operator_value":"0.00","to_change_code":null,"unit_name":"cc"}]},{"material_code":"G003","material_name":"冰塊","material_value":"3.00","material_unit":"杯","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"Q001","condiment_name":"珍珠","decline_level":"Y"},{"condiment_code":"Q002","condiment_name":"3Q","decline_level":"Y"},{"condiment_code":"Q004","condiment_name":"仙草","decline_level":"Y"},{"condiment_code":"Q005","condiment_name":"蘆薈","decline_level":"Y"}]}],"decline_list":[{"decline_level":"1","to_product_code":"10072","to_product_name":"蜂蜜綠茶-中"}]},"formula_obj":{"product_code":"10072","product_name":"蜂蜜 綠茶-中","material_list":[{"material_code":"b002","material_name":"綠茶","material_value":"200.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"Q001","condiment_name":"珍珠","operator_key":"-","operator_value":"20.00","to_change_code":null,"unit_name":"cc"}]},{"material_code":"G001","material_name":"蜂蜜","material_value":"150.00","material_unit":"cc","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"S0001","condiment_name":"少糖","operator_key":"*","operator_value":"0.80","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0002","condiment_name":"半糖","operator_key":"*","operator_value":"0.60","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0003","condiment_name":"微糖","operator_key":"*","operator_value":"0.30","to_change_code":null,"unit_name":"cc"},{"condiment_code":"S0004","condiment_name":"無糖","operator_key":"=","operator_value":"0.00","to_change_code":null,"unit_name":"cc"}]},{"material_code":"G003","material_name":"冰塊","material_value":"100.00","material_unit":"杯","print_bill":"N","is_display":"N","formula_list":[{"condiment_code":"I0001","condiment_name":"少冰","operator_key":"=","operator_value":"2.00","to_change_code":null,"unit_name":"杯"},{"condiment_code":"I0002","condiment_name":"微冰","operator_key":"*","operator_value":"0.50","to_change_code":null,"unit_name":"杯"},{"condiment_code":"I0003","condiment_name":"去 冰","operator_key":"*","operator_value":"0.30","to_change_code":null,"unit_name":"杯"},{"condiment_code":"I0004","condiment_name":"多冰","operator_key":"*","operator_value":"1.20","to_change_code":null,"unit_name":"杯"}]}],"decline_list":[{"decline_level":"1","to_product_code":"1007","to_product_name":"蜂蜜綠茶-大"}]},"formula_obj":{"product_code":"1001","product_name":"茉莉綠茶","material_list":[{"material_code":"G003","material_name":"冰塊","material_value":"3.00","material_unit":"杯","print_bill":"N","is_display":"N"},{"material_code":"b003","material_name":"果糖","material_value":"30.00","material_unit":"匙","print_bill":"N","is_display":"N"}]}},"condiment_bom":{"Q001":{"condiment_code":"Q001","condiment_name":"珍珠","material_list":[{"material_code":"D001","material_name":"波霸珍珠","material_value":"1.00","material_unit":"匙"}]},"Q002":{"condiment_code":"Q002","condiment_name":"3Q","material_list":[{"material_code":"D004","material_name":"QQ凍","material_value":"1.00","material_unit":"匙"}]},"Q003":{"condiment_code":"Q003","condiment_name":"椰果2","material_list":[{"material_code":"D005","material_name":"椰果","material_value":"1.00","material_unit":"匙"}]},"Q004":{"condiment_code":"Q004","condiment_name":"仙草","material_list":[{"material_code":"D003","material_name":"仙草凍","material_value":"1.00","material_unit":"份"}]},"Q005":{"condiment_code":"Q005","condiment_name":"蘆薈","material_list":[{"material_code":"D002","material_name":"蘆薈塊","material_value":"1.00","material_unit":"匙"}]}}}

{
	"formula_data": {
		"formula_obj": {
			"product_code": "E04",
			"product_name": "檸檬多多",
			"material_list": [
				{
					"material_code": "b002",
					"material_name": "綠茶",
					"material_value": "50.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N"
				},
				{
					"material_code": "G003",
					"material_name": "冰塊",
					"material_value": "3.00",
					"material_unit": "杯",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0001",
							"condiment_name": "少冰",
							"operator_key": "*",
							"operator_value": "0.80",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "I0002",
							"condiment_name": "微冰",
							"operator_key": "*",
							"operator_value": "0.50",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "I0003",
							"condiment_name": "去冰",
							"operator_key": "*",
							"operator_value": "0.30",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "I0004",
							"condiment_name": "多冰",
							"operator_key": "*",
							"operator_value": "1.20",
							"to_change_code": null,
							"unit_name": "杯"
						}
					]
				},
				{
					"material_code": "b003",
					"material_name": "果糖",
					"material_value": "30.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "S0001",
							"condiment_name": "少糖",
							"operator_key": "*",
							"operator_value": "0.80",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0002",
							"condiment_name": "半糖",
							"operator_key": "*",
							"operator_value": "0.50",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0003",
							"condiment_name": "微糖",
							"operator_key": "*",
							"operator_value": "0.30",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0004",
							"condiment_name": "無糖",
							"operator_key": "=",
							"operator_value": "0.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0005",
							"condiment_name": "多糖",
							"operator_key": "*",
							"operator_value": "1.20",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				},
				{
					"material_code": "W001",
					"material_name": "養樂多",
					"material_value": "3.00",
					"material_unit": "罐",
					"print_bill": "N",
					"is_display": "N"
				}
			]
		},
		"formula_obj": {
			"product_code": "F05-M",
			"product_name": "翠玉金萱(中)",
			"material_list": [
				{
					"material_code": "G002",
					"material_name": "水",
					"material_value": "50.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0001",
							"condiment_name": "少冰",
							"operator_key": "+",
							"operator_value": "2.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "I0002",
							"condiment_name": "微冰",
							"operator_key": "+",
							"operator_value": "4.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0001",
							"condiment_name": "少糖",
							"operator_key": "+",
							"operator_value": "10.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0002",
							"condiment_name": "半糖",
							"operator_key": "+",
							"operator_value": "6.00",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				},
				{
					"material_code": "G003",
					"material_name": "冰塊",
					"material_value": "1.00",
					"material_unit": "杯",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0002",
							"condiment_name": "微冰",
							"operator_key": "*",
							"operator_value": "1.50",
							"to_change_code": null,
							"unit_name": "杯"
						}
					]
				},
				{
					"material_code": "b003",
					"material_name": "果糖",
					"material_value": "10.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0001",
							"condiment_name": "少冰",
							"operator_key": "+",
							"operator_value": "1.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0001",
							"condiment_name": "少糖",
							"operator_key": "+",
							"operator_value": "8.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0002",
							"condiment_name": "半糖",
							"operator_key": "+",
							"operator_value": "6.00",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				},
				{
					"material_code": "b005",
					"material_name": "特種金萱",
					"material_value": "550.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0001",
							"condiment_name": "少冰",
							"operator_key": "+",
							"operator_value": "2.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "I0002",
							"condiment_name": "微冰",
							"operator_key": "+",
							"operator_value": "4.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0001",
							"condiment_name": "少糖",
							"operator_key": "+",
							"operator_value": "20.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0002",
							"condiment_name": "半糖",
							"operator_key": "+",
							"operator_value": "16.00",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				}
			]
		},
		"formula_obj": {
			"product_code": "F06-L",
			"product_name": "初露高山茶(大)",
			"material_list": [
				{
					"material_code": "G002",
					"material_name": "水",
					"material_value": "10.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0001",
							"condiment_name": "少冰",
							"operator_key": "-",
							"operator_value": "2.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0001",
							"condiment_name": "少糖",
							"operator_key": "-",
							"operator_value": "2.00",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				},
				{
					"material_code": "G003",
					"material_name": "冰塊",
					"material_value": "1.00",
					"material_unit": "杯",
					"print_bill": "N",
					"is_display": "N"
				},
				{
					"material_code": "b004",
					"material_name": "高山茶",
					"material_value": "500.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0001",
							"condiment_name": "少冰",
							"operator_key": "-",
							"operator_value": "11.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0001",
							"condiment_name": "少糖",
							"operator_key": "-",
							"operator_value": "10.00",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				}
			]
		},
		"formula_obj": {
			"product_code": "B05L",
			"product_name": "宇治鮮奶抹茶",
			"material_list": [
				{
					"material_code": "M001",
					"material_name": "鮮奶",
					"material_value": "400.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0001",
							"condiment_name": "少冰",
							"operator_key": "+",
							"operator_value": "10.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "I0002",
							"condiment_name": "微冰",
							"operator_key": "+",
							"operator_value": "15.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "I0003",
							"condiment_name": "去冰",
							"operator_key": "+",
							"operator_value": "20.00",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				},
				{
					"material_code": "b003",
					"material_name": "果糖",
					"material_value": "10.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0001",
							"condiment_name": "少冰",
							"operator_key": "+",
							"operator_value": "2.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "I0002",
							"condiment_name": "微冰",
							"operator_key": "+",
							"operator_value": "1.50",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "I0003",
							"condiment_name": "去冰",
							"operator_key": "+",
							"operator_value": "1.10",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				},
				{
					"material_code": "G002",
					"material_name": "水",
					"material_value": "50.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N"
				},
				{
					"material_code": "G003",
					"material_name": "冰塊",
					"material_value": "1.00",
					"material_unit": "杯",
					"print_bill": "N",
					"is_display": "N"
				}
			]
		},
		"formula_obj": {
			"product_code": "1010-L",
			"product_name": "養樂多綠(大)",
			"material_list": [
				{
					"material_code": "G003",
					"material_name": "冰塊",
					"material_value": "3.00",
					"material_unit": "杯",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0001",
							"condiment_name": "少冰",
							"operator_key": "*",
							"operator_value": "0.80",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "I0002",
							"condiment_name": "微冰",
							"operator_key": "-",
							"operator_value": "1.00",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "I0003",
							"condiment_name": "去冰",
							"operator_key": "=",
							"operator_value": "1.00",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "Q001",
							"condiment_name": "珍珠",
							"operator_key": "=",
							"operator_value": "2.50",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "Q002",
							"condiment_name": "3Q",
							"operator_key": "=",
							"operator_value": "2.50",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "Q003",
							"condiment_name": "椰果2",
							"operator_key": "*",
							"operator_value": "0.80",
							"to_change_code": null,
							"unit_name": "杯"
						}
					]
				},
				{
					"material_code": "b003",
					"material_name": "果糖",
					"material_value": "20.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "S0001",
							"condiment_name": "少糖",
							"operator_key": "=",
							"operator_value": "15.00",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0002",
							"condiment_name": "半糖",
							"operator_key": "*",
							"operator_value": "0.60",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0003",
							"condiment_name": "微糖",
							"operator_key": "*",
							"operator_value": "0.30",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				},
				{
					"material_code": "W001",
					"material_name": "養樂多",
					"material_value": "3.00",
					"material_unit": "罐",
					"print_bill": "N",
					"is_display": "N"
				},
				{
					"material_code": "b002",
					"material_name": "綠茶",
					"material_value": "200.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N"
				}
			],
			"decline_list": [
				{
					"decline_level": "1",
					"to_product_code": "1010-L",
					"to_product_name": "養樂多綠(大)"
				}
			]
		},
		"formula_obj": {
			"product_code": "F05-L",
			"product_name": "翠玉金萱(大)",
			"material_list": [
				{
					"material_code": "G003",
					"material_name": "冰塊",
					"material_value": "3.00",
					"material_unit": "杯",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0001",
							"condiment_name": "少冰",
							"operator_key": "*",
							"operator_value": "0.80",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "I0002",
							"condiment_name": "微冰",
							"operator_key": "*",
							"operator_value": "0.30",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "I0003",
							"condiment_name": "去冰",
							"operator_key": "*",
							"operator_value": "0.30",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "I0004",
							"condiment_name": "多冰",
							"operator_key": "*",
							"operator_value": "1.20",
							"to_change_code": null,
							"unit_name": "杯"
						}
					]
				},
				{
					"material_code": "A003",
					"material_name": "660塑膠杯",
					"material_value": "1.00",
					"material_unit": "個",
					"print_bill": "N",
					"is_display": "N"
				},
				{
					"material_code": "b003",
					"material_name": "果糖",
					"material_value": "35.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N"
				},
				{
					"material_code": "b005",
					"material_name": "特種金萱",
					"material_value": "500.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N"
				}
			]
		},
		"formula_obj": {
			"product_code": "1007",
			"product_name": "蜂蜜綠茶-大",
			"material_list": [
				{
					"material_code": "b002",
					"material_name": "綠茶",
					"material_value": "350.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "Q001",
							"condiment_name": "珍珠",
							"decline_level": "Y"
						},
						{
							"condiment_code": "Q002",
							"condiment_name": "3Q",
							"decline_level": "Y"
						},
						{
							"condiment_code": "Q004",
							"condiment_name": "仙草",
							"decline_level": "Y"
						},
						{
							"condiment_code": "Q005",
							"condiment_name": "蘆薈",
							"decline_level": "Y"
						},
						{
							"condiment_code": "Q007",
							"condiment_name": "仙草+布丁+珍珠+蘆薈",
							"operator_key": null,
							"operator_value": null,
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				},
				{
					"material_code": "G001",
					"material_name": "蜂蜜",
					"material_value": "200.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "Q001",
							"condiment_name": "珍珠",
							"decline_level": "Y"
						},
						{
							"condiment_code": "Q002",
							"condiment_name": "3Q",
							"decline_level": "Y"
						},
						{
							"condiment_code": "Q004",
							"condiment_name": "仙草",
							"decline_level": "Y"
						},
						{
							"condiment_code": "Q005",
							"condiment_name": "蘆薈",
							"decline_level": "Y"
						},
						{
							"condiment_code": "Q007",
							"condiment_name": "仙草+布丁+珍珠+蘆薈",
							"operator_key": null,
							"operator_value": null,
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0001",
							"condiment_name": "少糖",
							"operator_key": "*",
							"operator_value": "0.80",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0002",
							"condiment_name": "半糖",
							"operator_key": "*",
							"operator_value": "0.60",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0003",
							"condiment_name": "微糖",
							"operator_key": "*",
							"operator_value": "0.30",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0004",
							"condiment_name": "無糖",
							"operator_key": "=",
							"operator_value": "0.00",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				},
				{
					"material_code": "G003",
					"material_name": "冰塊",
					"material_value": "3.00",
					"material_unit": "杯",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "Q001",
							"condiment_name": "珍珠",
							"decline_level": "Y"
						},
						{
							"condiment_code": "Q002",
							"condiment_name": "3Q",
							"decline_level": "Y"
						},
						{
							"condiment_code": "Q004",
							"condiment_name": "仙草",
							"decline_level": "Y"
						},
						{
							"condiment_code": "Q005",
							"condiment_name": "蘆薈",
							"decline_level": "Y"
						}
					]
				}
			],
			"decline_list": [
				{
					"decline_level": "1",
					"to_product_code": "10072",
					"to_product_name": "蜂蜜綠茶-中"
				}
			]
		},
		"formula_obj": {
			"product_code": "10072",
			"product_name": "蜂蜜 綠茶-中",
			"material_list": [
				{
					"material_code": "b002",
					"material_name": "綠茶",
					"material_value": "200.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "Q001",
							"condiment_name": "珍珠",
							"operator_key": "-",
							"operator_value": "20.00",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				},
				{
					"material_code": "G001",
					"material_name": "蜂蜜",
					"material_value": "150.00",
					"material_unit": "cc",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "S0001",
							"condiment_name": "少糖",
							"operator_key": "*",
							"operator_value": "0.80",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0002",
							"condiment_name": "半糖",
							"operator_key": "*",
							"operator_value": "0.60",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0003",
							"condiment_name": "微糖",
							"operator_key": "*",
							"operator_value": "0.30",
							"to_change_code": null,
							"unit_name": "cc"
						},
						{
							"condiment_code": "S0004",
							"condiment_name": "無糖",
							"operator_key": "=",
							"operator_value": "0.00",
							"to_change_code": null,
							"unit_name": "cc"
						}
					]
				},
				{
					"material_code": "G003",
					"material_name": "冰塊",
					"material_value": "100.00",
					"material_unit": "杯",
					"print_bill": "N",
					"is_display": "N",
					"formula_list": [
						{
							"condiment_code": "I0001",
							"condiment_name": "少冰",
							"operator_key": "=",
							"operator_value": "2.00",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "I0002",
							"condiment_name": "微冰",
							"operator_key": "*",
							"operator_value": "0.50",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "I0003",
							"condiment_name": "去 冰",
							"operator_key": "*",
							"operator_value": "0.30",
							"to_change_code": null,
							"unit_name": "杯"
						},
						{
							"condiment_code": "I0004",
							"condiment_name": "多冰",
							"operator_key": "*",
							"operator_value": "1.20",
							"to_change_code": null,
							"unit_name": "杯"
						}
					]
				}
			],
			"decline_list": [
				{
					"decline_level": "1",
					"to_product_code": "1007",
					"to_product_name": "蜂蜜綠茶-大"
				}
			]
		},
		"formula_obj": {
			"product_code": "1001",
			"product_name": "茉莉綠茶",
			"material_list": [
				{
					"material_code": "G003",
					"material_name": "冰塊",
					"material_value": "3.00",
					"material_unit": "杯",
					"print_bill": "N",
					"is_display": "N"
				},
				{
					"material_code": "b003",
					"material_name": "果糖",
					"material_value": "30.00",
					"material_unit": "匙",
					"print_bill": "N",
					"is_display": "N"
				}
			]
		}
	},
	"condiment_bom": {
		"Q001": {
			"condiment_code": "Q001",
			"condiment_name": "珍珠",
			"material_list": [
				{
					"material_code": "D001",
					"material_name": "波霸珍珠",
					"material_value": "1.00",
					"material_unit": "匙"
				}
			]
		},
		"Q002": {
			"condiment_code": "Q002",
			"condiment_name": "3Q",
			"material_list": [
				{
					"material_code": "D004",
					"material_name": "QQ凍",
					"material_value": "1.00",
					"material_unit": "匙"
				}
			]
		},
		"Q003": {
			"condiment_code": "Q003",
			"condiment_name": "椰果2",
			"material_list": [
				{
					"material_code": "D005",
					"material_name": "椰果",
					"material_value": "1.00",
					"material_unit": "匙"
				}
			]
		},
		"Q004": {
			"condiment_code": "Q004",
			"condiment_name": "仙草",
			"material_list": [
				{
					"material_code": "D003",
					"material_name": "仙草凍",
					"material_value": "1.00",
					"material_unit": "份"
				}
			]
		},
		"Q005": {
			"condiment_code": "Q005",
			"condiment_name": "蘆薈",
			"material_list": [
				{
					"material_code": "D002",
					"material_name": "蘆薈塊",
					"material_value": "1.00",
					"material_unit": "匙"
				}
			]
		}
	}
}
 */