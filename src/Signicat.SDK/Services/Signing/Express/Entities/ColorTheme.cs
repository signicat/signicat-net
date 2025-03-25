using System.Runtime.Serialization;

namespace Signicat.Services.Signing.Express.Entities
{
    public enum ColorTheme
    {
        [EnumMember(Value = "Default")] Default = 0,

        [EnumMember(Value = "Black")] Black = 1,

        [EnumMember(Value = "Blue")] Blue = 2,

        [EnumMember(Value = "Cyan")] Cyan = 3,

        [EnumMember(Value = "Dark")] Dark = 4,

        [EnumMember(Value = "Lime")] Lime = 5,

        [EnumMember(Value = "Neutral")] Neutral = 6,

        [EnumMember(Value = "Pink")] Pink = 7,

        [EnumMember(Value = "Purple")] Purple = 8,

        [EnumMember(Value = "Red")] Red = 9,

        [EnumMember(Value = "Teal")] Teal = 10,

        [EnumMember(Value = "Indigo")] Indigo = 11,

        [EnumMember(Value = "LightBlue")] LightBlue = 12,

        [EnumMember(Value = "DeepPurple")] DeepPurple = 13,

        [EnumMember(Value = "Green")] Green = 14,

        [EnumMember(Value = "LightGreen")] LightGreen = 15,

        [EnumMember(Value = "Yellow")] Yellow = 16,

        [EnumMember(Value = "Amber")] Amber = 17,

        [EnumMember(Value = "Orange")] Orange = 18,

        [EnumMember(Value = "DeepOrange")] DeepOrange = 19,

        [EnumMember(Value = "Brown")] Brown = 20,

        [EnumMember(Value = "Gray")] Gray = 21,

        [EnumMember(Value = "BlueGray")] BlueGray = 22,

        [EnumMember(Value = "OceanGreen")] OceanGreen = 23,

        [EnumMember(Value = "GreenOcean")] GreenOcean = 24
    }
}