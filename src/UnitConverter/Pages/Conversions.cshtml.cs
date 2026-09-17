using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter.Pages;

public class ConversionsModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string Input { get; set; } = string.Empty;
    public string Output { get; set; } = string.Empty;

    [BindProperty(SupportsGet = true)]
    public string ConversionType { get; set; } = string.Empty;



    public void OnGet()
    {
        string displayName;

        if (string.IsNullOrEmpty(ConversionType))
        {
            ConversionType = "MilesToKilometers";
            displayName = "Miles to Kilometers";
            ViewData["ConversionType"] = displayName;

        }

        if (string.IsNullOrEmpty(Input))
        {
            Input = "3.1415";
        }
        ViewData["Title"] = "Conversions";
        double inputValue;
        try
        {
            inputValue  = Convert.ToDouble(Input);
        }
        catch (Exception e)
        {
            ViewData["ErrorMessage"] = "Input must be a valid number";
            return;
        }
        double result;


        switch (ConversionType)
        {
            case  "MilesToKilometers":
                displayName = "Miles to Kilometers";
                result = new UnitOf.Length()
                    .FromMiles(inputValue)
                    .ToKilometers();
                break;
            case  "KilometersToMiles":
                displayName  = "Kilometers to Miles";
                result = new UnitOf.Length()
                    .FromKilometers(inputValue)
                    .ToMiles();
                break;
            case "FahrenheitToCelsius":
                displayName = "Fahrenheit to Celsius";
                result = new UnitOf.Temperature()
                    .FromFahrenheit(inputValue)
                    .ToCelsius();
                break;
            case "CelsiusToFahrenheit":
                displayName = "Celsius to Fahrenheit";
                result = new UnitOf.Temperature()
                    .FromCelsius(inputValue)
                    .ToFahrenheit();
                break;
            case "KilogramsToPounds":
                displayName = "Kilograms to Pounds";
                result = new UnitOf.Mass()
                    .FromKilograms(inputValue)
                    .ToPounds();
                break;
            case "PoundsToKilograms":
                displayName = "Pounds to Kilograms";
                result = new UnitOf.Mass()
                    .FromPounds(inputValue)
                    .ToKilograms();
                break;
            case "SecondsToMinutes":
                displayName = "Seconds to Minutes";
                result = new UnitOf.Time()
                    .FromSeconds(inputValue)
                    .ToMinutes();
                break;
            case "MinutesToSeconds":
                displayName = "Minutes to Seconds";
                result = new UnitOf.Time()
                    .FromMinutes(inputValue)
                    .ToSeconds();
                break;
            default:
                ViewData["ErrorMessage"] = "Conversion type not recognized";
                return;
        }
        ViewData["ConversionType"] = displayName;

        Output = result.ToString();



    }
}
