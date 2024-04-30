using Microsoft.Extensions.Logging;
using System.Globalization;
using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
var builder = WebApplication.CreateBuilder(args);
ILogger logger = factory.CreateLogger("Program");
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/numberToText/${number}", (double number) =>
{
    logger.LogInformation("{number}", number);
    static string ValueToString(int value)
    {
        var singleNumbers = new Dictionary<int, string>
        {
            {1, "one"},
            {2, "two"},
            {3, "three"},
            {4, "four"},
            {5, "five"},
            {6, "six"},
            {7, "seven"},
            {8, "eight"},
            {9, "nine"},
            {10, "ten"},
            {11, "eleven"},
            {12, "twelve"},
            {13, "thirteen"},
            {14, "fourteen"},
            {15, "fifteen"},
            {16, "sixteen"},
            {17, "seventeen"},
            {18, "eighteen"},
            {19, "nineteen"},
        };

        var tens = new Dictionary<int, string>
        {
            {2, "twenty"},
            {3, "thirty"},
            {4, "forty"},
            {5, "fifty"},
            {6, "sixty"},
            {7, "seventy"},
            {8, "eighty"},
            {9, "ninety"},
        };

        if (value < 20)
        {
            return singleNumbers[value];
        }
        if (value > 20 && value < 100)
        {
            int tensValue = value / 10;
            int remainder = value % 10;
            return tens[tensValue] + " " + (remainder != 0 ? ValueToString(remainder) : "");
        }
        if (value >= 100 && value < 1000)
        {
            int hundredsValue = value / 100;
            int remainder = value % 100;
            return singleNumbers[hundredsValue] + " hundred" + (remainder != 0 ? " and " + ValueToString(remainder) : "");
        }
        if (value >= 1000)
        {
            int thousandsValue = value / 1000;
            int remainder = value % 1000;
            return singleNumbers[thousandsValue] + " thousand" + (remainder != 0 ? " and " + ValueToString(remainder) : "");
        }

        return "number out of scope";
    }

    if (Double.IsNaN(number))
    {
        return Results.Json(new { error = true, errormsg = "Not a valid number" });

    }
    if (number >= 10000)
    {
        return Results.Json(new { error = true, errormsg = "Number exceeds maximum of 9999" });

    }
    if (number == 0)
    {
        return Results.Json(new { textValue = "zero dollars" });
    }

    string convertedTextValue = "";
    var roundedVal = number.ToString("F").Split('.');
    int dollars = int.Parse(roundedVal[0]);
    int cents = int.Parse(roundedVal[1]);

    if (cents == 0)
    {
        convertedTextValue += ValueToString(dollars) + " dollars";
    }
    else
    {
        convertedTextValue += ValueToString(dollars) + " dollars" + " and " + ValueToString(cents) + " cents";
    }

    return Results.Json(new { textValue = convertedTextValue });

})
.WithName("GetNumberToText")
.WithOpenApi();


app.Run();

// public static class NumberTextConverter
// {
//     public
// }
public partial class Program { }