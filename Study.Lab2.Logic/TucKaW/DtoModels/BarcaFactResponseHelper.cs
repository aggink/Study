using System.Collections.Generic;
using System.Text.Json;

namespace Study.Lab2.Logic.TucKaW.DtoModels;

public static class BarcaFactResponseHelper
{
    public static BarcaFactResponseDto CreateDefault()
    {
        return new BarcaFactResponseDto
        {
            Data = new List<string>
            {
                "🔵🔴 ФК Барселона основана 29 ноября 1899 года",
                "🏟 Камп Ноу - крупнейший стадион Европы (99 354 места)",
                "⭐ Легендарные игроки: Месси, Кройф, Марадона",
                "🏆 26-кратный чемпион Испании, 5-кратный победитель ЛЧ",
                "👕 Клубные цвета: синий и гранатовый (blaugrana)"
            }
        };
    }

    public static string GetDefaultJson()
    {
        return JsonSerializer.Serialize(CreateDefault());
    }
}