using UnityEngine;

public static class EquationGeneration
{
    public static (string equation , int xValue) GenerateRandomEquation()
    {
        int equationPattern = Random.Range(0, 4);
        int a = Random.Range(1, 10);
        int b = Random.Range(2, 20);
        int x = 0;
        string equation = "";
        


        switch (equationPattern)
        {
            case 0:
                x = b - a;

                equation = $"X + {a} = {b}";
                break;

            case 1:
                x = b + a;

                 equation = $"X - {a} = {b}";
                break;

            case 2:
                x = b - a;

                equation = $"{a} + X = {b}";
                break;

            case 3:
                x = a - b;

                equation = $"{a} - X = {b}";
                break;
           
        }
        return (equation, x);
    }
}
