using System;

namespace Domain.People;

public static class GenderHelper
{
    public static Gender? GetById(int genderId)
    {
        if (Enum.IsDefined(typeof(Gender), genderId))
        {
            return (Gender)genderId;
        }
        return null; 
    }
}