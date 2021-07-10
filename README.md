# Number to Vietnamese C#

Convert numbers to Vietnamese words, written in C#. Original project: [hankphung](https://github.com/hankphung/numer_to_vietnamese_text)

## Usage

```C#
var numberToVietnamese = new NumberToVietnamese();

Console.WriteLine(numberToVietnamese.ToVietnamese(123456));
Console.WriteLine(numberToVietnamese.ToVietnamese("123456"));
```

## Result

```
5: năm
11: mười một
21: hai mươi mốt
15: mười lăm
3000: ba nghìn
278346: hai trăm bảy mươi tám nghìn ba trăm bốn mươi sáu
2000006: hai triệu không trăm lẻ sáu
123456789: một trăm hai mươi ba triệu bốn trăm năm mươi sáu nghìn bảy trăm tám mươi chín
2000000000: hai tỉ
```