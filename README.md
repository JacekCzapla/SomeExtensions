# SomeExtensions
A few extensions methods for different types.

## String

**bool IsEmpty(this string val)** Is string empty or null <br/>  
**string FirstLimit(this string val, int limit)** First chars in string, "this is string".FirstLimit(7)=> "this is"<br/>  
**string FirstLimitWithDots(this string val, int limit)** First chars in string with 3 dots in the end, "this is string".FirstLimit(7)=> "this is..."<br/>  
**bool IsInt(this string val)** in string int number (all chars are digit, no white chars spaces...) <br/>  
**bool IsDecimal(this string val)** in string decimal <br/>  
**string EncodeBase64(this string val)** <br/>  
**string DecodeBase64(this string val)** <br/>  

## DateTime

**long ToLong(this FDateTime date)**, 2023-12-01 12:23:44 => 20231201122344 as long <br/>  
**DateTime YearStart(this FDateTime date)** first day in daye.Year as DateTime, 2023-12-04 12:23:44 => 2023-01-01 00:00:00 <br/>  
**DateTime MonthStart(this DateTime d)** frist date in year and month in date year and month, 2023-12-04 12:23:44 => 2023-12-01 00:00:00 <br/>  

More in code
