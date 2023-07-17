using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/customs_duty/{price}", (int price) => TheAmountOfCustomsDuty(price));
app.MapGet("/full_date/{language}", (string language) => 
{
    DateTime now = DateTime.Now;
    CultureInfo culture = CultureInfo.GetCultureInfo(language);

    string dayOfWeek = culture.DateTimeFormat.GetDayName(now.DayOfWeek);
    string month = culture.DateTimeFormat.GetMonthName(now.Month);
    string year = now.Year.ToString();
    string time = now.ToString("HH:mm:ss");


    return $"{now.Day}, {dayOfWeek}, {month} {year}, {time}";
});

app.Run();

string TheAmountOfCustomsDuty(int price)
{
    decimal customs_duty = 0;

    if (price > 200)
    {
        customs_duty = (price - 200) * 0.15m;
    }

    return $"Стоимость посылки: {price}\nПошлина: {customs_duty}\nИтого: {price + customs_duty}";
}